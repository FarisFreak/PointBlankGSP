using System;

namespace PBServer.model.players
{
	public class ItemsModel
	{
		public int count;

		public int equip;

		public int equip_type;

		public int id;

		public string name;

		public int object_id;

		public int slot;

		public ItemsModel()
		{
		}

		public ItemsModel(int _id, int _slot, string name, int _equip, int count, int _equip_type, int ob_id)
		{
			this.object_id = ob_id;
			this.id = _id;
			this.name = name;
			this.count = count;
			this.slot = _slot;
			this.equip = _equip;
			this.equip_type = _equip_type;
		}
	}
}
