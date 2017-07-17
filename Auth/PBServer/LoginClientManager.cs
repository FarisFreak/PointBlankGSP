using PBServer.data;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace PBServer
{
	internal class LoginClientManager
	{
		protected NetworkBlock _banned;

		private static LoginClientManager _instance = new LoginClientManager();

		private List<LoginClient> _loggedClients = new List<LoginClient>();

		private SortedList<string, LoginClient> _waitingAcc = new SortedList<string, LoginClient>();

		public void addClient(TcpClient client)
		{
			bool flag = this._banned == null;
			if (flag)
			{
				this._banned = NetworkBlock.getInstance();
			}
			string text = client.Client.RemoteEndPoint.ToString().Split(new char[]
			{
				':'
			})[0];
			bool flag2 = !this._banned.allowed(text);
			if (flag2)
			{
				client.Close();
				CLogger.getInstance().error("NetworkBlock: connection attemp failed. " + text + " banned.");
			}
			else
			{
				LoginClient item = new LoginClient(client);
				bool flag3 = this._loggedClients.Contains(item);
				if (flag3)
				{
					CLogger.getInstance().info("Client is Have");
				}
				else
				{
					this._loggedClients.Add(item);
				}
			}
		}

		public static LoginClientManager getInstance()
		{
			return LoginClientManager._instance;
		}

		public void removeClient(LoginClient loginClient)
		{
			bool flag = this._loggedClients.Contains(loginClient);
			if (flag)
			{
				this._loggedClients.Remove(loginClient);
			}
		}
	}
}
