using PBServer.model.players;
using System;
using System.Collections.Generic;

namespace Managers.Active
{
	public class DAOM
	{
		private static DAOM clm = new DAOM();

		public List<ItemsModel> items = new List<ItemsModel>();

		public ItemsModel getItem(int object_id)
		{
			ItemsModel item = new ItemsModel
			{
				id = object_id
			};
			this.items.Add(item);
			return null;
		}

		public static DAOM getInstance()
		{
			return DAOM.clm;
		}
	}
}
