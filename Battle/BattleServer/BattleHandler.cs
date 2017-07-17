using PBServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace BattleServer
{
	public class BattleHandler
	{
		private UdpClient _client;

		public Player player3
		{
			get;
			set;
		}

		public BattleHandler(UdpClient client)
		{
			this._client = client;
			try
			{
				this._client.BeginReceive(new AsyncCallback(this.BeginReceive), null);
			}
			catch (Exception)
			{
			}
		}

		public void BeginReceive(IAsyncResult result)
		{
			IPEndPoint iPEndPoint = null;
			MemoryStream memoryStream = new MemoryStream();
			MemoryStream memoryStream2 = new MemoryStream();
			byte[] array = this._client.EndReceive(result, ref iPEndPoint);
			byte b = array[0];
			if (b <= 68)
			{
				switch (b)
				{
				case 1:
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					for (int i = 0; i < playersINRoom.Count; i++)
					{
						Player player = playersINRoom[i];
						bool flag = player != null;
						if (flag)
						{
							this._client.Send(array, array.Length, player._address.ToString(), 29890);
						}
					}
					return;
				}
				case 2:
					break;
				case 3:
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag2 = playersINRoom != null;
					if (flag2)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag3 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag3)
							{
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream2 = new MemoryStream();
								bool flag4 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag4)
								{
									memoryStream3.WriteByte(4);
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(4);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(3);
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(3);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
				case 4:
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag5 = playersINRoom != null;
					if (flag5)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag6 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag6)
							{
								CLogger.getInstance().extra_info("Client[1]: " + player2._address.ToString());
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(4);
								bool flag7 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag7)
								{
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
				default:
					if (b == 9)
					{
						MemoryStream memoryStream3 = new MemoryStream();
						memoryStream3.WriteByte(9);
						return;
					}
					switch (b)
					{
					case 65:
						for (int i = 0; i < Program.getRoomManager().getCountPlayer(iPEndPoint.Address); i++)
						{
							Player player2 = Program.getRoomManager().getPlayer(iPEndPoint.Address, i);
							bool flag8 = player2 != null;
							if (flag8)
							{
								CLogger.getInstance().extra_info("Client[1]: " + player2._address.ToString());
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(66);
								memoryStream3.WriteByte(array[1]);
								memoryStream3.Write(new byte[5], 0, 5);
								memoryStream3.WriteByte(29);
								memoryStream3.Write(new byte[21], 0, 21);
								this._client.Send(memoryStream3.ToArray(), (int)memoryStream3.Length, iPEndPoint);
								CLogger.getInstance().extra_info("Client[2]: " + player2._address.ToString());
								memoryStream2 = new MemoryStream();
								memoryStream2.WriteByte(66);
								memoryStream2.WriteByte(array[1]);
								memoryStream2.Write(new byte[5], 0, 5);
								memoryStream2.WriteByte(29);
								memoryStream2.Write(new byte[21], 0, 21);
								this._client.Send(memoryStream2.ToArray(), (int)memoryStream3.Length, iPEndPoint);
							}
						}
						return;
					case 67:
						new Player()._address = iPEndPoint.Address;
						CLogger.getInstance().console("-------------------------------------------------------------------------------");
						Program.getRoomManager().RemovePlayerInRoom(iPEndPoint.Address);
						return;
					case 68:
						new Player()._address = iPEndPoint.Address;
						CLogger.getInstance().console("-------------------------------------------------------------------------------");
						Program.getRoomManager().RemovePlayerInRoom(iPEndPoint.Address);
						return;
					}
					break;
				}
			}
			else if (b <= 97)
			{
				if (b == 84)
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag9 = playersINRoom != null;
					if (flag9)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag10 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag10)
							{
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(84);
								memoryStream2 = new MemoryStream();
								memoryStream2.WriteByte(84);
								bool flag11 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag11)
								{
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 3, array.Length - 3);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
				if (b == 97)
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag12 = playersINRoom != null;
					if (flag12)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag13 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag13)
							{
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(97);
								memoryStream2 = new MemoryStream();
								memoryStream2.WriteByte(97);
								bool flag14 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag14)
								{
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 2, array.Length - 2);
								memoryStream2.Write(array, 3, array.Length - 3);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
								this._client.Send(memoryStream2.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
			}
			else
			{
				if (b == 131)
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag15 = playersINRoom != null;
					if (flag15)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag16 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag16)
							{
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(131);
								memoryStream2 = new MemoryStream();
								memoryStream2.WriteByte(131);
								bool flag17 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag17)
								{
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
								memoryStream2.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream2.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
				if (b == 132)
				{
					List<Player> playersINRoom = Program.getRoomManager().getPlayersINRoom(iPEndPoint.Address);
					bool flag18 = playersINRoom != null;
					if (flag18)
					{
						for (int i = 0; i < playersINRoom.Count; i++)
						{
							Player player2 = playersINRoom[i];
							bool flag19 = player2 != null && player2._address.ToString() != iPEndPoint.Address.ToString();
							if (flag19)
							{
								MemoryStream memoryStream3 = new MemoryStream();
								memoryStream3.WriteByte(132);
								memoryStream2 = new MemoryStream();
								memoryStream2.WriteByte(132);
								bool flag20 = Program.getRoomManager().getRoom(iPEndPoint.Address).type == 3;
								if (flag20)
								{
									memoryStream3.WriteByte(255);
									memoryStream2.WriteByte(255);
								}
								else
								{
									memoryStream3.WriteByte(array[1]);
									memoryStream2.WriteByte(array[1]);
								}
								memoryStream3.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream3.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
								memoryStream2.Write(array, 2, array.Length - 2);
								this._client.Send(memoryStream2.ToArray(), memoryStream3.ToArray().Length, player2._address.ToString(), 29890);
							}
						}
					}
					return;
				}
			}
			CLogger.getInstance().extra_info("Opcode: " + array[0]);
		}
	}
}
