using PBServer;
using PBServer.model.clans;
using PBServer.model.players;
using PBServer.src.managers;
using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.friends;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;
using System.Net;

namespace Model
{
	public class Player
	{
		private Clan _clan = null;

		public ConfigP _config;

		public LoginClient _connection;

		private PlayerInventory _inventory;

		private bool _isConnected = true;

		public Mission[] _mission;

		private bool _online = false;

		public int _rank;

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

		public int point;

		public int id;

		public int mao;

		public int mira;

		public int mission_id;

		public int cash;

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

		public void setRank(int rank)
		{
			this._rank = rank;
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

		public int getPoint()
		{
			return this.point;
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

		public int getMeleeWeapon()
		{
			return this.weapon_melee;
		}

		public int getMissionId()
		{
			return this.mission_id;
		}

		public int getCash()
		{
			return this.cash;
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

		public byte[] publicAdddress()
		{
			return IPAddress.Parse(this.addrEndPoint).GetAddressBytes();
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

		public void setPoint(int point)
		{
			this.point = point;
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

		public void setCash(int cash)
		{
			this.cash = cash;
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

		public void setRoom(Room r)
		{
			this._room = r;
		}
	}
}
