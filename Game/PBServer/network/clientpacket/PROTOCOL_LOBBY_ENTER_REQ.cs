using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_ENTER_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_LOBBY_ENTER_REQ(GameClient Client, byte[] data)
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
				bool flag2 = base.getClient().getPlayer() != null;
				if (flag2)
				{
					Account playerFromPlayerId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(base.getClient().getPlayer().player_id);
					bool flag3 = playerFromPlayerId != null && playerFromPlayerId.getRoom() != null;
					if (flag3)
					{
						ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(playerFromPlayerId.getRoom().getRoomId()).removePlayer(playerFromPlayerId);
					}
					bool flag4 = base.getClient().getPlayer() != null;
					if (flag4)
					{
						Account player = base.getClient().getPlayer();
						player.setClient(base.getClient());
						player.setOnlineStatus(true);
						int channelId = base.getClient().getChannelId();
						bool flag5 = channelId > -1;
						if (flag5)
						{
							ChannelInfoHolder.getChannel(channelId).addPlayer(player);
						}
					}
				}
				base.getClient().sendPacket(new PROTOCOL_LOBBY_ENTER_ACK());
				base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(base.getClient().getPlayer()));
			}
		}
	}
}
