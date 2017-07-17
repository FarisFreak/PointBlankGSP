using System;

namespace Model
{
	public class Medal
	{
		public int player_id = 0;

		public int brooch;

		public int blue_order;

		public string name;

		public int insignia;

		public int medal;

		public int getBlueOrder()
		{
			return this.blue_order;
		}

		public int getBrooch()
		{
			return this.brooch;
		}

		public int getInsignia()
		{
			return this.insignia;
		}

		public int getMedal()
		{
			return this.medal;
		}
	}
}
