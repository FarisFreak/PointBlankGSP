using PBServer.managers;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_CS_DETAIL_INFO_REQ : ReceiveBaseGamePacket
	{
		private int clanId;

		public PROTOCOL_CS_DETAIL_INFO_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.clanId = (int)base.readC();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = ClanManager.getInstance().get(this.clanId) != null;
			if (flag)
			{
				base.getClient().getPlayer().sendPacket(new PROTOCOL_CS_DETAIL_INFO_ACK(ClanManager.getInstance().get(this.clanId)));
			}
			else
			{
				base.getClient().getPlayer().sendPacket(new PROTOCOL_CS_DETAIL_INFO_ACK(ClanManager.getInstance().get(base.getClient().getPlayer().getClanId())));
			}
		}
	}
}
