using PBServer.managers;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BASE_GET_CLAN_PLAYERS_ACK : SendBaseLoginPacket
	{
		private LoginClient _lc;

		private List<Account> players_in_clan;

		public PROTOCOL_BASE_GET_CLAN_PLAYERS_ACK(LoginClient lc)
		{
			base.makeme();
			this._lc = lc;
		}

		protected internal override void write()
		{
			base.writeH(1349);
			Account account = AccountManager.getInstance().get(this._lc.getLogin());
			this.players_in_clan = ClanManager.getInstance().getClanPlayers(account.getClanId());
			bool flag = account.getClanId() == 0;
			if (flag)
			{
				base.writeC(0);
				base.writeC(33);
				base.writeS("", 33);
				base.writeB(new byte[17]);
			}
			else
			{
				base.writeC(Convert.ToByte(this.players_in_clan.Count - 1));
				foreach (Account current in this.players_in_clan)
				{
					bool flag2 = current.getPlayerName() != account.getPlayerName();
					if (flag2)
					{
						base.writeC(33);
						base.writeS(current.getPlayerName(), 33);
						base.writeB(new byte[]
						{
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3,
							3
						});
						base.writeC(Convert.ToByte(current.getRank()));
					}
				}
			}
		}
	}
}
