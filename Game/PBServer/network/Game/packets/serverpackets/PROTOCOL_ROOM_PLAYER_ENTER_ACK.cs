using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_PLAYER_ENTER_ACK : SendBaseGamePacket
	{
		private Account pl;

		public PROTOCOL_ROOM_PLAYER_ENTER_ACK(Account p)
		{
			this.pl = p;
			base.makeme();
		}

		protected internal override void write()
		{
			Clan clan = ClanManager.getInstance().get(this.pl.getClanId());
			base.writeH(3909);
			base.writeD(this.pl.getSlot());
			base.writeC((byte)this.pl.getRoom().getSlotState(this.pl.getSlot()));
			base.writeH((short)this.pl.getRank());
			base.writeB(new byte[8]);
			bool flag = this.pl.getClanId() == 0;
			if (flag)
			{
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(0);
				base.writeS("", 22);
			}
			bool flag2 = this.pl.getClanId() > 0;
			if (flag2)
			{
				base.writeC((byte)clan.getLogo1());
				base.writeC((byte)clan.getLogo2());
				base.writeC((byte)clan.getLogo3());
				base.writeC((byte)clan.getLogo4());
				base.writeC((byte)clan.getLogoColor());
				base.writeS(clan.getClanName(), 22);
			}
			base.writeC((byte)this.pl.getSlot());
			base.writeC((byte)this.pl.getPlayerName().Length);
			base.writeC(0);
			base.writeH(33);
			base.writeS(this.pl.getPlayerName(), 33);
			base.writeC((byte)this.pl.getNameColor());
		}
	}
}
