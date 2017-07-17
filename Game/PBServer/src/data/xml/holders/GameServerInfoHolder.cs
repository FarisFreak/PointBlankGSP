using PBServer.src.commons.data.holders;
using PBServer.src.data.model;
using System;
using System.Collections.Generic;

namespace PBServer.src.data.xml.holders
{
	internal class GameServerInfoHolder : IHolder
	{
		private static GameServerInfoHolder _instance;

		private static List<GameServerInfo> _servers = new List<GameServerInfo>();

		public void addGameServerInfo(GameServerInfo server)
		{
			GameServerInfoHolder._servers.Add(server);
		}

		public void clear()
		{
			GameServerInfoHolder._servers.Clear();
		}

		public List<GameServerInfo> getAllGameserverInfos()
		{
			return GameServerInfoHolder._servers;
		}

		public GameServerInfo getGameServerInfo(int id)
		{
			return GameServerInfoHolder._servers[id];
		}

		public static GameServerInfoHolder getInstance()
		{
			bool flag = GameServerInfoHolder._instance == null;
			if (flag)
			{
				GameServerInfoHolder._instance = new GameServerInfoHolder();
			}
			return GameServerInfoHolder._instance;
		}

		public void log()
		{
			CLogger.getInstance().info("[Server] Loaded: " + GameServerInfoHolder._servers.Count + " servers.");
		}
	}
}
