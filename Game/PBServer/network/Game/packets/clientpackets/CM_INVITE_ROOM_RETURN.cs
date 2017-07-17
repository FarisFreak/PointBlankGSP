using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_INVITE_ROOM_RETURN : ReceiveBaseGamePacket
	{
		private int Player1;

		public CM_INVITE_ROOM_RETURN(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.Player1 = (int)base.readC();
			CLogger.getInstance().info("[Room] Number of players selected " + this.Player1);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
			for (int i = 0; i < channel.getWaitPlayers().Count; i++)
			{
				bool flag = channel.getWaitPlayers()[i] != null;
				if (flag)
				{
					channel.getWaitPlayers()[i].sendPacket(new SM_INVITE_FROM_ROOM_MESSAGE(player.getPlayerName(), player.getRoom().getRoomId()));
				}
			}
			base.getClient().getPlayer().sendPacket(new SM_INVITE_ROOM_RETURN());
		}
	}
}
