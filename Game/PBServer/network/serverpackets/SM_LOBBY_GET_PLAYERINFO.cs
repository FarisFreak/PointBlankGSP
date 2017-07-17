using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class SM_LOBBY_GET_PLAYERINFO : SendBaseGamePacket
	{
		private int _id;

		public SM_LOBBY_GET_PLAYERINFO(int id)
		{
			base.makeme();
			this._id = id;
		}

		protected internal override void write()
		{
			Account accountInPlayerId = AccountManager.getInstance().getAccountInPlayerId(this._id);
			bool flag = accountInPlayerId != null;
			if (flag)
			{
				base.writeH(2640);
				base.writeD(accountInPlayerId._statistic.getFights_s());
				base.writeD(accountInPlayerId._statistic.getWinFights_s());
				base.writeD(accountInPlayerId._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(accountInPlayerId._statistic.getKills_s());
				base.writeD(accountInPlayerId._statistic.getHeadShotKills());
				base.writeD(accountInPlayerId._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(accountInPlayerId._statistic.getKills_s());
				base.writeD(accountInPlayerId._statistic.getEscapes_s());
				base.writeD(accountInPlayerId._statistic.getFights_s());
				base.writeD(accountInPlayerId._statistic.getWinFights_s());
				base.writeD(accountInPlayerId._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(accountInPlayerId._statistic.getKills_s());
				base.writeD(accountInPlayerId._statistic.getHeadShotKills());
				base.writeD(accountInPlayerId._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(accountInPlayerId._statistic.getKills_s());
				base.writeD(accountInPlayerId._statistic.getEscapes_s());
			}
		}
	}
}
