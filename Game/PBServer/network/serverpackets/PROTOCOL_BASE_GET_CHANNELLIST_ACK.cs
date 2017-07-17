using PBServer.src.data.xml.holders;
using PBServer.src.model;
using System;
using System.Collections.Generic;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BASE_GET_CHANNELLIST_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BASE_GET_CHANNELLIST_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2572);
			List<Channel> allChannels = ChannelInfoHolder.getAllChannels();
			base.writeD(allChannels.Count);
			base.writeD(300);
			foreach (Channel current in allChannels)
			{
				base.writeD(current.getAllPlayers().Count);
			}
		}
	}
}
