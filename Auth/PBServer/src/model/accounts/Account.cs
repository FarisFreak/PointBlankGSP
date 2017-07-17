using PBServer.model.clans;
using PBServer.model.players;
using PBServer.src.managers;
using PBServer.src.model.friends;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;
using System.Net;

namespace PBServer.src.model.accounts
{
	public class Account
	{
		private SLOT_STATE slotState;

		private Clan _clan = null;

		public ConfigP _config;

		public LoginClient _connection;

		private PlayerInventory _inventory;

		private bool _isConnected = true;

		public Mission[] _mission;

		private bool _online = false;

		public int _rank;

		public int _coupon;

		private Room _room;

		private int _slotId = -1;

		public PlayerStats _statistic = new PlayerStats();

		public int _status;

		private int _team = -1;

		public int access_level;

		private byte[] addr = new byte[4];

		private string addrEndPoint;

		public int audio_enable;

		public int audio1;

		public int audio2;

		public int blue_order;

		public int brooch;

		public int card_id;

		public int changeSlot = 1;

		public int char_beret;

		public int char_blue;

		public int char_dino;

		public int char_helmet;

		public int char_red;

		public int clan_id;

		public int config;

		public string cookie = null;

		public IPAddress customAddress = null;

		public int exp;

		public List<Friends> friends = new List<Friends>();

		public int gp;

		public int id;

		public int insignia;

		public int mao;

		public int medal;

		public int mira;

		public int mission_id;

		public int money;

		public string name;

		public int name_color;

		private int newSlot;

		public string password;

		public int pc_cafe;

		public int player_id;

		public string player_name = "";

		public int sangue;

		public int sensibilidade;

		public Title title;

		public int title_slot_count;

		public int visao;

		public int weapon_melee;

		public int weapon_primary;

		public int weapon_secondary;

		public int weapon_thrown_normal;

		public int weapon_thrown_special;

		public int MissionID;

		public int CardID;

		public int Card1_1;

		public int Card1_2;

		public int Card1_3;

		public int Card1_4;

		public int Card2_1;

		public int Card2_2;

		public int Card2_3;

		public int Card2_4;

		public int Card3_1;

		public int Card3_2;

		public int Card3_3;

		public int Card3_4;

		public int Card4_1;

		public int Card4_2;

		public int Card4_3;

		public int Card4_4;

		public int Card5_1;

		public int Card5_2;

		public int Card5_3;

		public int Card5_4;

		public int Card6_1;

		public int Card6_2;

		public int Card6_3;

		public int Card6_4;

		public int Card7_1;

		public int Card7_2;

		public int Card7_3;

		public int Card7_4;

		public int Card8_1;

		public int Card8_2;

		public int Card8_3;

		public int Card8_4;

		public int Card9_1;

		public int Card9_2;

		public int Card9_3;

		public int Card9_4;

		public int Card10_1;

		public int Card10_2;

		public int Card10_3;

		public int Card10_4;

		public int LastRewardEXP;

		public int LastRewardCredits;

		public int Id;

		public int Mission1;

		public int Mission2;

		public int Mission3;

		public int Mission4;

		public int EXP;

		public int Points;

		public int Item;

		public int Type1;

		public int Type2;

		public int Type3;

		public int Type4;

		public void setSlotState(SLOT_STATE state)
		{
			this.slotState = state;
		}

		public bool hasSlotState(SLOT_STATE state)
		{
			return this.slotState == state;
		}

		public void addFriend(Friends friend)
		{
			this.friends.Add(friend);
		}

		public void CheckCorrectInventory()
		{
			bool flag = this._inventory == null;
			if (flag)
			{
				this._inventory = new PlayerInventory(this.player_id);
			}
			this._inventory.CheckCorrectInventory(this.player_id);
		}

		public void close()
		{
			bool flag = this._connection != null;
			if (flag)
			{
				this._connection.close();
			}
		}

		public int getBlueOrder()
		{
			return this.blue_order;
		}

		public int getBrooch()
		{
			return this.brooch;
		}

		public int getCardId()
		{
			return this.card_id;
		}

		public int getCharBeret()
		{
			return this.char_beret;
		}

		public int getCharBlue()
		{
			return this.char_blue;
		}

		public int getCharDino()
		{
			return this.char_dino;
		}

		public int getCharHelmet()
		{
			return this.char_helmet;
		}

		public int getCharRed()
		{
			return this.char_red;
		}

		public Clan getClan()
		{
			return this._clan;
		}

		public int getClanId()
		{
			return this.clan_id;
		}

		public LoginClient getClient()
		{
			return this._connection;
		}

		public ConfigP getConfig()
		{
			return this._config;
		}

		public int getEquepItem(int slot)
		{
			return this._inventory.getEquipItemFromSlot(slot);
		}

		public int getExp()
		{
			return this.exp;
		}

		public int getGP()
		{
			return this.gp;
		}

		public int getInsignia()
		{
			return this.insignia;
		}

		public PlayerInventory getInventory()
		{
			return this._inventory;
		}

		public List<ItemsModel> getInvetoryOnly(int type)
		{
			return this._inventory.getAllItemsOnType(type);
		}

		public List<ItemsModel> getInvetoryOnlyEquip(int type)
		{
			return this._inventory.getAllItemsOnTypeEquip(type);
		}

		public byte[] getLocalAddress()
		{
			return this.addr;
		}

		public string getLogin()
		{
			return this.name;
		}

		public int getMedal()
		{
			return this.medal;
		}

		public int getMeleeWeapon()
		{
			return this.weapon_melee;
		}

		public int getMissionId()
		{
			return this.mission_id;
		}

		public int getMoney()
		{
			return this.money;
		}

		public int getNameColor()
		{
			return this.name_color;
		}

		public int getnewSlot()
		{
			return this.newSlot;
		}

		public bool getOnline()
		{
			return this._online;
		}

		public int getPcCafe()
		{
			return this.pc_cafe;
		}

		public int getPlayerId()
		{
			return this.player_id;
		}

		public string getPlayerName()
		{
			return this.player_name;
		}

		public int getPrimaryWeapon()
		{
			return this.weapon_primary;
		}

		public int getRank()
		{
			return this._rank;
		}

		public Room getRoom()
		{
			return this._room;
		}

		public int getSecondaryWeapon()
		{
			return this.weapon_secondary;
		}

		public int getSlot()
		{
			return this._slotId;
		}

		public int getTeam()
		{
			return this._team;
		}

		public int getThrownNormalWeapon()
		{
			return this.weapon_thrown_normal;
		}

		public int getThrownSpecialWeapon()
		{
			return this.weapon_thrown_special;
		}

		public int getTitleSlotCount()
		{
			return this.title_slot_count;
		}

		public bool isConnected()
		{
			return this._isConnected;
		}

		public bool isOnline()
		{
			return this._online;
		}

		public bool isRoomLeader()
		{
			return this._room.getLeader() == this;
		}

		public byte[] publicAdddress()
		{
			return IPAddress.Parse(this.addrEndPoint).GetAddressBytes();
		}

		public void sendPacket(SendBaseLoginPacket sp)
		{
			bool flag = this._connection != null;
			if (flag)
			{
				this._connection.sendPacket(sp);
			}
		}

		public void setCharBeret(int beret)
		{
			this.char_beret = beret;
		}

		public void setCharBlue(int character_blue)
		{
			this.char_blue = character_blue;
		}

		public void setCharDino(int character_dino)
		{
			this.char_dino = character_dino;
		}

		public void setCharHelmet(int helmet)
		{
			this.char_helmet = helmet;
		}

		public void setCharRed(int character_red)
		{
			this.char_red = character_red;
		}

		public void setClan(Clan clan)
		{
			this._clan = clan;
		}

		public void setClanId(int id)
		{
			this.clan_id = id;
		}

		public void setClient(LoginClient connection)
		{
			this._connection = connection;
		}

		public void setConnected(bool connected)
		{
			this._isConnected = connected;
		}

		public void setExp(int exp)
		{
			this.exp = exp;
		}

		public void setGP(int gp)
		{
			this.gp = gp;
		}

		public void setInventory(PlayerInventory pi)
		{
			this._inventory = pi;
		}

		public void setLocalAddress(byte[] address)
		{
			this.addr = address;
		}

		public void setMeleeWeapon(int melee)
		{
			this.weapon_melee = melee;
		}

		public void setMoney(int money1)
		{
			this.money = money1;
		}

		public void setNameColor(int color)
		{
			this.name_color = color;
		}

		public void setnewSlot(int slot)
		{
			bool flag = slot == 0 || slot == 2 || slot == 4 || slot == 6 || slot == 8 || slot == 10 || slot == 12 || slot == 14;
			if (flag)
			{
				this.newSlot = slot + 1;
			}
			else
			{
				this.newSlot = slot - 1;
			}
		}

		public void setOnlineStatus(bool isOnline)
		{
			this._online = isOnline;
		}

		public void setPcCafe(int pc_cafe)
		{
			this.pc_cafe = pc_cafe;
		}

		public void setPlayerId(int id)
		{
			this.player_id = id;
			this._inventory = new DaoManager(this._connection).getInventory(this.player_id);
			this._team = -1;
			this._mission = new Mission[3];
			bool flag = TitleManager.getInstance().getTitle(id) == null;
			if (flag)
			{
				TitleManager.getInstance().AddTitleDb(id);
				Title acc = new Title
				{
					owner_id = id
				};
				TitleManager.getInstance().AddTitle(acc);
				this.title = TitleManager.getInstance().getTitle(id);
			}
			else
			{
				this.title = TitleManager.getInstance().getTitle(id);
			}
			bool flag2 = ConfigManager.getInstance().getInfoItem(id) == null;
			if (flag2)
			{
				ConfigP configP = new ConfigP();
				configP.setOwnerId(id);
				configP.setOwnerName(this.player_name);
				configP.setMira(1);
				configP.setSensibilidade(50);
				configP.setSangue(1);
				configP.setVisao(70);
				configP.setAudio1(100);
				configP.setAudio2(100);
				configP.config = 55;
				ConfigManager.getInstance().AddConfig(configP);
				ConfigManager.getInstance().AddConfigDb(id, 100, 100, 50, 70, 1, 0, this.player_name, 0, 7, 55);
				this._config = ConfigManager.getInstance().getInfoItem(id);
				this.audio1 = this.getConfig().getAudio1();
				this.audio2 = this.getConfig().getAudio2();
				this.sensibilidade = this.getConfig().getSensibilidade();
				this.visao = this.getConfig().getVisao();
				this.mira = this.getConfig().getMira();
				this.mao = this.getConfig().getMao();
				this.sangue = this.getConfig().getSangue();
				this.audio_enable = this.getConfig().getAudioEnable();
				this.config = this.getConfig().config;
			}
			else
			{
				this._config = ConfigManager.getInstance().getInfoItem(id);
				this.audio1 = this.getConfig().getAudio1();
				this.audio2 = this.getConfig().getAudio2();
				this.sensibilidade = this.getConfig().getSensibilidade();
				this.visao = this.getConfig().getVisao();
				this.mira = this.getConfig().getMira();
				this.mao = this.getConfig().getMao();
				this.sangue = this.getConfig().getSangue();
				this.audio_enable = this.getConfig().getAudioEnable();
				this.config = this.getConfig().config;
			}
		}

		public void setPlayerName(string name)
		{
			this.player_name = name;
		}

		public void setPrimaryWeapon(int primary)
		{
			this.weapon_primary = primary;
		}

		public void setPublicAddress(string address)
		{
			this.addrEndPoint = address;
		}

		public void setRank(int rank)
		{
			this._rank = rank;
		}

		public void setRoom(Room r)
		{
			this._room = r;
		}

		public int getCard1_1()
		{
			return this.Card1_1;
		}

		public int getCard1_2()
		{
			return this.Card1_2;
		}

		public int getCard1_3()
		{
			return this.Card1_3;
		}

		public int getCard1_4()
		{
			return this.Card1_4;
		}

		public int getCard2_1()
		{
			return this.Card2_1;
		}

		public int getCard2_2()
		{
			return this.Card2_2;
		}

		public int getCard2_3()
		{
			return this.Card2_3;
		}

		public int getCard2_4()
		{
			return this.Card2_4;
		}

		public int getCard3_1()
		{
			return this.Card3_1;
		}

		public int getCard3_2()
		{
			return this.Card3_2;
		}

		public int getCard3_3()
		{
			return this.Card3_3;
		}

		public int getCard3_4()
		{
			return this.Card3_4;
		}

		public int getCard4_1()
		{
			return this.Card4_1;
		}

		public int getCard4_2()
		{
			return this.Card4_2;
		}

		public int getCard4_3()
		{
			return this.Card4_3;
		}

		public int getCard4_4()
		{
			return this.Card4_4;
		}

		public int getCard5_1()
		{
			return this.Card5_1;
		}

		public int getCard5_2()
		{
			return this.Card5_2;
		}

		public int getCard5_3()
		{
			return this.Card5_3;
		}

		public int getCard5_4()
		{
			return this.Card5_4;
		}

		public int getCard6_1()
		{
			return this.Card6_1;
		}

		public int getCard6_2()
		{
			return this.Card6_2;
		}

		public int getCard6_3()
		{
			return this.Card6_3;
		}

		public int getCard6_4()
		{
			return this.Card6_4;
		}

		public int getCard7_1()
		{
			return this.Card7_1;
		}

		public int getCard7_2()
		{
			return this.Card7_2;
		}

		public int getCard7_3()
		{
			return this.Card7_3;
		}

		public int getCard7_4()
		{
			return this.Card7_4;
		}

		public int getCard8_1()
		{
			return this.Card8_1;
		}

		public int getCard8_2()
		{
			return this.Card8_2;
		}

		public int getCard8_3()
		{
			return this.Card8_3;
		}

		public int getCard8_4()
		{
			return this.Card8_4;
		}

		public int getCard9_1()
		{
			return this.Card9_1;
		}

		public int getCard9_2()
		{
			return this.Card9_2;
		}

		public int getCard9_3()
		{
			return this.Card9_3;
		}

		public int getCard9_4()
		{
			return this.Card9_4;
		}

		public int getCard10_1()
		{
			return this.Card10_1;
		}

		public int getCard10_2()
		{
			return this.Card10_2;
		}

		public int getCard10_3()
		{
			return this.Card10_3;
		}

		public int getCard10_4()
		{
			return this.Card10_4;
		}

		public int getMissionID()
		{
			return this.MissionID;
		}

		public int getCardID()
		{
			return this.CardID;
		}

		public int getId()
		{
			return this.Id;
		}

		public int getMission1()
		{
			return this.Mission1;
		}

		public int getMission1_Type()
		{
			return this.Type1;
		}

		public int getMission2()
		{
			return this.Mission2;
		}

		public int getMission2_Type()
		{
			return this.Type2;
		}

		public int getMission3()
		{
			return this.Mission3;
		}

		public int getMission3_Type()
		{
			return this.Type3;
		}

		public int getMission4()
		{
			return this.Mission4;
		}

		public int getMission4_Type()
		{
			return this.Type4;
		}

		public int getEXP()
		{
			return this.EXP;
		}

		public int getPoints()
		{
			return this.Points;
		}

		public int getItem()
		{
			return this.Item;
		}

		public int getLastRewardEXP()
		{
			return this.LastRewardEXP;
		}

		public int getLastRewardCredits()
		{
			return this.LastRewardCredits;
		}

		public void setSecondaryWeapon(int secondary)
		{
			this.weapon_secondary = secondary;
		}

		public void setSlot(int slotId)
		{
			this._slotId = slotId;
		}

		public void setStatus(int status)
		{
			this._status = status;
		}

		public void setTeam(int team)
		{
			this._team = team;
		}

		public void setThrownNormalWeapon(int thrown_normal)
		{
			this.weapon_thrown_normal = thrown_normal;
		}

		public void setThrownSpecialWeapon(int thrown_special)
		{
			this.weapon_thrown_special = thrown_special;
		}

		public void setTitleSlotCount(int title_count)
		{
			this.title_slot_count = title_count;
		}

		public string toString()
		{
			return this.ToString();
		}

		public bool validatePassword(string p)
		{
			return p == this.password;
		}
	}
}
