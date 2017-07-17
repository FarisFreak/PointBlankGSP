using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_GET_ROOMLIST_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_LOBBY_GET_ROOMLIST_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
				channel.RemoveEmptyRooms();
				base.getClient().sendPacket(new PROTOCOL_LOBBY_GET_ROOMLIST_ACK(channel));
			}
		}
	}
}
