using System;

namespace PointBlank_GSP.Data
{
	internal class Global
	{
		private static GlobalConsole dbdt = new GlobalConsole();

		public static void Load()
		{
		}

		public static GlobalConsole getInstance()
		{
			return Global.dbdt;
		}
	}
}
