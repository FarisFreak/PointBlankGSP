using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PBServer
{
	internal class NetworkLogin
	{
		private static TcpListener _clientLoginListener;

		private static NetworkLogin _instance;

		public NetworkLogin()
		{
			new Thread(new ThreadStart(this.NetworkStart)).Start();
		}

		private static void accept(TcpClient client)
		{
			LoginClientManager.getInstance().addClient(client);
		}

		private void BeginAcceptTcpClient(IAsyncResult result)
		{
			NetworkLogin.accept(NetworkLogin._clientLoginListener.EndAcceptTcpClient(result));
			NetworkLogin._clientLoginListener.BeginAcceptTcpClient(new AsyncCallback(this.BeginAcceptTcpClient), null);
		}

		public static NetworkLogin getInstance()
		{
			bool flag = NetworkLogin._instance == null;
			if (flag)
			{
				NetworkLogin._instance = new NetworkLogin();
			}
			return NetworkLogin._instance;
		}

		public void NetworkStart()
		{
			try
			{
				NetworkLogin._clientLoginListener = new TcpListener(IPAddress.Parse(Config.LOGIN_HOST), Config.LOGIN_PORT);
				NetworkLogin._clientLoginListener.Start();
				CLogger.getInstance().info(string.Concat(new object[]
				{
					"[Network] Login Server IP: ",
					((IPEndPoint)NetworkLogin._clientLoginListener.LocalEndpoint).Address,
					":",
					Config.LOGIN_PORT
				}));
				NetworkLogin._clientLoginListener.BeginAcceptTcpClient(new AsyncCallback(this.BeginAcceptTcpClient), null);
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error(ex.ToString());
			}
		}
	}
}
