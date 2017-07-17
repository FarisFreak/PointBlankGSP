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
			GameClientManager.getInstance();
			ChannelInfoParser.getInstance();
			PlayerTemplateParser.getInstance();
			GameServerInfoParser.getInstance();
			StartedInventoryItemsParser.getInstance();
			RankExpInfoParser.getInstance();
			StartedInventoryItemsHolder.getInstance();
			TutorialParser.Load();
			ChannelInfoHolder.getInstance();
			PlayerTemplateHolder.getInstance();
			RankExpInfoHolder.getInstance();
		}

		public static GlobalDate getInstance()
		{
			return GlobalDate.dbdt;
		}
	}
}
