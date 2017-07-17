using PBServer.managers;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_MEMBER_CONTEXT_ACK : SendBaseGamePacket
	{
		private Account _clan;

		private List<Account> players_in_clan;

		public PROTOCOL_CS_MEMBER_CONTEXT_ACK(Account clan)
		{
			base.makeme();
			this._clan = clan;
		}

		protected internal override void write()
		{
			this.players_in_clan = ClanManager.getInstance().getClanPlayers(this._clan.getClanId());
			base.writeH(1307);
			base.writeD(0);
			base.writeC(Convert.ToByte(this.players_in_clan.Count));
			base.writeC(13);
			base.writeC(2);
			base.writeD(0);
		}
	}
}
