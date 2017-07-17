using PBServer;
using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Threading;

namespace BattleServer
{
	internal class Program
	{
		protected static RoomsManager rs;

		protected static void BattleHandlerInit()
		{
			UdpClient udpClient = new UdpClient(59999);
			while (true)
			{
				Thread.Sleep(10);
				bool flag = udpClient.Available > 0;
				if (flag)
				{
					new BattleHandler(udpClient);
				}
			}
		}

		public static RoomsManager getRoomManager()
		{
			bool flag = Program.rs == null;
			if (flag)
			{
				Program.rs = new RoomsManager();
			}
			return Program.rs;
		}

		protected static void GSHandlerInit()
		{
			UdpClient udpClient = new UdpClient(60000);
			Console.Title = "PointBlank Server Battle";
            CLogger.getInstance().cyan("======================================================================");
            CLogger.getInstance().cyan("                           POINT BLANK BATTLE                         ");
            CLogger.getInstance().yellow("                         Client: ID, TH, TR, RU                       ");
            CLogger.getInstance().cyan("======================================================================");
			while (true)
			{
				Thread.Sleep(10);
				bool flag = udpClient.Available > 0;
				if (flag)
				{
					new GSHandler(udpClient);
				}
			}
		}

		protected static void Main(string[] args)
		{
			new Thread(new ThreadStart(Program.GSHandlerInit)).Start();
			new Thread(new ThreadStart(Program.BattleHandlerInit)).Start();
			Process.GetCurrentProcess().WaitForExit();
		}
	}
}
