using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PBServer
{
	internal class NetworkGame
	{
		private static TcpListener _clientGameListener;

		private static NetworkGame _instance;

		public NetworkGame()
		{
			new Thread(new ThreadStart(this.NetworkStart)).Start();
		}

		private static void accept(TcpClient client)
		{
			GameClientManager.getInstance().addClient(client);
		}

		private void BeginAcceptTcpClient(IAsyncResult result)
		{
			NetworkGame.accept(NetworkGame._clientGameListener.EndAcceptTcpClient(result));
			NetworkGame._clientGameListener.BeginAcceptTcpClient(new AsyncCallback(this.BeginAcceptTcpClient), null);
		}

		public static NetworkGame getInstance()
		{
			bool flag = NetworkGame._instance == null;
			if (flag)
			{
				NetworkGame._instance = new NetworkGame();
			}
			return NetworkGame._instance;
		}

		public void NetworkStart()
		{
			try
			{
				NetworkGame._clientGameListener = new TcpListener(IPAddress.Parse(Config.GAME_HOST), Config.GAME_PORT);
				NetworkGame._clientGameListener.Start();
				CLogger.getInstance().info("[Network] Game Server IP: " + NetworkGame._clientGameListener.LocalEndpoint.ToString());
				NetworkGame._clientGameListener.BeginAcceptTcpClient(new AsyncCallback(this.BeginAcceptTcpClient), null);
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error(ex.ToString());
			}
		}
	}
}
