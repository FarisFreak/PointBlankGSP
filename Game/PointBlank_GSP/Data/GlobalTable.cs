using PBServer.db;
using PBServer.managers;
using PBServer.src.managers;
using System;

namespace PointBlank_GSP.Data
{
	internal class GlobalTable
	{
		private static GlobalTable dbdt = new GlobalTable();

		public static void Load()
		{
			SQLjec.getInstance();
			AccountManager.getInstance();
			ClanManager.getInstance();
			ConfigManager.getInstance();
			FriendManager.getInstance();
			MessageManager.getInstance();
			MissionManager.getInstance();
			ShopInfoManager.getInstance();
			TitleManager.getInstance();
		}

		public static GlobalTable getInstance()
		{
			return GlobalTable.dbdt;
		}
	}
}
