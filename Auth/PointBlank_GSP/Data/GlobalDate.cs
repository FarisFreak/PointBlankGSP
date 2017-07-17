using Data.xml.parsers;
using PBServer;
using PBServer.data.xml.holders;
using PBServer.data.xml.parsers;
using PBServer.src.data.xml.holders;
using PBServer.src.data.xml.parsers;
using System;

namespace PointBlank_GSP.Data
{
	internal class GlobalDate
	{
		private static GlobalDate dbdt = new GlobalDate();

		public static void Load()
		{
			LoginClientManager.getInstance();
			PlayerTemplateParser.getInstance();
			GameServerInfoParser.getInstance();
			StartedInventoryItemsParser.getInstance();
			RankExpInfoParser.getInstance();
			StartedInventoryItemsHolder.getInstance();
			TutorialParser.Load();
			PlayerTemplateHolder.getInstance();
			GameServerInfoHolder.getInstance();
			RankExpInfoHolder.getInstance();
		}

		public static GlobalDate getInstance()
		{
			return GlobalDate.dbdt;
		}
	}
}
