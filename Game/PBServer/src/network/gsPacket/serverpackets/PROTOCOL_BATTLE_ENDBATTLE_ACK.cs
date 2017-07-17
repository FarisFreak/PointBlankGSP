using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.src.network.gsPacket.serverpackets
{
	internal class PROTOCOL_BATTLE_ENDBATTLE_ACK : SendBaseGamePacket
	{
		private Account _player;

		private Room r;

		public PROTOCOL_BATTLE_ENDBATTLE_ACK(Account p)
		{
			base.makeme();
			this._player = p;
			this.r = p.getRoom();
			this.r.changeSlotState(p.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
		}

		protected internal override void write()
		{
			Clan clan = ClanManager.getInstance().get(this._player.getClanId());
			SLOT roomSlotByPlayer = this.r.getRoomSlotByPlayer(this._player);
			this._player.setExp(this._player.getExp() + roomSlotByPlayer.exp);
			this._player.setGP(this._player.getGP() + roomSlotByPlayer.gp);
			base.writeH(3336);
			bool flag = this.r.room_type == 1;
			if (flag)
			{
				bool flag2 = this.r.getBlueKills() > this.r.getRedKills();
				if (flag2)
				{
					base.writeC(1);
				}
				bool flag3 = this.r.getRedKills() > this.r.getBlueKills();
				if (flag3)
				{
					base.writeC(0);
				}
				bool flag4 = this.r.getRedKills() == this.r.getBlueKills();
				if (flag4)
				{
					base.writeC(2);
				}
			}
			bool flag5 = this.r.room_type == 2;
			if (flag5)
			{
				bool flag6 = this.r.getBlueWinRounds() > this.r.getRedWinRounds();
				if (flag6)
				{
					base.writeC(1);
				}
				bool flag7 = this.r.getRedWinRounds() > this.r.getBlueWinRounds();
				if (flag7)
				{
					base.writeC(0);
				}
				bool flag8 = this.r.getRedWinRounds() == this.r.getBlueWinRounds();
				if (flag8)
				{
					base.writeC(2);
				}
			}
			bool flag9 = this.r.room_type == 4;
			if (flag9)
			{
				bool flag10 = this.r.getBlueWinRounds() > this.r.getRedWinRounds();
				if (flag10)
				{
					base.writeC(1);
				}
				bool flag11 = this.r.getRedWinRounds() > this.r.getBlueWinRounds();
				if (flag11)
				{
					base.writeC(0);
				}
				bool flag12 = this.r.getRedWinRounds() == this.r.getBlueWinRounds();
				if (flag12)
				{
					base.writeC(2);
				}
			}
			bool flag13 = this._player != null && this.r.getLeader() != null;
			if (flag13)
			{
				this.r.stopBattle(this._player);
				base.writeH(3);
				base.writeH(2);
				for (int i = 0; i < 16; i++)
				{
					SLOT slot = this.r.getSlot(i);
					base.writeH((short)slot.exp);
				}
				for (int j = 0; j < 16; j++)
				{
					SLOT slot2 = this.r.getSlot(j);
					base.writeH((short)slot2.gp);
				}
				for (int k = 0; k < 16; k++)
				{
					bool flag14 = this.r.special == 6;
					if (flag14)
					{
						SLOT slot3 = this.r.getSlot(k);
						int botScore = slot3.getBotScore();
						base.writeH((short)botScore);
					}
					else
					{
						base.writeH(0);
					}
				}
				base.writeB(new byte[32]);
				base.writeB(new byte[]
				{
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255,
					255
				});
				base.writeS(this._player.getPlayerName(), 33);
				base.writeD(this._player.getExp());
				base.writeD(this._player.getRank());
				base.writeD(this._player.getRank());
				base.writeD(this._player.getGP());
				base.writeD(this._player.getMoney());
				base.writeD((this._player == null || clan == null) ? 0 : clan.getClanId());
				base.writeD((int)((short)((this._player == null || clan == null) ? 0 : clan.getLogoColor())));
				base.writeD(0);
				base.writeD(0);
				base.writeH((short)this._player.getPcCafe());
				base.writeC((byte)this._player.getNameColor());
				base.writeS((this._player == null || clan == null) ? "" : clan.getClanName(), 17);
				base.writeH((short)((this._player == null || clan == null) ? 0 : clan.getClanRank()));
				base.writeC(Convert.ToByte((this._player == null || clan == null) ? 255 : clan.getLogo1()));
				base.writeC(Convert.ToByte((this._player == null || clan == null) ? 255 : clan.getLogo2()));
				base.writeC(Convert.ToByte((this._player == null || clan == null) ? 255 : clan.getLogo3()));
				base.writeC(Convert.ToByte((this._player == null || clan == null) ? 255 : clan.getLogo4()));
				base.writeC(Convert.ToByte((this._player == null || clan == null) ? 0 : clan.getLogoColor()));
				base.writeC(0);
				base.writeD(0);
				base.writeD(0);
				base.writeD(0);
				base.writeD(this._player._statistic.getFights_s());
				base.writeD(this._player._statistic.getWinFights_s());
				base.writeD(this._player._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(this._player._statistic.getKills_s());
				base.writeD(this._player._statistic.getHeadShotKills());
				base.writeD(this._player._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(this._player._statistic.getKills_s());
				base.writeD(this._player._statistic.getEscapes_s());
				base.writeD(this._player._statistic.getFights_s());
				base.writeD(this._player._statistic.getWinFights_s());
				base.writeD(this._player._statistic.getLostFights_s());
				base.writeD(0);
				base.writeD(this._player._statistic.getKills_s());
				base.writeD(this._player._statistic.getHeadShotKills());
				base.writeD(this._player._statistic.getDeaths_s());
				base.writeD(0);
				base.writeD(this._player._statistic.getKills_s());
				base.writeD(this._player._statistic.getEscapes_s());
				bool flag15 = this.r.isBomb() || this.r.isEliminate() || this.r.isEscape() || this.r.isCrossCounter();
				if (flag15)
				{
					base.writeH((short)this.r.getRedWinRounds());
					base.writeH((short)this.r.getBlueWinRounds());
					SLOT[] slots = this.r._slots;
					for (int l = 0; l < slots.Length; l++)
					{
						SLOT sLOT = slots[l];
						base.writeC(0);
					}
				}
				bool flag16 = this.r.isAI();
				if (flag16)
				{
					SLOT[] slots2 = this.r._slots;
					for (int m = 0; m < slots2.Length; m++)
					{
						SLOT sLOT2 = slots2[m];
						base.writeH((short)sLOT2.getBotScore());
					}
				}
				base.writeB(new byte[49]);
			}
		}
	}
}
