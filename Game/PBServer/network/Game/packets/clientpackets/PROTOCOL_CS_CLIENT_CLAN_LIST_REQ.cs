using PBServer.managers;
using PBServer.model.clans;
using PBServer.network.Game.packets.serverpackets;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_CS_CLIENT_CLAN_LIST_REQ : ReceiveBaseGamePacket
	{
		private List<Clan> _clans = null;

		public PROTOCOL_CS_CLIENT_CLAN_LIST_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			this._clans = ClanManager.getInstance().getClans();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_CS_CLIENT_CLAN_LIST_ACK(this._clans));
			}
		}
	}
}
