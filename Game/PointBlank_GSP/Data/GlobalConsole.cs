using PBServer;
using System;

namespace PointBlank_GSP.Data
{
	internal class GlobalConsole
	{
		private static GlobalConsole dbdt = new GlobalConsole();

		public static void Load()
		{
            CLogger.getInstance().cyan("======================================================================");
            CLogger.getInstance().cyan("                            POINT BLANK GAME                          ");
            CLogger.getInstance().yellow("                         Client: ID, TH, TR, RU                      ");
            CLogger.getInstance().cyan("======================================================================");
        }

		public static GlobalConsole getInstance()
		{
			return GlobalConsole.dbdt;
		}
	}
}
