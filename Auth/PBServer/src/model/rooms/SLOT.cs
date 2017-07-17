using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.src.model.rooms
{
	public class SLOT
	{
		public int _playerId;

		public int allDeaths;

		public int botScore;

		public int exp;

		public int gp;

		public int headshotsInPlay;

		private int oneTimeKills;

		private int id;

		public List<Inventory> itens_utilizados = new List<Inventory>();

		public int killMessage;

		public int allKills;

		private int lastKillMessage;

		public int killsOnLife;

		public int lastKillState;

		private Account player;

		public string playername;

		public bool repeatLastState;

		public SLOT_STATE state = SLOT_STATE.SLOT_STATE_EMPTY;

		public SLOT_STATE getState()
		{
			return this.state;
		}

		public int getId()
		{
			return this.id;
		}

		public Account getPlayer()
		{
			return this.player;
		}

		public void resetkillsOnLife()
		{
			this.killsOnLife = 0;
		}

		public void setId(int id)
		{
			this.id = id;
		}

		public void setPlayer(Account player)
		{
			this.player = player;
		}

		public void setLastKillMessage(int message)
		{
			this.lastKillMessage = message;
		}

		public void setState(SLOT_STATE _state)
		{
			this.state = _state;
		}

		public int getLastKillMessage()
		{
			return this.lastKillMessage;
		}

		public int getKillMessage()
		{
			return this.killMessage;
		}

		public void setKillMessage(int message)
		{
			this.killMessage = message;
		}

		public void setAllDeahts(int death)
		{
			this.allDeaths = death;
		}

		public int getAllDeath()
		{
			return this.allDeaths;
		}

		public void setBotScore(int score)
		{
			this.botScore = score;
		}

		public int getBotScore()
		{
			return this.botScore;
		}

		public void setAllKills(int kills)
		{
			this.allKills = kills;
		}

		public int getAllKills()
		{
			return this.allKills;
		}

		public void setOneTimeKills(int kills)
		{
			this.oneTimeKills = kills;
		}

		public int getOneTimeKills()
		{
			return this.oneTimeKills;
		}
	}
}
