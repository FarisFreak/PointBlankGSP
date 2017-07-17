using PBServer.src.model;
using System;
using System.Collections.Generic;

namespace PBServer.src.data.xml.holders
{
	public class ChannelInfoHolder
	{
		private static List<Channel> _channels = new List<Channel>();

		private static ChannelInfoHolder _instance;

		private static List<Channel> _servers = new List<Channel>();

		internal void addChannelInfo(Channel gsi)
		{
			ChannelInfoHolder._servers.Add(gsi);
		}

		public void clear()
		{
			ChannelInfoHolder._servers.Clear();
		}

		public List<Channel> getAllChannelInfos()
		{
			return ChannelInfoHolder._servers;
		}

		public static List<Channel> getAllChannels()
		{
			return ChannelInfoHolder._channels;
		}

		public static Channel getChannel(int channelId)
		{
			bool flag = channelId > -1;
			Channel result;
			if (flag)
			{
				result = ChannelInfoHolder._servers[channelId];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public static ChannelInfoHolder getInstance()
		{
			bool flag = ChannelInfoHolder._instance == null;
			if (flag)
			{
				ChannelInfoHolder._instance = new ChannelInfoHolder();
			}
			return ChannelInfoHolder._instance;
		}

		internal void log()
		{
			CLogger.getInstance().info("[Channel] Loaded: " + ChannelInfoHolder._servers.Count + " channels.");
		}
	}
}
