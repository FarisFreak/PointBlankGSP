using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;

namespace PBServer.managers
{
	public class StorageManager
	{
		private static StorageManager _instance;

		private List<Channel> channels = new List<Channel>(10);

		public StorageManager()
		{
			CLogger.getInstance().info("[Storage] Loaded.");
		}

		public void AddPlayerInChannel(int channel, Account p)
		{
			this.channels[channel].addPlayer(p);
		}

		public static StorageManager getInstance()
		{
			bool flag = StorageManager._instance == null;
			if (flag)
			{
				StorageManager._instance = new StorageManager();
			}
			return StorageManager._instance;
		}

		public List<int> getPlayers(int channel)
		{
			return this.channels[channel].getAllPlayers();
		}

		public Room getRoom(int channel, int id)
		{
			return this.channels[channel].getRooms()[id];
		}

		public List<Room> getRooms(int channel)
		{
			return this.channels[channel].getRooms();
		}
	}
}
