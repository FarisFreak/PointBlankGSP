using System;

namespace PBServer.src.data.model
{
	internal class GameServerInfo
	{
		public int _id;

		public string _ip;

		public bool _isAuthed;

		private bool _isOnline;

		private int _maxPlayers;

		public string _name;

		public string _pass;

		public int _type;

		public int port;

		public GameServerInfo(string name, int id, string pass, int type, int max_players, string ip, int port)
		{
			this._name = name;
			this._id = id;
			this._pass = pass;
			this._type = type;
			this._maxPlayers = max_players;
			this._ip = ip;
			this.port = port;
		}

		public string getIP()
		{
			return this._ip;
		}

		public int getMaxPlayers()
		{
			return this._maxPlayers;
		}

		public string getPassword()
		{
			return this._pass;
		}

		public int getPort()
		{
			return this.port;
		}

		public string getServerName()
		{
			return this._name;
		}

		public int getTypeGameServer()
		{
			return this._type;
		}

		public bool isAuthed()
		{
			return this._isAuthed;
		}

		public bool isOnline()
		{
			return this._isOnline;
		}

		public void setAuthed(bool isAuthed)
		{
			this._isAuthed = isAuthed;
		}

		public void setMaxPlayers(int maxPlayers)
		{
			this._maxPlayers = maxPlayers;
		}

		public void setOnline(bool online)
		{
			this._isOnline = online;
		}
	}
}
