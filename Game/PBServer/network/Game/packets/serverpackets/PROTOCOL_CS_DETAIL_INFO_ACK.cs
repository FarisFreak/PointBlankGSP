using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_DETAIL_INFO_ACK : SendBaseGamePacket
	{
		private Clan clan;

		public PROTOCOL_CS_DETAIL_INFO_ACK(Clan c)
		{
			base.makeme();
			this.clan = c;
		}

		protected internal override void write()
		{
			base.writeH(1305);
			base.writeD(0);
			base.writeC((byte)this.clan.getClanId());
			base.writeC(65);
			base.writeH(0);
			base.writeS(this.clan.getClanName(), 17);
			base.writeH((short)this.clan.getClanRank());
			base.writeC(Convert.ToByte(ClanManager.getInstance().getClanPlayers(this.clan.getClanId()).Count));
			base.writeB(new byte[]
			{
				50,
				75,
				5,
				51
			});
			base.writeC((byte)this.clan.getLogo1());
			base.writeC((byte)this.clan.getLogo2());
			base.writeC((byte)this.clan.getLogo3());
			base.writeC((byte)this.clan.getLogo4());
			base.writeC((byte)this.clan.getLogoColor());
			base.writeD(0);
			base.writeB(new byte[13]);
			bool flag = AccountManager.getInstance().getAccountInPlayerId(this.clan.getOwnerId()) != null;
			if (flag)
			{
				base.writeS(AccountManager.getInstance().getAccountInPlayerId(this.clan.getOwnerId()).getPlayerName(), 33);
				base.writeC((byte)AccountManager.getInstance().getAccountInPlayerId(this.clan.getOwnerId()).getRank());
			}
			else
			{
				base.writeS("", 33);
				base.writeC(0);
			}
			base.writeS(this.clan.clan_info, 280);
			base.writeS("[Test] Modify Clan Notice", 280);
		}
	}
}
