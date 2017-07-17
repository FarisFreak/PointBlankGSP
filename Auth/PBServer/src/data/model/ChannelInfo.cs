using System;

namespace PBServer.src.data.model
{
	internal class ChannelInfo
	{
		public int _id;

		private int _maxPlayers;

		public string _name;

		public int _type;

		public ChannelInfo(string name, int id, int type, int max_players)
		{
			this._name = name;
			this._id = id;
			this._type = type;
			this._maxPlayers = max_players;
		}

		public int getMaxPlayers()
		{
			return this._maxPlayers;
		}

		public void setMaxPlayers(int maxPlayers)
		{
			this._maxPlayers = maxPlayers;
		}
	}
}
