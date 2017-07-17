using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_CLAN_PLAYER_LEAVE : ReceiveBaseGamePacket
	{
		public CM_CLAN_PLAYER_LEAVE(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().getPlayer().setClanId(0);
				AccountManager.getInstance().UpdateClan(base.getClient().getPlayerId(), 0);
				base.getClient().sendPacket(new SM_CLAN_PLAYER_LEAVE());
			}
		}
	}
}
