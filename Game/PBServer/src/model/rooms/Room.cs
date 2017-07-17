using Model;
using PBServer.data.xml.holders;
using PBServer.model.ENUMS;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.network.Game.packets.serverpackets;
using PBServer.src.network.gsPacket.serverpackets;
using System;
using System.Collections.Generic;

namespace PBServer.src.model.rooms
{
	public class Room
	{
		public int _aiCount;

		public int _aiLevel;

		private int figth;

		public int _blueDeaths = 0;

		public int roundQty;

		public int _blueKills = 0;

		public int _channelId;

		private bool _isInFight = true;

		public int _leader;

		public int _redDeaths = 0;

		public int _redKills = 0;

		public StageMode mode;

		private ROOM_STATE _room_state;

		private int _roomId;

		public SLOT[] _slots = new SLOT[16];

		public int _timeRoom;

		public int allweapons;

		public int autobalans;

		public int[] BLUE_TEAM = new int[]
		{
			1,
			3,
			5,
			7,
			9,
			11,
			13,
			15
		};

		public int bomb = 5;

		private Chat chat = new Chat();

		public int GMTimeOut = -1;

		private static int[] KILLS = new int[]
		{
			60,
			80,
			100,
			120,
			140,
			160
		};

		public int killtime;

		public int limit;

		public int map_id;

		public string map_name;

		private int redKills;

		private int redDeaths;

		private int blueKills;

		private int blueDeaths;

		private int aiCount;

		private int aiLevel;

		private int redWinRounds;

		private int blueWinRounds;

		public int redTeamCount;

		public int blueTeamCount;

		public string name;

		public static int NET_ROOM_NAME_SIZE = 23;

		public static int NET_ROOM_PW = 4;

		public string password;

		public int random_map;

		public int[] RED_TEAM = new int[]
		{
			0,
			2,
			4,
			6,
			8,
			10,
			12,
			14
		};

		public int refreshCheck = 0;

		public int room_type;

		private static int[] ROUNDS = new int[]
		{
			0,
			3,
			5,
			7,
			9
		};

		public int seeConf;

		public int server_type = 1;

		public int special;

		public int stage4v4;

		public int type;

		private static int[] TIMES = new int[]
		{
			3,
			5,
			7,
			5,
			10,
			15,
			20,
			25,
			30
		};

		public int unkc1;

		public int unkc2;

		public void setFigth(int figth)
		{
			this.figth = figth;
		}

		public bool isBomb()
		{
			return this.mode == StageMode.Bomb;
		}

		public bool isEliminate()
		{
			return this.mode == StageMode.Eliminate;
		}

		public bool isEscape()
		{
			return this.mode == StageMode.Escape;
		}

		public bool isCrossCounter()
		{
			return this.mode == StageMode.CrossCounter;
		}

		public bool isAI()
		{
			return this.mode == StageMode.CrossCounter;
		}

		public int getServerType()
		{
			return this.server_type;
		}

		public List<Account> getReadyPlayerList()
		{
			List<Account> allPlayers = this.getAllPlayers();
			foreach (Account current in allPlayers)
			{
				bool flag = current.hasSlotState(SLOT_STATE.SLOT_STATE_READY);
				if (flag)
				{
					allPlayers.Add(current);
				}
			}
			return allPlayers;
		}

		public SLOT getRoomSlotByPlayer(Account player)
		{
			SLOT[] slots = this._slots;
			SLOT result;
			for (int i = 0; i < slots.Length; i++)
			{
				SLOT sLOT = slots[i];
				bool flag = player.Equals(sLOT.getPlayer());
				if (flag)
				{
					result = sLOT;
					return result;
				}
			}
			result = null;
			return result;
		}

		public bool setFigth(bool b)
		{
			return this._isInFight;
		}

		public Room(int roomId, int channelId)
		{
			this._roomId = roomId;
			for (int i = 0; i < this._slots.Length; i++)
			{
				this._slots[i] = new SLOT();
			}
			this._room_state = ROOM_STATE.ROOM_STATE_READY;
			this._channelId = channelId;
		}

		public void addDeaths(TeamEnum t)
		{
			this.addDeaths(t, 1);
		}

		public void addDeaths(TeamEnum t, int value)
		{
			if (t != TeamEnum.CHARACTER_TEAM_RED)
			{
				if (t == TeamEnum.CHARACTER_TEAM_BLUE)
				{
					this._blueDeaths += value;
				}
			}
			else
			{
				this._redDeaths += value;
			}
		}

		public void addKills(TeamEnum t)
		{
			this.addKills(t, 1);
		}

		public void addKills(TeamEnum t, int value)
		{
			if (t != TeamEnum.CHARACTER_TEAM_RED)
			{
				if (t == TeamEnum.CHARACTER_TEAM_BLUE)
				{
					this._blueKills += value;
				}
			}
			else
			{
				this._redKills += value;
			}
		}

		public int getKillsByMask()
		{
			bool flag = this.killtime >> 4 < 3;
			int result;
			if (flag)
			{
				result = Room.ROUNDS[this.killtime & 15];
			}
			else
			{
				result = Room.KILLS[this.killtime & 15];
			}
			return result;
		}

		public int getSlotBattle()
		{
			int num = 0;
			SLOT[] slots = this._slots;
			for (int i = 0; i < slots.Length; i++)
			{
				SLOT sLOT = slots[i];
				bool flag = sLOT.getPlayer().hasSlotState(SLOT_STATE.SLOT_STATE_BATTLE_READY);
				if (flag)
				{
					num |= 1 << sLOT.getId();
				}
			}
			return num;
		}

		public void getStartBattle(Room room)
		{
		}

		public void RoomTask(Room room)
		{
			int num = 0;
			foreach (Account current in room.getReadyPlayerList())
			{
				SLOT roomSlotByPlayer = room.getRoomSlotByPlayer(current);
				bool flag = roomSlotByPlayer.state > SLOT_STATE.SLOT_STATE_READY && roomSlotByPlayer.state < SLOT_STATE.SLOT_STATE_BATTLE_READY;
				if (flag)
				{
					num++;
				}
			}
			SLOT roomSlotByPlayer2 = room.getRoomSlotByPlayer(room.getLeader());
			bool flag2 = roomSlotByPlayer2.state < SLOT_STATE.SLOT_STATE_BATTLE;
			if (flag2)
			{
				bool flag3 = num == 0;
				if (flag3)
				{
					bool flag4 = roomSlotByPlayer2.state < SLOT_STATE.SLOT_STATE_BATTLE;
					if (flag4)
					{
						foreach (Account current2 in room.getReadyPlayerList())
						{
							SLOT roomSlotByPlayer3 = room.getRoomSlotByPlayer(current2);
							bool flag5 = roomSlotByPlayer3.state == SLOT_STATE.SLOT_STATE_BATTLE_READY;
							if (flag5)
							{
								roomSlotByPlayer3.setState(SLOT_STATE.SLOT_STATE_BATTLE);
								current2.getClient().sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(current2));
								foreach (Account current3 in room.getReadyPlayerList())
								{
									bool flag6 = !current3.Equals(current2);
									if (flag6)
									{
										SLOT roomSlotByPlayer4 = room.getRoomSlotByPlayer(current3);
										bool flag7 = roomSlotByPlayer4.state > SLOT_STATE.SLOT_STATE_PRESTART;
										if (flag7)
										{
											current2.getClient().sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(current3));
										}
									}
								}
								current2.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(room));
							}
						}
					}
				}
			}
			else
			{
				foreach (Account current4 in room.getReadyPlayerList())
				{
					SLOT roomSlotByPlayer5 = room.getRoomSlotByPlayer(current4);
					bool flag8 = roomSlotByPlayer5.state == SLOT_STATE.SLOT_STATE_BATTLE_READY;
					if (flag8)
					{
						current4.getClient().sendPacket(new PROTOCOL_BATTLE_AI_COLLISION_ACK(room));
						roomSlotByPlayer5.setState(SLOT_STATE.SLOT_STATE_BATTLE);
						current4.getClient().sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(current4));
						foreach (Account current5 in room.getReadyPlayerList())
						{
							SLOT sLOT = room._slots[current5.getSlot()];
							bool flag9 = sLOT.state == SLOT_STATE.SLOT_STATE_BATTLE && !current4.Equals(current5);
							if (flag9)
							{
								current5.getClient().sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(current4));
								current4.getClient().sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(current5));
							}
						}
						current4.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(room));
					}
				}
			}
			foreach (Account current6 in room.getReadyPlayerList())
			{
				current6.getClient().sendPacket(new PROTOCOL_ROOM_GET_SLOTINFO_ACK(room));
			}
			CLogger.getInstance().info("State= " + roomSlotByPlayer2.state);
		}

		public int addPlayer(Account player)
		{
			int player_id = player.player_id;
			int result;
			for (int i = 0; i < 16; i++)
			{
				bool flag = this._slots[i]._playerId == 0 && this._slots[i].state == SLOT_STATE.SLOT_STATE_EMPTY;
				if (flag)
				{
					this._slots[i].setId(i);
					this._slots[i]._playerId = player_id;
					this._slots[i].playername = player.getPlayerName();
					this._slots[i].state = SLOT_STATE.SLOT_STATE_NORMAL;
					this._slots[i].setPlayer(player);
					player.setRoom(this);
					player.setSlot(i);
					this.updateInfo();
					result = i;
					return result;
				}
			}
			result = -1;
			return result;
		}

		public void CalculateBattleResult(Account ac)
		{
			for (int i = 0; i < 16; i++)
			{
				Account playerBySlot = this.getPlayerBySlot(i);
				bool flag = playerBySlot != null;
				if (flag)
				{
					bool trainigExpEnable = Config.TrainigExpEnable;
					int num;
					int num2;
					if (trainigExpEnable)
					{
						num = playerBySlot.getRoom().getSlots()[playerBySlot.getSlot()].allKills * 25;
						num2 = playerBySlot.getRoom().getSlots()[playerBySlot.getSlot()].allKills * 50;
					}
					else
					{
						num = playerBySlot.getRoom().getSlots()[playerBySlot.getSlot()].allKills * 10;
						num2 = playerBySlot.getRoom().getSlots()[playerBySlot.getSlot()].allKills * 8;
					}
					this.updateFights(i, playerBySlot);
					playerBySlot.setExp(playerBySlot.getExp() + num2 + Config.BonusXP);
					playerBySlot.setGP(playerBySlot.getGP() + num);
					playerBySlot.setMoney(playerBySlot.getMoney() + 100);
					this.getSlot(i).gp = num;
					this.getSlot(i).exp = num2;
					playerBySlot._statistic.setHeadShotKilled(playerBySlot.getRoom().getSlot(playerBySlot.getSlot()).headshotsInPlay);
					for (int j = 0; j < playerBySlot.getRoom().getSlot(playerBySlot.getSlot()).headshotsInPlay; j++)
					{
						SLOT slot = playerBySlot.getRoom().getSlot(playerBySlot.getSlot());
						slot.allKills--;
					}
					playerBySlot._statistic.setKills(playerBySlot.getRoom().getSlot(playerBySlot.getSlot()).allKills);
					playerBySlot._statistic.setDeaths(playerBySlot.getRoom().getSlot(playerBySlot.getSlot()).allDeaths);
					int onNextLevel = RankExpInfoHolder.getRankExpInfo(playerBySlot.getRank())._onNextLevel;
					int onAllExp = RankExpInfoHolder.getRankExpInfo(playerBySlot.getRank())._onAllExp;
					int onGPUp = RankExpInfoHolder.getRankExpInfo(playerBySlot.getRank())._onGPUp;
					int itemid = RankExpInfoHolder.getRankExpInfo(playerBySlot.getRank())._itemid;
					bool flag2 = playerBySlot.getExp() >= onNextLevel && playerBySlot.getRank() < 50;
					if (flag2)
					{
						int exp = playerBySlot.getExp() - onNextLevel;
						playerBySlot.setExp(exp);
						playerBySlot.setRank(playerBySlot.getRank() + 1);
						playerBySlot.setGP(playerBySlot.getGP() + onGPUp);
						playerBySlot.sendPacket(new SM_PLAYER_UP_LEVEL(playerBySlot.getRank(), itemid));
						CLogger.getInstance().extra_info("[Player] " + playerBySlot.getPlayerName() + " up level");
					}
					AccountManager.getInstance().updatePlayer(playerBySlot);
				}
			}
			this.updateInfo();
		}

		public void ChangeRoomState(ROOM_STATE room, Account p)
		{
			bool flag = this.getState() == ROOM_STATE.ROOM_STATE_PRE_BATTLE;
			if (flag)
			{
				bool flag2 = p.player_id == this.getLeader().player_id;
				if (flag2)
				{
					this._timeRoom = ((this.GMTimeOut != -1) ? this.GMTimeOut : (this.getTimeByMask() * 60));
				}
				for (int i = 0; i < 16; i++)
				{
					Account playerBySlot = this.getPlayerBySlot(i);
					bool flag3 = this._slots[i].state == SLOT_STATE.SLOT_STATE_BATTLE_READY && this._slots[i]._playerId > 0 && playerBySlot != null;
					if (flag3)
					{
						this.changeSlotState(i, SLOT_STATE.SLOT_STATE_BATTLE, true);
						CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + playerBySlot.getPlayerName() + " pede o " + playerBySlot.getPlayerName());
						playerBySlot.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(playerBySlot));
						bool flag4 = p.player_id != playerBySlot.player_id;
						if (flag4)
						{
							CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + p.getPlayerName() + " pede o " + playerBySlot.player_name);
							playerBySlot.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(p));
							CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + playerBySlot.getPlayerName() + " pede o " + p.player_name);
							p.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(playerBySlot));
						}
						playerBySlot.sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this));
					}
				}
				this.setState(ROOM_STATE.ROOM_STATE_BATTLE);
				this.updateInfo();
			}
			else
			{
				bool flag5 = this.getState() == ROOM_STATE.ROOM_STATE_BATTLE && p.getRoom().getSlotState(p.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE_READY;
				if (flag5)
				{
					this.changeSlotState(p.getSlot(), SLOT_STATE.SLOT_STATE_BATTLE, true);
					CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + p.getPlayerName() + " pede o " + p.getPlayerName());
					p.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(p));
					for (int i = 0; i < 16; i++)
					{
						Account playerBySlot = this.getPlayerBySlot(i);
						bool flag6 = this._slots[i].state == SLOT_STATE.SLOT_STATE_BATTLE_READY && this._slots[i]._playerId > 0;
						if (flag6)
						{
							bool flag7 = p.player_id != playerBySlot.player_id;
							if (flag7)
							{
								CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + p.getPlayerName() + " pede o " + playerBySlot.player_name);
								playerBySlot.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(p));
							}
							CLogger.getInstance().info("Send: SM_BATTLE_STARTBATTLE | O jogador " + playerBySlot.getPlayerName() + " pede o " + p.player_name);
							p.sendPacket(new PROTOCOL_BATTLE_STARTBATTLE_ACK(playerBySlot));
						}
					}
					this.updateInfo();
					p.sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(this));
				}
			}
		}

		public void changeSlotState(int slot, SLOT_STATE state, bool sendinfo)
		{
			this._slots[slot].state = state;
			bool flag = state == SLOT_STATE.SLOT_STATE_EMPTY || state == SLOT_STATE.SLOT_STATE_CLOSE;
			if (flag)
			{
				this._slots[slot].allDeaths = 0;
				this._slots[slot].allKills = 0;
				this._slots[slot]._playerId = 0;
			}
			if (sendinfo)
			{
				this.updateInfo();
			}
		}

		public void changeSlotState2(int slot, SLOT_STATE state)
		{
			this._slots[slot].state = state;
			bool flag = state == SLOT_STATE.SLOT_STATE_EMPTY || state == SLOT_STATE.SLOT_STATE_CLOSE;
			if (flag)
			{
				this._slots[slot].allDeaths = 0;
				this._slots[slot].allKills = 0;
				this._slots[slot]._playerId = 0;
			}
		}

		public void CMDChangeMap(int map, Account acc)
		{
			this.map_id = map;
			bool flag = map != 18;
			if (flag)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Training Camp";
			bool flag2 = map != 47;
			if (flag2)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Dragon Alley";
			bool flag3 = map != 57;
			if (flag3)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Dragon Alley";
			bool flag4 = map != 7;
			if (flag4)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Angkor Ruins";
			bool flag5 = map != 60;
			if (flag5)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Ghost Town";
			bool flag6 = map != 61;
			if (flag6)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Grand Bazaar";
			bool flag7 = map != 62;
			if (flag7)
			{
				this.chat.playername = "[Server]";
			}
			this.chat.chat = "Mapa mudado para Dino Lab";
			CLogger.getInstance().extra_info("[Room] Map: " + map.ToString() + " | [Admin] " + acc.getPlayerName());
			this.SendRoomInfo();
		}

		public List<Account> getAllPlayers()
		{
			List<Account> list = new List<Account>();
			for (int i = 0; i < this._slots.Length; i++)
			{
				bool flag = this._slots[i]._playerId > 0;
				if (flag)
				{
					Account playerFromPlayerId = ChannelInfoHolder.getChannel(this._channelId).getPlayerFromPlayerId(this._slots[i]._playerId);
					list.Add(playerFromPlayerId);
				}
			}
			return list;
		}

		public int getBlueKills()
		{
			return this._blueKills;
		}

		public int getDeaths(TeamEnum t)
		{
			int result;
			if (t != TeamEnum.CHARACTER_TEAM_RED)
			{
				if (t != TeamEnum.CHARACTER_TEAM_BLUE)
				{
					result = 0;
				}
				else
				{
					result = this._blueDeaths;
				}
			}
			else
			{
				result = this._redDeaths;
			}
			return result;
		}

		public int getKills(TeamEnum t)
		{
			int result;
			if (t != TeamEnum.CHARACTER_TEAM_RED)
			{
				if (t != TeamEnum.CHARACTER_TEAM_BLUE)
				{
					result = 0;
				}
				else
				{
					result = this._blueKills;
				}
			}
			else
			{
				result = this._redKills;
			}
			return result;
		}

		public SLOT changeTeam(Account player, int team)
		{
			SLOT roomSlotByPlayer = this.getRoomSlotByPlayer(player);
			int[] array = (team == 0) ? this.RED_TEAM : this.BLUE_TEAM;
			SLOT result;
			for (int i = 0; i < array.Length; i++)
			{
				int num = array[i];
				SLOT sLOT = this._slots[num];
				bool flag = player.Equals(sLOT.getPlayer()) || sLOT.getState() == SLOT_STATE.SLOT_STATE_NORMAL;
				if (flag)
				{
					roomSlotByPlayer.setPlayer(null);
					roomSlotByPlayer.setState(SLOT_STATE.SLOT_STATE_NORMAL);
					sLOT.setPlayer(player);
					sLOT.setState(SLOT_STATE.SLOT_STATE_NORMAL);
					result = sLOT;
					return result;
				}
			}
			result = null;
			return result;
		}

		public Account getLeader()
		{
			bool flag = this.getAllPlayers().Count <= 0;
			Account result;
			if (flag)
			{
				result = null;
			}
			else
			{
				bool flag2 = this._leader == -1;
				if (flag2)
				{
					this.setNewLeader(-1);
				}
				result = ChannelInfoHolder.getChannel(this._channelId).getPlayerFromPlayerId(this.getSlot(this._leader)._playerId);
			}
			return result;
		}

		public Account getPlayerBySlot(int slot)
		{
			int playerId = this._slots[slot]._playerId;
			Account result;
			for (int i = 0; i < this.getAllPlayers().Count; i++)
			{
				bool flag = playerId == this.getAllPlayers()[i].player_id;
				if (flag)
				{
					result = this.getAllPlayers()[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Account> getPlayerInRoom(GameClient client)
		{
			List<Account> list = new List<Account>();
			for (int i = 0; i < 16; i++)
			{
				int playerId = this.getSlot(i)._playerId;
				bool flag = playerId > 0;
				if (flag)
				{
					Account playerFromPlayerId = ChannelInfoHolder.getChannel(client.getChannelId()).getPlayerFromPlayerId(playerId);
					list.Add(playerFromPlayerId);
				}
			}
			return list;
		}

		public int getRedKills()
		{
			return this._redKills;
		}

		public int getRoomId()
		{
			return this._roomId;
		}

		public SLOT getSlot(int id)
		{
			return this._slots[id];
		}

		public int getSlotCount()
		{
			int num = 0;
			for (int i = 0; i < this._slots.Length; i++)
			{
				bool flag = this._slots[i].state != SLOT_STATE.SLOT_STATE_CLOSE;
				if (flag)
				{
					num++;
				}
			}
			return num;
		}

		public SLOT getSlotPlayerId(int playerId)
		{
			SLOT result;
			for (int i = 0; i < 16; i++)
			{
				bool flag = this._slots[i]._playerId == playerId;
				if (flag)
				{
					result = this._slots[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		public SLOT[] getSlots()
		{
			return this._slots;
		}

		public SLOT_STATE getSlotState(int slot)
		{
			return this._slots[slot].state;
		}

		public ROOM_STATE getState()
		{
			return this._room_state;
		}

		public bool getStateBattle()
		{
			return this._room_state > ROOM_STATE.ROOM_STATE_READY;
		}

		public int getTimeByMask()
		{
			return Room.TIMES[this.killtime >> 4];
		}

		public int getTimeLost()
		{
			return this._timeRoom;
		}

		public void initSlotCount(int count)
		{
			bool flag = count == 0;
			if (flag)
			{
				count++;
			}
			for (int i = 0; i < this._slots.Length; i++)
			{
				bool flag2 = i >= count;
				if (flag2)
				{
					this._slots[i].state = SLOT_STATE.SLOT_STATE_CLOSE;
				}
			}
		}

		public int isBattleInt()
		{
			return (this._room_state > ROOM_STATE.ROOM_STATE_COUNTDOWN) ? 1 : 0;
		}

		public bool isInFight()
		{
			return this._isInFight;
		}

		public void removePlayer(Account player)
		{
			int player_id = player.player_id;
			bool flag = this != null;
			if (flag)
			{
				bool flag2 = this.getAllPlayers().Count > 1 && this.getLeader().player_id == player.player_id;
				if (flag2)
				{
					this.setNewLeader(-1);
				}
				int slot = player.getSlot();
				bool flag3 = this.getSlot(slot).state == SLOT_STATE.SLOT_STATE_BATTLE;
				if (flag3)
				{
					for (int i = 0; i < 16; i++)
					{
						bool flag4 = this.getSlot(i)._playerId > 0 && this.getSlot(i)._playerId != player.player_id;
						if (flag4)
						{
							this.getPlayerBySlot(i).sendPacket(new PROTOCOL_ROOM_CHANGE_SLOT_ACK(slot));
						}
					}
				}
				for (int i = 0; i < this._slots.Length; i++)
				{
					try
					{
						bool flag5 = this._slots[i]._playerId > 0 && this._slots[i]._playerId == player.player_id;
						if (flag5)
						{
							this._slots[i].playername = "";
							this._slots[i].botScore = 0;
							this._slots[i]._playerId = 0;
							this._slots[i].state = SLOT_STATE.SLOT_STATE_EMPTY;
							this._slots[i].setPlayer(null);
							player.setRoom(null);
							player.setSlot(-1);
							break;
						}
					}
					catch (Exception ex)
					{
						CLogger.getInstance().warning(ex.ToString());
					}
				}
				this.updateInfo();
			}
		}

		public void SendRoomInfo()
		{
			for (int i = 0; i < 16; i++)
			{
				Account playerBySlot = this.getPlayerBySlot(i);
				bool flag = playerBySlot != null;
				if (flag)
				{
					playerBySlot.sendPacket(new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(this));
				}
			}
		}

		public void setInFight(bool b)
		{
			this._isInFight = b;
		}

		public void setLeader(int slotId)
		{
			this._leader = slotId;
		}

		public void setNewLeader(int newLeader)
		{
			bool flag = newLeader == -1;
			if (flag)
			{
				for (int i = 0; i < 16; i++)
				{
					bool flag2 = this.getSlot(i)._playerId > 0;
					if (flag2)
					{
						this.setLeader(i);
					}
				}
			}
			else
			{
				this.setLeader(newLeader);
			}
			this.updateInfo();
		}

		public void setNewSlot(Account player, int team)
		{
			bool flag = team == 0;
			int[] array;
			if (flag)
			{
				array = new int[]
				{
					0,
					2,
					4,
					6,
					8,
					10,
					12,
					14
				};
			}
			else
			{
				array = new int[]
				{
					1,
					3,
					5,
					7,
					9,
					11,
					13,
					15
				};
			}
			int slot = player.getSlot();
			int num = slot % 2;
			bool flag2 = team != num;
			if (flag2)
			{
				int[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					int num2 = array2[i];
					bool flag3 = this._slots[num2]._playerId == 0 && this._slots[num2].state == SLOT_STATE.SLOT_STATE_EMPTY;
					if (flag3)
					{
						CLogger.getInstance().info("[Slot] " + player.getPlayerName() + " switching sides.");
						this.changeSlotState2(num2, SLOT_STATE.SLOT_STATE_NORMAL);
						this._slots[num2]._playerId = player.player_id;
						player.setSlot(num2);
						bool flag4 = slot == this._leader;
						if (flag4)
						{
							this._leader = num2;
						}
						break;
					}
				}
				this.changeSlotState2(slot, SLOT_STATE.SLOT_STATE_EMPTY);
				player.changeSlot = 1;
			}
		}

		public int setNewSlotHost(Account player, int slot, int oldSlot, int host_status)
		{
			CLogger.getInstance().info(string.Concat(new object[]
			{
				"[Slot] slot[",
				slot,
				"] state = ",
				this._slots[slot].state.ToString()
			}));
			SLOT_STATE state = this._slots[slot].state;
			this.changeSlotState2(slot, SLOT_STATE.SLOT_STATE_NORMAL);
			this._slots[slot]._playerId = player.player_id;
			player.setSlot(slot);
			this.changeSlotState2(oldSlot, state);
			bool flag = oldSlot == this._leader && host_status == 1;
			int result;
			if (flag)
			{
				this._leader = slot;
				result = 2;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		public void setState(ROOM_STATE _state)
		{
			this._room_state = _state;
		}

		public void setTimeLost(int time)
		{
			this._timeRoom = time;
		}

		public void stopBattle(Account p)
		{
			this.updateInfo();
		}

		public void stopBattle2(Account p)
		{
			bool flag = p.getSlot() == this._leader;
			if (flag)
			{
				for (int i = 0; i < 16; i++)
				{
					bool flag2 = this._slots[i].state == SLOT_STATE.SLOT_STATE_BATTLE || this._slots[i].state == SLOT_STATE.SLOT_STATE_PRESTART;
					if (flag2)
					{
						this.changeSlotState(i, SLOT_STATE.SLOT_STATE_NORMAL, true);
					}
					this._slots[i].allDeaths = 0;
					this._slots[i].allKills = 0;
					this._slots[i].killMessage = 0;
					this._slots[i].killsOnLife = 0;
					this._slots[i].lastKillState = 0;
					this._slots[i].repeatLastState = false;
					this._slots[i].botScore = 0;
					this._slots[i].headshotsInPlay = 0;
				}
				this._redKills = 0;
				this._redDeaths = 0;
				this._blueKills = 0;
				this._blueDeaths = 0;
				this._timeRoom = this.getTimeByMask() * 60;
				this.setState(ROOM_STATE.ROOM_STATE_READY);
			}
			this.updateInfo();
		}

		public void updateFights(int slot, Account p)
		{
			bool flag = slot % 2 == 0 && this.getRedKills() > this.getBlueKills();
			if (flag)
			{
				p._statistic.setFights(p._statistic.getFights_s() + 1);
				p._statistic.setWinFights(p._statistic.getWinFights_s() + 1);
			}
			else
			{
				bool flag2 = slot % 2 != 0 && this.getBlueKills() > this.getRedKills();
				if (flag2)
				{
					p._statistic.setFights(p._statistic.getFights_s() + 1);
					p._statistic.setWinFights(p._statistic.getWinFights_s() + 1);
				}
				else
				{
					bool flag3 = slot % 2 == 0 && this.getRedKills() < this.getBlueKills();
					if (flag3)
					{
						p._statistic.setFights(p._statistic.getFights_s() + 1);
						p._statistic.setLostFights(p._statistic.getLostFights_s() + 1);
					}
					else
					{
						bool flag4 = slot % 2 != 0 && this.getRedKills() > this.getBlueKills();
						if (flag4)
						{
							p._statistic.setFights(p._statistic.getFights_s() + 1);
							p._statistic.setLostFights(p._statistic.getLostFights_s() + 1);
						}
					}
				}
			}
			AccountManager.getInstance().updateFights(p._statistic.getFights_s(), p._statistic.getWinFights_s(), p._statistic.getLostFights_s(), p.getPlayerId());
		}

		public void updateInfo()
		{
			Account[] array = this.getAllPlayers().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Account account = array[i];
				try
				{
					account.sendPacket(new PROTOCOL_ROOM_GET_SLOTINFO_ACK(this));
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}
		}

		public void setRedKills(int kills)
		{
			this.redKills = kills;
		}

		public int getRedDeaths()
		{
			return this.redDeaths;
		}

		public void setRedDeaths(int deaths)
		{
			this.redDeaths = deaths;
		}

		public void setBlueKills(int kills)
		{
			this.blueKills = kills;
		}

		public int getBlueDeaths()
		{
			return this.blueDeaths;
		}

		public void setBlueDeaths(int deaths)
		{
			this.blueDeaths = deaths;
		}

		public int getAiCount()
		{
			return this.aiCount;
		}

		public void setAiCount(int aiCount)
		{
			this.aiCount = aiCount;
		}

		public int getAiLevel()
		{
			return this.aiLevel;
		}

		public void setAiLevel(int aiLevel)
		{
			this.aiLevel = aiLevel;
		}

		public int getBombState()
		{
			return this.bomb;
		}

		public void setBombState(int bomb)
		{
			this.bomb = bomb;
		}

		public int getRedWinRounds()
		{
			return this.redWinRounds;
		}

		public void setRedWinRounds(int redWinRounds)
		{
			this.redWinRounds = redWinRounds;
		}

		public int getBlueWinRounds()
		{
			return this.blueWinRounds;
		}

		public void setBlueWinRounds(int blueWinRounds)
		{
			this.blueWinRounds = blueWinRounds;
		}
	}
}
