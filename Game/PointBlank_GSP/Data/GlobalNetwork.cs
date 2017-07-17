using PBServer;
using PBServer.network.BattleConnect;
using System;

namespace PointBlank_GSP.Data
{
	internal class GlobalNetwork
	{
		private static GlobalNetwork dbdt = new GlobalNetwork();

		public static void Load()
		{
			NetworkGame.getInstance();
			UdpHandler.getInstance().SendPacket(255, new byte[4]);
		}

		public static GlobalNetwork getInstance()
		{
			return GlobalNetwork.dbdt;
		}
	}
}
