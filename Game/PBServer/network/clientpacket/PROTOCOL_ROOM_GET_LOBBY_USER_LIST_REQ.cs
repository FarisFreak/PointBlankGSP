using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_ROOM_GET_LOBBY_USER_LIST_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
				player.sendPacket(new PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK(channel));
			}
		}
	}
}
