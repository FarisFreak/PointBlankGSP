using PBServer.data;
using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace PBServer
{
	internal class GameClientManager
	{
		protected NetworkBlock _banned;

		private static GameClientManager _instance = new GameClientManager();

		private List<GameClient> _loggedClients = new List<GameClient>();

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
				GameClient item = new GameClient(client);
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

		public static GameClientManager getInstance()
		{
			return GameClientManager._instance;
		}

		public void removeClient(GameClient loginClient)
		{
			try
			{
				bool flag = this._loggedClients.Contains(loginClient);
				if (flag)
				{
					this._loggedClients.Remove(loginClient);
				}
			}
			catch (Exception ex)
			{
				CLogger.getInstance().warning(ex.ToString());
			}
		}
	}
}
