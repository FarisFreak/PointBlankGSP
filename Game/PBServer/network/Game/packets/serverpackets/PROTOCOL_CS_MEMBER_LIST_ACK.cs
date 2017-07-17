using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_MEMBER_LIST_ACK : SendBaseGamePacket
	{
		private Account account;

		private Clan clan;

		private List<Account> players_in_clan;

		public PROTOCOL_CS_MEMBER_LIST_ACK(Account a)
		{
			base.makeme();
			this.account = a;
			this.clan = this.account.getClan();
		}

		protected internal override void write()
		{
			this.players_in_clan = ClanManager.getInstance().getClanPlayers(this.account.getClanId());
			base.writeH(1309);
			base.writeD(0);
			base.writeC(0);
			base.writeC(Convert.ToByte(this.players_in_clan.Count));
			foreach (Account current in this.players_in_clan)
			{
				base.writeQ((long)current.getPlayerId());
				base.writeS(current.getPlayerName(), 33);
				base.writeC((byte)current.getRank());
				base.writeC(3);
				base.writeD(1);
				base.writeD(0);
				base.writeD(0);
				base.writeC((byte)current.getNameColor());
			}
		}
	}
}
