using System;
using System.Collections.Generic;

namespace PBServer.data.model
{
	public class PlayerTemplate
	{
		public int _exp;

		public int _gp;

		public int _id;

		public int _money;

		public int _rank;

		public List<PlayerTemplateInventory> _startInventory;

		public PlayerTemplate(int id, int rank, int exp, int gp, List<PlayerTemplateInventory> inventory)
		{
			this._id = id;
			this._rank = rank;
			this._exp = exp;
			this._gp = gp;
			this._startInventory = inventory;
		}
	}
}
