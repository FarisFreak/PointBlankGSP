using PBServer.model.clans;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_CLIENT_CLAN_LIST_ACK : SendBaseGamePacket
	{
		private List<Clan> clans;

		public PROTOCOL_CS_CLIENT_CLAN_LIST_ACK(List<Clan> clans)
		{
			base.makeme();
			this.clans = clans;
		}

		protected internal override void write()
		{
			base.writeH(1446);
			base.writeD(0);
			foreach (Clan current in this.clans)
			{
				base.writeC(170);
				base.writeD(current.getClanId());
				base.writeS(current.getClanName(), current.getClanName().Length);
				base.writeC((byte)current.getClanRank());
				base.writeC(0);
				base.writeC(50);
				base.writeD(current.getDateCreated());
				base.writeB(new byte[]
				{
					1,
					8,
					30,
					26
				});
			}
		}
	}
}
