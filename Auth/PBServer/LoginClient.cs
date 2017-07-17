using Network.ReceivePackets;
using PBServer.managers;
using PBServer.network;
using PBServer.Network;
using PBServer.network.clientpacket;
using PBServer.network.Login.packets.clientpacket;
using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PointBlank.Auth.Network.ReceivePackets;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PBServer
{
	public class LoginClient
	{
		public EndPoint _address;

		private byte[] _buffer;

		public TcpClient _client;

		private static bool _isConnectedAviable = true;

		private Account _player;

		public NetworkStream _stream;

		private int clan_id;

		private string login;

		public bool networkDebug = true;

		public int CRYPT_KEY
		{
			get;
			set;
		}

		public LoginClient(TcpClient tcpClient)
		{
			CLogger.getInstance().info("[LoginClient] Client connect.");
			this._client = tcpClient;
			this._stream = tcpClient.GetStream();
			this._address = tcpClient.Client.RemoteEndPoint;
			this._player = new Account();
			new Thread(new ThreadStart(this.init)).Start();
			new Thread(new ThreadStart(this.read)).Start();
		}

		public void close()
		{
			bool debug = Config.debug;
			if (debug)
			{
				CLogger.getInstance().info("[LoginClient] Player disconnect.");
			}
			LoginClientManager.getInstance().removeClient(this);
			this._stream.Dispose();
		}

		public static byte[] decrypt(byte[] data, int shift)
		{
			byte b = data[data.Length - 1];
			for (int i = data.Length - 1; i > 0; i--)
			{
				data[i] = (byte)((int)(data[i - 1] & 255) << 8 - shift | (data[i] & 255) >> shift);
			}
			data[0] = (byte)((int)b << 8 - shift | (data[0] & 255) >> shift);
			return data;
		}

		public byte[] decryptC(byte[] data, int length)
		{
			int iD = this.getID();
			int cryptKey = this.getCryptKey();
			int num = this.getShift();
			bool flag = num <= 0;
			if (flag)
			{
				num = (iD + cryptKey) % 7 + 1;
				this.setShift(num);
			}
			byte[] array = new byte[data.Length];
			Array.Copy(data, 0, array, 0, array.Length);
			return LoginClient.decrypt(array, num);
		}

		public void EndSendCallBackStatic(IAsyncResult result)
		{
			try
			{
				this._stream.EndWrite(result);
				this._stream.Flush();
			}
			catch
			{
			}
		}

		public int getClan()
		{
			return this.clan_id;
		}

		public int getCryptKey()
		{
			return 29890;
		}

		public int getID()
		{
			return 5404;
		}

		public string getLogin()
		{
			return this.login;
		}

		public int getMyId()
		{
			return this.getPlayer().getPlayerId();
		}

		public Account getPlayer()
		{
			return this._player;
		}

		public int getShift()
		{
			return this.CRYPT_KEY;
		}

		private void handlePacket(byte[] buff)
		{
			ushort num = BitConverter.ToUInt16(new byte[]
			{
				buff[0],
				buff[1]
			}, 0);
			ushort num2 = BitConverter.ToUInt16(new byte[]
			{
				buff[0],
				buff[1]
			}, 0);
			BitConverter.ToString(buff).Replace("-", " ");
			bool flag = this.networkDebug;
			if (flag)
			{
				string[] array = BitConverter.ToString(buff).Split(new char[]
				{
					'-',
					',',
					'.',
					':',
					'\t'
				});
				string str = "";
				string[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					string str2 = array2[i];
					str = str + "0x" + str2 + " ";
				}
			}
			bool flag2 = num2 != 999;
			if (flag2)
			{
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().packet("Receive: " + (buff.Length + 2));
				CLogger.getInstance().packet("Opcode [Receive Login]: " + num2);
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().packet(Utils.HexDump(buff));
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
			}
			List<ReceiveBaseLoginPacket> list = new List<ReceiveBaseLoginPacket>();
			bool isConnectedAviable = LoginClient._isConnectedAviable;
			if (isConnectedAviable)
			{
				ushort num3 = num;
				if (num3 <= 2654)
				{
					if (num3 <= 2567)
					{
						if (num3 == 0)
						{
							LoginClient._isConnectedAviable = false;
							goto IL_322;
						}
						switch (num3)
						{
						case 2561:
						case 2563:
							Thread.Sleep(500);
							list.Add(new PROTOCOL_BASE_LOGIN_REQ(this, buff));
							goto IL_322;
						case 2565:
							list.Add(new PROTOCOL_BASE_GET_MYINFO_REQ(this, buff));
							goto IL_322;
						case 2567:
							list.Add(new PROTOCOL_AUTH_FRIEND_INFO_REQ(this, buff));
							goto IL_322;
						}
					}
					else
					{
						switch (num3)
						{
						case 2575:
							list.Add(new PROTOCOL_UNK_2575_REQ(this, buff));
							goto IL_322;
						case 2576:
						case 2578:
							break;
						case 2577:
							list.Add(new PROTOCOL_BASE_USER_LEAVE_REQ(this, buff));
							goto IL_322;
						case 2579:
							list.Add(new PROTOCOL_UNK_2579_REQ(this, buff));
							goto IL_322;
						default:
							if (num3 == 2654)
							{
								list.Add(new PROTOCOL_UNK_2654_REQ(this, buff));
								goto IL_322;
							}
							break;
						}
					}
				}
				else if (num3 <= 2666)
				{
					if (num3 == 2661)
					{
						list.Add(new PROTOCOL_UNK_2661_REQ(this, buff));
						goto IL_322;
					}
					if (num3 == 2666)
					{
						list.Add(new PROTOCOL_UNK_2666_REQ(this, buff));
						goto IL_322;
					}
				}
				else
				{
					if (num3 == 2672 || num3 == 2673)
					{
						Thread.Sleep(500);
						list.Add(new PROTOCOL_BASE_LOGIN_GARENA_REQ(this, buff));
						goto IL_322;
					}
					if (num3 == 2678)
					{
						list.Add(new PROTOCOL_UNK_2678_REQ(this, buff));
						goto IL_322;
					}
				}
				CLogger.getInstance().error("[Opcode LC] not found: " + num);
				IL_322:
				bool flag3 = list != null && list.ToArray().Length != 0;
				if (flag3)
				{
					foreach (ReceiveBaseLoginPacket current in list)
					{
						ThreadManager.runNewThread(new Thread(new ThreadStart(current.run)));
					}
				}
			}
		}

		public void init()
		{
			this.sendPacket(new PROTOCOL_SERVER_MESSAGE_CONNECTIONSUCCESS_ACK(this));
		}

		private void OnReceiveCallback(IAsyncResult result)
		{
			this._stream.EndRead(result);
			byte[] array = new byte[this._buffer.Length];
			this._buffer.CopyTo(array, 0);
			bool flag = array.Length >= 2;
			if (flag)
			{
				this.handlePacket(this.decryptC(array, array.Length));
			}
			new Thread(new ThreadStart(this.read)).Start();
		}

		private void OnReceiveCallbackStatic(IAsyncResult result)
		{
			try
			{
				int num = this._stream.EndRead(result);
				bool flag = num > 0;
				if (flag)
				{
					byte b = this._buffer[0];
					bool dataAvailable = this._stream.DataAvailable;
					if (dataAvailable)
					{
						this._buffer = new byte[(int)(b + 2)];
						this._stream.BeginRead(this._buffer, 0, (int)(b + 2), new AsyncCallback(this.OnReceiveCallback), result.AsyncState);
					}
				}
			}
			catch
			{
				this.close();
			}
		}

		public void read()
		{
			try
			{
				bool flag = this._stream != null && this._stream.CanRead;
				if (flag)
				{
					this._buffer = new byte[2];
					this._stream.BeginRead(this._buffer, 0, 2, new AsyncCallback(this.OnReceiveCallbackStatic), null);
				}
			}
			catch (Exception arg)
			{
				CLogger.getInstance().info("[LoginClient] read() Exception: \n" + arg);
				this.close();
			}
		}

		public Account restorePlayer(string acc)
		{
			return new DaoManager(null).getPlayerInfo(this._player.getPlayerId());
		}

		public void sendPacket(SendBaseLoginPacket bp)
		{
			bp.write();
			byte[] array = bp.ToByteArray();
			short value = Convert.ToInt16(array.Length - 2);
			List<byte> list = new List<byte>(array.Length + 2);
			list.AddRange(BitConverter.GetBytes(value));
			list.AddRange(array);
			byte[] array2 = list.ToArray();
			byte[] value2 = new byte[]
			{
				array2[2],
				array2[3]
			};
			ushort num = BitConverter.ToUInt16(value2, 0);
			bool flag = this.networkDebug;
			if (flag)
			{
				string[] array3 = BitConverter.ToString(array2).Split(new char[]
				{
					'-',
					',',
					'.',
					':',
					'\t'
				});
				string str = "";
				string[] array4 = array3;
				for (int i = 0; i < array4.Length; i++)
				{
					string str2 = array4[i];
					str = str + "0x" + str2 + " ";
				}
			}
			bool flag2 = array2.Length != 0;
			if (flag2)
			{
				this._stream.BeginWrite(array2, 0, array2.Length, new AsyncCallback(this.EndSendCallBackStatic), null);
			}
			bool flag3 = num != 545;
			if (flag3)
			{
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().packet("Send: " + array2.Length);
				CLogger.getInstance().packet("Opcode [Send Login]: " + num);
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().sendpacket(Utils.HexDump(array2));
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
			}
		}

		public void setClan(int clan_id)
		{
			this.clan_id = clan_id;
		}

		public void setLogin(string lo)
		{
			this.login = lo;
		}

		public void setPlayer(Account p)
		{
			this._player = p;
		}

		public void setShift(int key)
		{
			this.CRYPT_KEY = key;
		}
	}
}
