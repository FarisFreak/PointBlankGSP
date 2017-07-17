using System;

namespace PBServer.model.players
{
	public class PlayerStats
	{
		private int _deaths_count_s = 0;

		private int _escape_s = 0;

		private int _fights_lost_s = 0;

		private int _fights_s = 0;

		private int _fights_win_s = 0;

		private int _headshots_count_s = 0;

		private int _kills_count_s = 0;

		public int getDeaths_s()
		{
			return this._deaths_count_s;
		}

		public int getEscapes_s()
		{
			return this._escape_s;
		}

		public int getFights_s()
		{
			return this._fights_s;
		}

		public int getHeadShotKills()
		{
			return this._headshots_count_s;
		}

		public int getKills_s()
		{
			return this._kills_count_s;
		}

		public int getLostFights_s()
		{
			return this._fights_lost_s;
		}

		public int getWinFights_s()
		{
			return this._fights_win_s;
		}

		public void setDeaths(int val)
		{
			this._deaths_count_s += val;
		}

		public void setEscapes(int val)
		{
			this._escape_s = val;
		}

		public void setFights(int val)
		{
			this._fights_s = val;
		}

		public void setHeadShotKilled(int val)
		{
			this._headshots_count_s += val;
		}

		public void setKills(int val)
		{
			this._kills_count_s += val;
		}

		public void setLostFights(int val)
		{
			this._fights_lost_s = val;
		}

		public void setWinFights(int val)
		{
			this._fights_win_s = val;
		}
	}
}
