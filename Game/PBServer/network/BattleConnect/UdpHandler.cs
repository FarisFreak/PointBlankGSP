using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace PBServer.network.BattleConnect
{
	public class UdpHandler
	{
		private List<Account> _players = new List<Account>();

		private static TcpListener _clientGameListener;

		public static UdpHandler _instance;

		private UdpClient _client;

		static UdpHandler()
		{
			UdpHandler._instance = new UdpHandler();
		}

		public UdpHandler()
		{
			this._client = new UdpClient(40000);
		}

		public void AddPlayerInUdpRoom(Account p, Account host)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte(0);
			bool flag = !Config.ExternalOrInternalSendIpUdp;
			if (flag)
			{
				memoryStream.Write(p.getLocalAddress(), 0, 4);
			}
			else
			{
				memoryStream.Write(p.publicAdddress(), 0, 4);
			}
			memoryStream.WriteByte((byte)p.getSlot());
			memoryStream.WriteByte(0);
			bool flag2 = !Config.ExternalOrInternalSendIpUdp;
			if (flag2)
			{
				memoryStream.Write(host.getLocalAddress(), 0, 4);
			}
			else
			{
				memoryStream.Write(host.publicAdddress(), 0, 4);
			}
			this.SendPacket(2, memoryStream.ToArray());
		}

		public void CreateBattleUdpRoom(Room r, int type)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte(16);
			for (int i = 0; i < 16; i++)
			{
				memoryStream.WriteByte((byte)i);
				bool flag = r.getSlot(i).state != SLOT_STATE.SLOT_STATE_READY && r.getSlot(i).state != SLOT_STATE.SLOT_STATE_LOAD;
				if (flag)
				{
					memoryStream.Write(new byte[4], 0, 4);
				}
				else
				{
					bool flag2 = !Config.ExternalOrInternalSendIpUdp;
					if (flag2)
					{
						memoryStream.Write(r.getPlayerBySlot(i).getLocalAddress(), 0, 4);
					}
					else
					{
						try
						{
							bool flag3 = r.getPlayerBySlot(i).customAddress != null;
							if (flag3)
							{
								memoryStream.Write(r.getPlayerBySlot(i).customAddress.GetAddressBytes(), 0, 4);
							}
							else
							{
								memoryStream.Write(IPAddress.Parse(r.getPlayerBySlot(i).getIP()).GetAddressBytes(), 0, 4);
							}
						}
						catch (Exception ex)
						{
							CLogger.getInstance().warning(ex.ToString());
							memoryStream.Write(r.getPlayerBySlot(i).getLocalAddress(), 0, 4);
						}
					}
				}
			}
			memoryStream.WriteByte((byte)type);
			this.SendPacket(1, memoryStream.ToArray());
		}

		public void DeleteRoom(IPAddress host)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(host.GetAddressBytes(), 0, 4);
			this.SendPacket(3, memoryStream.ToArray());
		}

		public static UdpHandler getInstance()
		{
			return UdpHandler._instance;
		}

		public void PingUdpServer()
		{
			this.SendPacket(9, new byte[4]);
		}

		public void RemovePlayerInRoom(Account p)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.WriteByte((byte)p.getSlot());
			memoryStream.Write(p.publicAdddress(), 0, 4);
			this.SendPacket(4, memoryStream.ToArray());
		}

		public void SendPacket(short opcode, byte[] data)
		{
			MemoryStream memoryStream = new MemoryStream();
			memoryStream.Write(BitConverter.GetBytes(opcode), 0, 2);
			memoryStream.Write(data, 0, data.Length);
			this._client.Send(memoryStream.ToArray(), memoryStream.ToArray().Length, new IPEndPoint(IPAddress.Parse(Config.UDPHost), 60000));
			UdpHandler._clientGameListener = new TcpListener(IPAddress.Parse(Config.UDPHost), 60000);
			CLogger.getInstance().info("[Network] Battle Server IP: " + UdpHandler._clientGameListener.LocalEndpoint.ToString());
		}
	}
}
