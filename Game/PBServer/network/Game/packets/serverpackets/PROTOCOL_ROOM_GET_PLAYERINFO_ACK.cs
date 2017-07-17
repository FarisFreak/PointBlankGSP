using PBServer.model.clans;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_GET_PLAYERINFO_ACK : SendBaseGamePacket
	{
		private Account _p;

		private int _slot;

		public PROTOCOL_ROOM_GET_PLAYERINFO_ACK(int slot, Account p)
		{
			this._slot = slot;
			this._p = p;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3842);
			bool flag = this._p.getRoom() != null && this._p.getRoom().getPlayerBySlot(this._slot) != null;
			if (flag)
			{
				Account playerBySlot = this._p.getRoom().getPlayerBySlot(this._slot);
				Clan clan = this._p.getClan();
				base.writeD(1);
				base.writeS(playerBySlot.getPlayerName(), 33);
				base.writeD(playerBySlot.getExp());
				base.writeD(playerBySlot.getRank());
				base.writeD(0);
				base.writeD(playerBySlot.getGP());
				base.writeD(playerBySlot.getMoney());
				base.writeD((int)((short)((playerBySlot == null || clan == null) ? 0 : clan.getClanId())));
				base.writeD(1);
				base.writeD(0);
				base.writeD(0);
				base.writeH((short)playerBySlot.getPcCafe());
				base.writeC((byte)playerBySlot.getNameColor());
				base.writeS(Convert.ToString((playerBySlot == null || clan == null) ? "" : clan.getClanName()), 17);
				base.writeH((short)((playerBySlot == null || clan == null) ? 0 : clan.getClanRank()));
				base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo1()));
				base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo2()));
				base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo3()));
				base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo4()));
				base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 0 : clan.getLogoColor()));
				base.writeC(0);
				base.writeD(0);
				base.writeD(0);
				base.writeD(0);
				base.writeD(playerBySlot._statistic.getFights_s());
				base.writeD(playerBySlot._statistic.getWinFights_s());
				base.writeD(playerBySlot._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(playerBySlot._statistic.getKills_s());
				base.writeD(playerBySlot._statistic.getHeadShotKills());
				base.writeD(playerBySlot._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(playerBySlot._statistic.getKills_s());
				base.writeD(playerBySlot._statistic.getEscapes_s());
				base.writeD(playerBySlot._statistic.getFights_s());
				base.writeD(playerBySlot._statistic.getWinFights_s());
				base.writeD(playerBySlot._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(playerBySlot._statistic.getKills_s());
				base.writeD(playerBySlot._statistic.getHeadShotKills());
				base.writeD(playerBySlot._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(playerBySlot._statistic.getKills_s());
				base.writeD(playerBySlot._statistic.getEscapes_s());
				base.writeD(playerBySlot.getCharRed());
				base.writeD(playerBySlot.getCharBlue());
				base.writeD(playerBySlot.getCharHelmet());
				base.writeD(playerBySlot.getCharBeret());
				base.writeD(playerBySlot.getCharDino());
				base.writeD(playerBySlot.getPrimaryWeapon());
				base.writeD(playerBySlot.getSecondaryWeapon());
				base.writeD(playerBySlot.getMeleeWeapon());
				base.writeD(playerBySlot.getThrownNormalWeapon());
				base.writeD(playerBySlot.getThrownSpecialWeapon());
			}
			else
			{
				base.writeD(1);
			}
		}
	}
}
