using PBServer;
using System;

namespace PointBlank_GSP.Data
{
	internal class GlobalNetwork
	{
		private static GlobalNetwork dbdt = new GlobalNetwork();

		public static void Load()
		{
			NetworkLogin.getInstance();
		}

		public static GlobalNetwork getInstance()
		{
			return GlobalNetwork.dbdt;
		}
	}
}
