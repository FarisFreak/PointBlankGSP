using Network.ReceivePackets;
using PBServer.managers;
using PBServer.network;
using PBServer.Network;
using PBServer.network.BattleConnect;
using PBServer.network.clientpacket;
using PBServer.network.Game.packets.clientpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.network.gsPacket.clientpackets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PBServer
{
	public class GameClient
	{
		public EndPoint _address;

		private byte[] _buffer;

		private int _channelID = -1;

		public TcpClient _client;

		private static bool _isConnectedAviable = true;

		private bool _prepareToClose = false;

		public NetworkStream _stream;

		private static bool cf = true;

		private string IPClient;

		public bool networkDebug = true;

		private int player_id = 0;

		public int CRYPT_KEY
		{
			get;
			set;
		}

		public GameClient(TcpClient tcpClient)
		{
			CLogger.getInstance().info("[GameClient] Client connect. ");
			this._client = tcpClient;
			this._stream = tcpClient.GetStream();
			this._address = tcpClient.Client.RemoteEndPoint;
			this._stream.ReadTimeout = 10000;
			this.IPClient = this._address.ToString();
			new Thread(new ThreadStart(this.init)).Start();
			new Thread(new ThreadStart(this.read)).Start();
		}

		public void close()
		{
			this._prepareToClose = true;
			try
			{
				AccountManager.getInstance().get(this.getPlayer().name)._status = 0;
				this.getPlayer()._status = 0;
				AccountManager.getInstance().get(this.getPlayer().name).setOnlineStatus(false);
				bool flag = this.getPlayer() != null;
				if (flag)
				{
					bool flag2 = this.getPlayer().getRoom() != null;
					if (flag2)
					{
						UdpHandler.getInstance().RemovePlayerInRoom(this.getPlayer());
						ChannelInfoHolder.getChannel(this.getChannelId()).getRooms()[this.getPlayer().getRoom().getRoomId()].removePlayer(this.getPlayer());
						this.getPlayer().setRoom(null);
					}
					bool flag3 = this.getChannelId() >= 0;
					if (flag3)
					{
						ChannelInfoHolder.getChannel(this.getChannelId()).removePlayer(this.getPlayer());
					}
				}
				AccountManager.getInstance().get(this.getPlayer().name).setClient(null);
				GameClientManager.getInstance().removeClient(this);
				bool connected = this._client.Connected;
				if (connected)
				{
					this._client.Close();
					this._stream = null;
				}
				CLogger.getInstance().info("[GameClient] Player disconnect.");
			}
			catch (Exception ex)
			{
				CLogger.getInstance().warning(ex.ToString());
			}
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
			return GameClient.decrypt(array, num);
		}

		public void EndSendStaticPacket(IAsyncResult result)
		{
			try
			{
				this._stream.EndWrite(result);
			}
			catch
			{
			}
		}

		~GameClient()
		{
			this.close();
		}

		public void form()
		{
			bool flag = GameClient.cf && !Directory.Exists("unks_game");
			if (flag)
			{
				Directory.CreateDirectory("unks_game");
			}
		}

		public int getChannelId()
		{
			return this._channelID;
		}

		public int getCryptKey()
		{
			return 29890;
		}

		public int getID()
		{
			return 5404;
		}

		public string getIPString()
		{
			return IPAddress.Parse(this.IPClient.Split(new char[]
			{
				':'
			})[0]).ToString();
		}

		public Account getPlayer()
		{
			return AccountManager.getInstance().getAccountInObjectId(this.player_id) ?? null;
		}

		public int getPlayerId()
		{
			return this.player_id;
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
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().packet("Receive: " + (buff.Length + 2));
				CLogger.getInstance().packet("Opcode [Receive Game]: " + num2);
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
				CLogger.getInstance().packet(Utils.HexDump(buff));
				CLogger.getInstance().console("-------------------------------------------------------------------------------");
			}
			List<ReceiveBaseGamePacket> list = new List<ReceiveBaseGamePacket>();
			bool flag2 = !GameClient._isConnectedAviable;
			if (!flag2)
			{
				ushort num3 = num;
				bool flag3 = num3 <= 10000;
				if (flag3)
				{
					ushort num4 = num3;
					if (num4 <= 2654)
					{
						if (num4 <= 1332)
						{
							if (num4 <= 530)
							{
								if (num4 <= 297)
								{
									if (num4 <= 284)
									{
										if (num4 == 282)
										{
											list.Add(new PROTOCOL_AUTH_FRIEND_INVITED_REQ(this, buff));
											goto IL_1016;
										}
										if (num4 == 284)
										{
											list.Add(new PROTOCOL_AUTH_FRIEND_DELETE_REQ(this, buff));
											goto IL_1016;
										}
									}
									else
									{
										if (num4 == 290)
										{
											list.Add(new PROTOCOL_AUTH_RECV_WHISPER_REQ(this, buff));
											goto IL_1016;
										}
										if (num4 == 297)
										{
											list.Add(new PROTOCOL_AUTH_FIND_USER_REQ(this, buff));
											goto IL_1016;
										}
									}
								}
								else if (num4 <= 422)
								{
									if (num4 == 417)
									{
										list.Add(new PROTOCOL_MESSENGER_NOTE_SEND_REQ(this, buff));
										goto IL_1016;
									}
									if (num4 == 422)
									{
										list.Add(new CM_422(this, buff));
										goto IL_1016;
									}
								}
								else
								{
									if (num4 == 424)
									{
										list.Add(new CM_REMOVE_MESSAGE_IN_BOX(this, buff));
										goto IL_1016;
									}
									if (num4 == 530)
									{
										list.Add(new PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ(this, buff));
										goto IL_1016;
									}
								}
							}
							else if (num4 <= 544)
							{
								if (num4 <= 536)
								{
									if (num4 == 534)
									{
										list.Add(new PROTOCOL_INVENTORY_EQUIP_NOTUSED_REQ(this, buff));
										goto IL_1016;
									}
									if (num4 == 536)
									{
										list.Add(new PROTOCOL_INVENTORY_COUPON_ACTIVATE_REQ(this, buff));
										goto IL_1016;
									}
								}
								else
								{
									if (num4 == 542)
									{
										list.Add(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ(this, buff));
										goto IL_1016;
									}
									if (num4 == 544)
									{
										list.Add(new PROTOCOL_AUTH_GET_POINT_CASH_REQ(this, buff));
										goto IL_1016;
									}
								}
							}
							else if (num4 <= 1316)
							{
								if (num4 == 548)
								{
									list.Add(new PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ(this, buff));
									goto IL_1016;
								}
								switch (num4)
								{
								case 1304:
									list.Add(new PROTOCOL_CS_DETAIL_INFO_REQ(this, buff));
									goto IL_1016;
								case 1306:
									list.Add(new PROTOCOL_CS_MEMBER_CONTEXT_REQ(this, buff));
									goto IL_1016;
								case 1308:
									list.Add(new PROTOCOL_CS_MEMBER_LIST_REQ(this, buff));
									goto IL_1016;
								case 1310:
									list.Add(new PROTOCOL_CS_CREATE_CLAN_REQ(this, buff));
									goto IL_1016;
								case 1312:
									list.Add(new CM_CLAN_DISBAND(this, buff));
									goto IL_1016;
								case 1314:
									list.Add(new opcode_1314_REQ(this, buff));
									goto IL_1016;
								case 1316:
									list.Add(new opcode_1316_REQ(this, buff));
									goto IL_1016;
								}
							}
							else
							{
								if (num4 == 1320)
								{
									list.Add(new opcode_1320_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 1322)
								{
									list.Add(new PROTOCOL_CS_REQUEST_LIST_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 1332)
								{
									list.Add(new CM_CLAN_PLAYER_LEAVE(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 2575)
						{
							if (num4 <= 1447)
							{
								if (num4 <= 1392)
								{
									switch (num4)
									{
									case 1358:
										list.Add(new CM_CHAT_CLAN(this, buff));
										goto IL_1016;
									case 1359:
									case 1361:
									case 1363:
										break;
									case 1360:
										list.Add(new opcode_1360_REQ(this, buff));
										goto IL_1016;
									case 1362:
										list.Add(new CM_CLAN_SAVEINFO1(this, buff));
										goto IL_1016;
									case 1364:
										list.Add(new CM_CLAN_SAVEINFO2(this, buff));
										goto IL_1016;
									default:
										if (num4 == 1392)
										{
											list.Add(new CM_1392(this, buff));
											goto IL_1016;
										}
										break;
									}
								}
								else
								{
									if (num4 == 1416)
									{
										list.Add(new CM_CLAN_REQUESITES_FOR_CREATE(this, buff));
										goto IL_1016;
									}
									switch (num4)
									{
									case 1441:
										list.Add(new PROTOCOL_CS_CLIENT_ENTER_REQ(this, buff));
										goto IL_1016;
									case 1443:
										list.Add(new PROTOCOL_CS_CLIENT_LEAVE_REQ(this, buff));
										goto IL_1016;
									case 1445:
										list.Add(new PROTOCOL_CS_CLIENT_CLAN_LIST_REQ(this, buff));
										goto IL_1016;
									case 1447:
										list.Add(new PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_REQ(this, buff));
										goto IL_1016;
									}
								}
							}
							else if (num4 <= 1538)
							{
								if (num4 == 1451)
								{
									list.Add(new CM_CLAN_QUANTITY(this, buff));
									goto IL_1016;
								}
								if (num4 == 1538)
								{
									list.Add(new CM_1538(this, buff));
									goto IL_1016;
								}
							}
							else
							{
								if (num4 == 1540)
								{
									list.Add(new CM_1540(this, buff));
									goto IL_1016;
								}
								if (num4 == 1546)
								{
									list.Add(new CM_1546(this, buff));
									goto IL_1016;
								}
								switch (num4)
								{
								case 2571:
									list.Add(new PROTOCOL_BASE_GET_CHANNELLIST_REQ(this, buff));
									goto IL_1016;
								case 2573:
									list.Add(new PROTOCOL_BASE_SELECT_CHANNEL_REQ(this, buff));
									goto IL_1016;
								case 2575:
									list.Add(new opcode_2575_REQ(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 2605)
						{
							if (num4 <= 2581)
							{
								if (num4 == 2579)
								{
									list.Add(new PROTOCOL_BASE_USER_ENTER_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 2581)
								{
									list.Add(new PROTOCOL_SETTINGS_SAVE_REQ(this, buff));
									goto IL_1016;
								}
							}
							else
							{
								if (num4 == 2601)
								{
									list.Add(new PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 2605)
								{
									list.Add(new PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 2623)
						{
							if (num4 == 2607)
							{
								list.Add(new PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ(this, buff));
								goto IL_1016;
							}
							switch (num4)
							{
							case 2619:
								list.Add(new PROTOCOL_TITLE_GET_REQ(this, buff));
								goto IL_1016;
							case 2621:
								list.Add(new PROTOCOL_TITLE_USE_REQ(this, buff));
								goto IL_1016;
							case 2623:
								list.Add(new PROTOCOL_TITLE_DETACH_REQ(this, buff));
								goto IL_1016;
							}
						}
						else
						{
							if (num4 == 2627)
							{
								list.Add(new PROTOCOL_CHAT_NORMAL_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 2639)
							{
								list.Add(new CM_LOBBY_GET_PLAYERINFO(this, buff));
								goto IL_1016;
							}
							if (num4 == 2654)
							{
								list.Add(new CM_PLAYER_EXIT_GAME(this, buff));
								goto IL_1016;
							}
						}
					}
					else if (num4 <= 3372)
					{
						if (num4 <= 3101)
						{
							if (num4 <= 3073)
							{
								if (num4 <= 2845)
								{
									switch (num4)
									{
									case 2817:
										list.Add(new PROTOCOL_SHOP_LEAVE_REQ(this, buff));
										goto IL_1016;
									case 2818:
									case 2820:
										break;
									case 2819:
										list.Add(new PROTOCOL_SHOP_ENTER_REQ(this, buff));
										goto IL_1016;
									case 2821:
										list.Add(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ(this, buff));
										new PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ(this, buff).run();
										goto IL_1016;
									default:
										if (num4 == 2845)
										{
											list.Add(new opcode_2845_REQ(this, buff));
											goto IL_1016;
										}
										break;
									}
								}
								else
								{
									if (num4 == 2901)
									{
										list.Add(new opcode_2901_REQ(this, buff));
										goto IL_1016;
									}
									if (num4 == 3073)
									{
										list.Add(new PROTOCOL_LOBBY_GET_ROOMLIST_REQ(this, buff));
										goto IL_1016;
									}
								}
							}
							else if (num4 <= 3087)
							{
								switch (num4)
								{
								case 3077:
									list.Add(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(this, buff));
									goto IL_1016;
								case 3078:
								case 3080:
								case 3082:
									break;
								case 3079:
									list.Add(new PROTOCOL_LOBBY_ENTER_REQ(this, buff));
									goto IL_1016;
								case 3081:
									list.Add(new PROTOCOL_LOBBY_JOIN_ROOM_REQ(this, buff));
									goto IL_1016;
								case 3083:
									list.Add(new PROTOCOL_LOBBY_LEAVE_REQ(this, buff));
									goto IL_1016;
								default:
									if (num4 == 3087)
									{
										list.Add(new PROTOCOL_LOBBY_GET_ROOMINFO_REQ(this, buff));
										goto IL_1016;
									}
									break;
								}
							}
							else
							{
								if (num4 == 3089)
								{
									list.Add(new PROTOCOL_LOBBY_CREATE_ROOM_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 3099)
								{
									list.Add(new CM_LOBBY_GET_PLAYERINFO2(this, buff));
									goto IL_1016;
								}
								if (num4 == 3101)
								{
									list.Add(new PROTOCOL_LOBBY_CREATE_NICK_NAME_REQ(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 3344)
						{
							if (num4 <= 3337)
							{
								switch (num4)
								{
								case 3329:
									list.Add(new PROTOCOL_BATTLE_HOLE_CHECK_REQ(this, buff));
									goto IL_1016;
								case 3330:
								case 3332:
									break;
								case 3331:
									list.Add(new PROTOCOL_BATTLE_READYBATTLE_REQ(this, buff));
									goto IL_1016;
								case 3333:
									list.Add(new PROTOCOL_BATTLE_STARTBATTLE_REQ(this, buff));
									goto IL_1016;
								default:
									if (num4 == 3337)
									{
										list.Add(new PROTOCOL_BATTLE_RESPAWN_REQ(this, buff));
										goto IL_1016;
									}
									break;
								}
							}
							else
							{
								if (num4 == 3343)
								{
									list.Add(new CM_BATTLE_NETWORK_PROBLEM(this, buff));
									goto IL_1016;
								}
								if (num4 == 3344)
								{
									list.Add(new PROTOCOL_BATTLE_SENDPING_REQ(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 3350)
						{
							if (num4 == 3348)
							{
								list.Add(new PROTOCOL_BATTLE_PRESTARTBATTLE_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 3350)
							{
								list.Add(new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_REQ(this, buff));
								goto IL_1016;
							}
						}
						else
						{
							switch (num4)
							{
							case 3354:
								list.Add(new PROTOCOL_BATTLE_DEATH_REQ(this, buff));
								goto IL_1016;
							case 3355:
							case 3357:
								break;
							case 3356:
								list.Add(new PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_REQ(this, buff));
								goto IL_1016;
							case 3358:
								list.Add(new PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_REQ(this, buff));
								goto IL_1016;
							default:
								if (num4 == 3368)
								{
									list.Add(new PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 3372)
								{
									list.Add(new PROTOCOL_BATTLE_TIMERSYNC_REQ(this, buff));
									goto IL_1016;
								}
								break;
							}
						}
					}
					else if (num4 <= 3603)
					{
						if (num4 <= 3394)
						{
							if (num4 <= 3378)
							{
								if (num4 == 3376)
								{
									list.Add(new PROTOCOL_BATTLE_BOT_CHANGELEVEL_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 3378)
								{
									list.Add(new PROTOCOL_BATTLE_RESPAWN_FOR_AI_REQ(this, buff));
									goto IL_1016;
								}
							}
							else
							{
								if (num4 == 3384)
								{
									list.Add(new PROTOCOL_BATTLE_ENDBATTLE_REQ(this, buff));
									goto IL_1016;
								}
								if (num4 == 3394)
								{
									list.Add(new PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_REQ(this, buff));
									goto IL_1016;
								}
							}
						}
						else if (num4 <= 3412)
						{
							if (num4 == 3396)
							{
								list.Add(new PROTOCOL_BATTLE_SUGGEST_KICKVOTE_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 3412)
							{
								list.Add(new opcode_3413_REQ(this, buff));
								goto IL_1016;
							}
						}
						else
						{
							if (num4 == 3585)
							{
								list.Add(new PROTOCOL_INVENTORY_ENTER_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 3589)
							{
								list.Add(new PROTOCOL_INVENTORY_LEAVE_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 3603)
							{
								list.Add(new opcode_3604_REQ(this, buff));
								goto IL_1016;
							}
						}
					}
					else if (num4 <= 3854)
					{
						if (num4 <= 3841)
						{
							if (num4 == 3619)
							{
								list.Add(new opcode_3620_REQ(this, buff));
								goto IL_1016;
							}
							if (num4 == 3841)
							{
								list.Add(new PROTOCOL_ROOM_GET_PLAYERINFO_REQ(this, buff));
								goto IL_1016;
							}
						}
						else
						{
							switch (num4)
							{
							case 3845:
								list.Add(new PROTOCOL_ROOM_CHANGE_TEAM_REQ(this, buff));
								goto IL_1016;
							case 3846:
							case 3848:
								break;
							case 3847:
								list.Add(new opcode_3847_REQ(this, buff));
								goto IL_1016;
							case 3849:
								list.Add(new PROTOCOL_ROOM_CLOSE_SLOT_REQ(this, buff));
								goto IL_1016;
							default:
								if (num4 == 3854)
								{
									list.Add(new PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ(this, buff));
									goto IL_1016;
								}
								break;
							}
						}
					}
					else if (num4 <= 3884)
					{
						switch (num4)
						{
						case 3858:
							list.Add(new CM_3858(this, buff));
							goto IL_1016;
						case 3859:
						case 3860:
						case 3861:
						case 3863:
						case 3867:
						case 3869:
						case 3871:
						case 3873:
							break;
						case 3862:
							list.Add(new PROTOCOL_ROOM_INFO_ENTER_REQ(this, buff));
							goto IL_1016;
						case 3864:
							list.Add(new PROTOCOL_ROOM_INFO_LEAVE_REQ(this, buff));
							goto IL_1016;
						case 3865:
							list.Add(new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_REQ(this, buff));
							goto IL_1016;
						case 3866:
							list.Add(new CM_ROOM_IM_HOST(this, buff));
							goto IL_1016;
						case 3868:
							list.Add(new CM_3868(this, buff));
							goto IL_1016;
						case 3870:
							list.Add(new PROTOCOL_ROOM_CHANGE_HOST_REQ(this, buff));
							goto IL_1016;
						case 3872:
							list.Add(new PROTOCOL_ROOM_GET_NEW_HOST_REQ(this, buff));
							goto IL_1016;
						case 3874:
							list.Add(new PROTOCOL_ROOM_HOST_CHANGE_TEAM_REQ(this, buff));
							goto IL_1016;
						default:
							if (num4 == 3884)
							{
								list.Add(new CM_INVITE_ROOM_RETURN(this, buff));
								goto IL_1016;
							}
							break;
						}
					}
					else
					{
						if (num4 == 3886)
						{
							list.Add(new opcode_3591_REQ(this, buff));
							goto IL_1016;
						}
						if (num4 == 3904)
						{
							list.Add(new PROTOCOL_BATTLE_STARTING_REQ(this, buff));
							goto IL_1016;
						}
						if (num4 == 3906)
						{
							list.Add(new opcode_3593_REQ(this, buff));
							goto IL_1016;
						}
					}
				}
				CLogger.getInstance().error("[Opcode GC] not found: " + num);
				IL_1016:
				bool flag4 = list != null && list.ToArray().Length != 0;
				if (flag4)
				{
					foreach (ReceiveBaseGamePacket current in list)
					{
						ThreadManager.runNewThread(new Thread(new ThreadStart(current.run)));
					}
				}
			}
		}

		public void init()
		{
			this.sendPacket(new PROTOCOL_BASE_ENTER_CHANNELSELECT_ACK(this));
		}

		private void OnReceiveCallback(IAsyncResult result)
		{
			try
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
			catch
			{
			}
		}

		private void OnReceiveCallbackStatic(IAsyncResult result)
		{
			try
			{
				bool flag = !this._prepareToClose && this._stream != null && this._stream.EndRead(result) > 0;
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
			catch (IOException)
			{
				this.close();
			}
			catch (Exception ex)
			{
				this.close();
				CLogger.getInstance().warning(string.Concat(new object[]
				{
					"[Error] ",
					this.getPlayer().getPlayerName(),
					": ",
					this._address,
					" was closed by force: ",
					ex
				}));
			}
		}

		public void read()
		{
			try
			{
				bool flag = !this._prepareToClose && (this._stream != null && this._client.Connected) && this._stream.CanRead;
				if (flag)
				{
					this._buffer = new byte[2];
					this._stream.BeginRead(this._buffer, 0, 2, new AsyncCallback(this.OnReceiveCallbackStatic), null);
				}
			}
			catch (Exception arg)
			{
				CLogger.getInstance().info("[GameClient] read() Exception: \n" + arg);
				this.close();
			}
		}

		public Account restoreAccount(string acc)
		{
			Account account = AccountManager.getInstance().get(acc);
			bool flag = account == null;
			Account result;
			if (flag)
			{
				result = null;
			}
			else
			{
				account.setConnected(true);
				this.setAccount(account.player_id);
				result = account;
			}
			return result;
		}

		public void sendPacket(SendBaseGamePacket bp)
		{
			try
			{
				bool flag = !this._prepareToClose && this._stream != null;
				if (flag)
				{
					bp.write();
					byte[] array = bp.ToByteArray();
					short value = Convert.ToInt16(array.Length - 2);
					List<byte> list = new List<byte>(array.Length + 2);
					list.AddRange(BitConverter.GetBytes(value));
					list.AddRange(array);
					byte[] array2 = list.ToArray();
					byte[] expr_65 = new byte[]
					{
						array2[2],
						array2[3]
					};
					byte[] array3 = list.ToArray();
					byte[] value2 = new byte[]
					{
						array3[2],
						array3[3]
					};
					ushort num = BitConverter.ToUInt16(value2, 0);
					bool flag2 = this.networkDebug;
					if (flag2)
					{
						CLogger.getInstance().console("-------------------------------------------------------------------------------");
						CLogger.getInstance().packet("Send: " + array2.Length);
						CLogger.getInstance().packet("Opcode [Send Game]: " + num);
						CLogger.getInstance().console("-------------------------------------------------------------------------------");
						CLogger.getInstance().sendpacket(Utils.HexDump(array2));
						CLogger.getInstance().console("-------------------------------------------------------------------------------");
					}
					bool flag3 = array2.Length != 0;
					if (flag3)
					{
						this._stream.BeginWrite(array2, 0, array2.Length, new AsyncCallback(this.EndSendStaticPacket), null);
					}
				}
			}
			catch (Exception arg)
			{
				CLogger.getInstance().info("[GameClient] read() Exception: \n" + arg);
				this.close();
			}
		}

		public void setAccount(int playerid)
		{
			this.player_id = playerid;
		}

		public void setChannelId(int id)
		{
			CLogger.getInstance().warning(string.Concat(new string[]
			{
				"[Channel] ",
				this.getPlayer().getPlayerName(),
				" enter to channel[",
				id.ToString(),
				"]"
			}));
			this._channelID = id;
		}

		public void setShift(int key)
		{
			this.CRYPT_KEY = key;
		}
	}
}
