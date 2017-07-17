using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;

namespace PBServer.src.model
{
	public class Channel
	{
		private string _announce;

		private int _max_players;

		private List<int> _players;

		private List<Room> _rooms;

		private int _type;

		private int id;

		private string ip;

		private int port;

		private string server_name;

		public Channel(int id1, int type, string announce, int max_players, string server_name, string ip, int port)
		{
			this.id = id1;
			this._type = type;
			this._announce = announce;
			this._max_players = max_players;
			this._players = new List<int>();
			this._rooms = new List<Room>();
			this.server_name = server_name;
			this.ip = ip;
			this.port = port;
		}

		public void addPlayer(Account p)
		{
			for (int i = 0; i < this._players.Count; i++)
			{
				bool flag = p.player_id == this._players[i];
				if (flag)
				{
					return;
				}
			}
			CLogger.getInstance().info("[Channel] " + p.getPlayerName() + " It was added to the lobby.");
			this._players.Add(p.player_id);
		}

		public void addRoom(Room r)
		{
			this._rooms.Add(r);
		}

		public List<int> getAllPlayers()
		{
			return this._players;
		}

		public string getAnnounce()
		{
			return this._announce;
		}

		public int getAnnounceSize()
		{
			return this._announce.Length;
		}

		public int getId()
		{
			return this.id;
		}

		public string getIP()
		{
			return this.ip;
		}

		public int getMaxPlayers()
		{
			return this._max_players;
		}

		public Account getPlayerFromPlayerId(int playerId)
		{
			Account result;
			for (int i = 0; i < this._players.Count; i++)
			{
				bool flag = this._players[i] == playerId;
				if (flag)
				{
					result = AccountManager.getInstance().getAccountInObjectId(playerId);
					return result;
				}
			}
			result = null;
			return result;
		}

		public int getPort()
		{
			return this.port;
		}

		public Room getRoomInId(int id)
		{
			Room result;
			for (int i = 0; i < this._rooms.Count; i++)
			{
				bool flag = this._rooms[i].getRoomId() == id;
				if (flag)
				{
					result = this._rooms[i];
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Room> getRooms()
		{
			return this._rooms;
		}

		public string getServerName()
		{
			return this.server_name;
		}

		public int getTypeChannel()
		{
			return this._type;
		}

		public List<Account> getWaitPlayers()
		{
			List<Account> list = new List<Account>();
			for (int i = 0; i < this._players.Count; i++)
			{
				Account playerFromPlayerId = this.getPlayerFromPlayerId(this._players[i]);
				bool flag = playerFromPlayerId != null && playerFromPlayerId.getRoom() == null;
				if (flag)
				{
					list.Add(playerFromPlayerId);
				}
			}
			return list;
		}

		public void RemoveEmptyRooms()
		{
			for (int i = 0; i < this.getRooms().Count; i++)
			{
				Room room = this.getRooms()[i];
				bool flag = room.getAllPlayers().Count <= 0;
				if (flag)
				{
					this.removeRoom(room);
				}
			}
		}

		public void removePlayer(Account p)
		{
			for (int i = 0; i < this._players.Count; i++)
			{
				try
				{
					bool flag = p.player_id == this._players[i];
					if (flag)
					{
						Account playerFromPlayerId = this.getPlayerFromPlayerId(this._players[i]);
						CLogger.getInstance().warning(string.Concat(new object[]
						{
							"[Channel] ",
							playerFromPlayerId.getPlayerName(),
							" It was removed channel ",
							p.getClient().getChannelId()
						}));
						playerFromPlayerId.getClient().setChannelId(-1);
						this._players.Remove(p.player_id);
						break;
					}
				}
				catch (Exception ex)
				{
					CLogger.getInstance().warning(ex.ToString());
				}
			}
		}

		public void removeRoom(Room r)
		{
			for (int i = 0; i < this._rooms.Count; i++)
			{
				bool flag = r.getRoomId() == this._rooms[i].getRoomId();
				if (flag)
				{
					this._rooms.RemoveAt(i);
					break;
				}
			}
		}
	}
}
