using PBServer.managers;
using PBServer.model.clans;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_CLAN_DISBAND : ReceiveBaseGamePacket
	{
		public CM_CLAN_DISBAND(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Clan item = ClanManager.getInstance().get(base.getClient().getPlayer().getClanId());
			ClanManager.getInstance().getClans().Remove(item);
			base.getClient().getPlayer().setClanId(0);
			AccountManager.getInstance().UpdateClan(base.getClient().getPlayerId(), 0);
			ClanManager.getInstance().excludeClanInDb(base.getClient().getPlayerId());
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new SM_CLAN_DISBAND());
			}
		}
	}
}
