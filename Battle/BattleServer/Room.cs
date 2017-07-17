using PBServer;
using System;
using System.Collections.Generic;
using System.Net;

namespace BattleServer
{
	public class Room
	{
		public List<Player> _players = new List<Player>();

		public int id = -1;

		public int type = 2;

		public void AddPlayer(Player player)
		{
			for (int i = 0; i < this._players.Count; i++)
			{
				bool flag = this._players[i]._address == player._address;
				if (flag)
				{
					return;
				}
			}
			this._players.Add(player);
		}

		public Player getPlayer(IPAddress ip)
		{
			Player result;
			for (int i = 0; i < this._players.Count; i++)
			{
				bool flag = this._players[i]._address == ip;
				if (flag)
				{
					result = this._players[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Player> getPlayers()
		{
			return this._players;
		}

		public void RemovePlayer(Player p)
		{
			for (int i = 0; i < this._players.Count; i++)
			{
				bool flag = this._players[i]._address.ToString() == p._address.ToString();
				if (flag)
				{
					this._players.RemoveAt(i);
					CLogger.getInstance().info("Player As End PVP Battle Player ID");
				}
			}
		}
	}
}
