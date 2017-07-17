using PBServer;
using System;
using System.Collections.Generic;
using System.Net;

namespace BattleServer
{
	public class RoomsManager
	{
		public static RoomsManager _instance;

		public List<Room> _list = new List<Room>();

		public int getCountPlayer(IPAddress ip)
		{
			int result;
			for (int i = 0; i < this._list.Count; i++)
			{
				for (int j = 0; j < this._list[i]._players.Count; j++)
				{
					bool flag = this._list[i]._players[j]._address.ToString() == ip.ToString();
					if (flag)
					{
						result = this._list[i].getPlayers().Count;
						return result;
					}
				}
			}
			result = 0;
			return result;
		}

		public static RoomsManager getInstance()
		{
			bool flag = RoomsManager._instance == null;
			if (flag)
			{
				RoomsManager._instance = new RoomsManager();
			}
			return RoomsManager._instance;
		}

		public Player getPlayer(IPAddress ip)
		{
			Player result;
			for (int i = 0; i < this._list.Count; i++)
			{
				for (int j = 0; j < this._list[i]._players.Count; j++)
				{
					bool flag = this._list[i]._players[j]._address.ToString() == ip.ToString();
					if (flag)
					{
						result = this._list[i].getPlayers()[j];
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		public Player getPlayer(IPAddress host, int player)
		{
			Player result;
			for (int i = 0; i < this._list.Count; i++)
			{
				bool flag = this._list[i] != null && this._list[i]._players[player] != null && this._list[i]._players[player]._address.ToString() == host.ToString();
				if (flag)
				{
					result = this._list[i].getPlayers()[player];
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Player> getPlayersINRoom(IPAddress address)
		{
			List<Player> result;
			for (int i = 0; i < this._list.Count; i++)
			{
				for (int j = 0; j < this._list[i]._players.Count; j++)
				{
					bool flag = this._list[i]._players[j]._address.ToString() == address.ToString();
					if (flag)
					{
						result = this._list[i]._players;
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		public Room getRoom(IPAddress ip)
		{
			Room result;
			for (int i = 0; i < this._list.Count; i++)
			{
				for (int j = 0; j < this._list[i]._players.Count; j++)
				{
					bool flag = this._list[i]._players[j]._address.ToString() == ip.ToString();
					if (flag)
					{
						result = this._list[i];
						return result;
					}
				}
			}
			result = null;
			return result;
		}

		public List<Room> getRooms()
		{
			return this._list;
		}

		public void RemovePlayerInRoom(IPAddress ip)
		{
			for (int i = 0; i < this._list.Count; i++)
			{
				for (int j = 0; j < this._list[i]._players.Count; j++)
				{
					bool flag = this._list[i]._players[j]._address.ToString() == ip.ToString();
					if (flag)
					{
						this._list[i].RemovePlayer(this._list[i]._players[j]);
					}
				}
				bool flag2 = this._list[i]._players.Count == 0;
				if (flag2)
				{
					CLogger.getInstance().info("[RemovePlayerInRoom]: Remove room >>>");
					this._list.RemoveAt(i);
					CLogger.getInstance().info("[RemovePlayerInRoom]: Remove room <<<");
				}
			}
		}
	}
}
