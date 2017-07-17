using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_LEAVE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_LOBBY_LEAVE_REQ(GameClient Client, byte[] data)
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
				Account player = base.getClient().getPlayer();
				Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
				bool flag2 = channel != null && player != null && channel.getAllPlayers().Contains(player.getPlayerId());
				if (flag2)
				{
					channel.removePlayer(player);
				}
				base.getClient().sendPacket(new PROTOCOL_LOBBY_LEAVE_ACK());
				CLogger.getInstance().info("[Lobby] " + base.getClient().getPlayer().getPlayerName().ToString() + " out of the lobby.");
			}
		}
	}
}
