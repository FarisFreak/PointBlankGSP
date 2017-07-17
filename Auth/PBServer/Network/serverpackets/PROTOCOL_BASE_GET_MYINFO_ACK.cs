using Data.xml.parsers;
using PBServer.data.model;
using PBServer.data.xml.holders;
using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.managers;
using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	internal class PROTOCOL_BASE_GET_MYINFO_ACK : SendBaseLoginPacket
	{
		private LoginClient _lc;

		public PROTOCOL_BASE_GET_MYINFO_ACK(LoginClient lc)
		{
			this._lc = lc;
			base.makeme();
		}

		protected internal override void write()
		{
			Account account = AccountManager.getInstance().get(this._lc.getLogin());
			Clan clan = ClanManager.getInstance().get(account.getClanId());
			Mission mission = MissionManager.getInstance().get(account.getPlayerId());
			bool flag = account.getPlayerName() == null || account.getPlayerName() == "";
			if (flag)
			{
				PlayerTemplate playerTemplate = PlayerTemplateHolder.getPlayerTemplate(Config.PlayerTemplateId);
				account.setRank(playerTemplate._rank);
				account.setExp(playerTemplate._exp);
				account.setGP(playerTemplate._gp);
			}
			base.writeH(2566);
			base.writeD(4);
			base.writeC(1);
			base.writeS(account.getPlayerName(), 33);
			base.writeD(account.getExp());
			base.writeD(account.getRank());
			base.writeD(4);
			base.writeD(account.getGP());
			base.writeD(account.getMoney());
			base.writeD((int)((short)((account == null || clan == null) ? 0 : clan.getClanId())));
			base.writeD(2);
			base.writeD(0);
			base.writeD(0);
			base.writeH((short)account.getPcCafe());
			base.writeC((byte)account.getNameColor());
			base.writeS(Convert.ToString((account == null || clan == null) ? "" : clan.getClanName()), 17);
			base.writeH((short)((account == null || clan == null) ? 0 : clan.getClanRank()));
			base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo1()));
			base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo2()));
			base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo3()));
			base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo4()));
			base.writeC(Convert.ToByte((account == null || clan == null) ? 0 : clan.getLogoColor()));
			base.writeC(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(account._statistic.getFights_s());
			base.writeD(account._statistic.getWinFights_s());
			base.writeD(account._statistic.getLostFights_s());
			base.writeD(0);
			base.writeD(account._statistic.getKills_s());
			base.writeD(account._statistic.getHeadShotKills());
			base.writeD(account._statistic.getDeaths_s());
			base.writeD(0);
			base.writeD(account._statistic.getKills_s());
			base.writeD(account._statistic.getEscapes_s());
			base.writeD(account._statistic.getFights_s());
			base.writeD(account._statistic.getWinFights_s());
			base.writeD(account._statistic.getLostFights_s());
			base.writeD(0);
			base.writeD(account._statistic.getKills_s());
			base.writeD(account._statistic.getHeadShotKills());
			base.writeD(account._statistic.getDeaths_s());
			base.writeD(0);
			base.writeD(account._statistic.getKills_s());
			base.writeD(account._statistic.getEscapes_s());
			account.setStatus(1);
			AccountManager.getInstance().UpdateStatus(account.getPlayerId(), 1);
			account.CheckCorrectInventory();
			base.writeD(account.getCharRed());
			base.writeD(account.getCharBlue());
			base.writeD(account.getCharHelmet());
			base.writeD(account.getCharBeret());
			base.writeD(account.getCharDino());
			base.writeD(account.getPrimaryWeapon());
			base.writeD(account.getSecondaryWeapon());
			base.writeD(account.getMeleeWeapon());
			base.writeD(account.getThrownNormalWeapon());
			base.writeD(account.getThrownSpecialWeapon());
			base.writeH(0);
			base.writeH(55);
			base.writeH(0);
			base.writeH(55);
			base.writeB(new byte[38]);
			bool flag2 = account.getPlayerName() == null || account.getPlayerName() == "";
			if (flag2)
			{
				account.setCharRed(1001001005);
				account.setCharBlue(1001002006);
				account.setCharHelmet(1102003001);
				account.setCharDino(1006003041);
				account.setCharBeret(0);
				account.setPrimaryWeapon(200004006);
				account.setSecondaryWeapon(601002003);
				account.setMeleeWeapon(702001001);
				account.setThrownNormalWeapon(803007001);
				account.setThrownSpecialWeapon(904007002);
			}
			else
			{
				base.writeC(1);
			}
			bool flag3 = account.getPlayerName() == null || account.getPlayerName() == "";
			if (flag3)
			{
				base.writeD(account.getInvetoryOnlyEquip(2).Count);
				base.writeD(account.getInvetoryOnlyEquip(1).Count);
				base.writeD(account.getInvetoryOnlyEquip(3).Count);
				base.writeD(0);
			}
			else
			{
				base.writeD(account.getInvetoryOnly(2).Count);
				base.writeD(account.getInvetoryOnly(1).Count);
				base.writeD(account.getInvetoryOnly(3).Count);
				base.writeD(0);
			}
			bool flag4 = account.getPlayerName() == null || account.getPlayerName() == "";
			if (flag4)
			{
				for (int i = 0; i < account.getInvetoryOnlyEquip(2).Count; i++)
				{
					base.writeD(account.getInvetoryOnlyEquip(2)[i].id);
					base.writeD(account.getInvetoryOnlyEquip(2)[i].id);
					base.writeD(account.getInvetoryOnlyEquip(2)[i].id);
					base.writeC((byte)account.getInvetoryOnlyEquip(2)[i].equip_type);
					base.writeD(account.getInvetoryOnlyEquip(2)[i].count);
				}
				for (int j = 0; j < account.getInvetoryOnlyEquip(1).Count; j++)
				{
					base.writeD(account.getInvetoryOnlyEquip(1)[j].id);
					base.writeD(account.getInvetoryOnlyEquip(1)[j].id);
					base.writeD(account.getInvetoryOnlyEquip(1)[j].id);
					base.writeC((byte)account.getInvetoryOnlyEquip(1)[j].equip_type);
					base.writeD(account.getInvetoryOnlyEquip(1)[j].count);
				}
				for (int k = 0; k < account.getInvetoryOnlyEquip(3).Count; k++)
				{
					base.writeD(account.getInvetoryOnlyEquip(3)[k].id);
					base.writeD(account.getInvetoryOnlyEquip(3)[k].id);
					base.writeD(account.getInvetoryOnlyEquip(3)[k].id);
					base.writeC((byte)account.getInvetoryOnlyEquip(3)[k].equip_type);
					base.writeD(account.getInvetoryOnlyEquip(3)[k].count);
				}
				for (int l = 0; l < account.getInvetoryOnlyEquip(4).Count; l++)
				{
					base.writeD(account.getInvetoryOnlyEquip(4)[l].id);
					base.writeD(account.getInvetoryOnlyEquip(4)[l].id);
					base.writeD(account.getInvetoryOnlyEquip(4)[l].id);
					base.writeC((byte)account.getInvetoryOnlyEquip(4)[l].equip_type);
					base.writeD(account.getInvetoryOnlyEquip(4)[l].count);
				}
			}
			else
			{
				for (int m = 0; m < account.getInvetoryOnly(2).Count; m++)
				{
					base.writeD(account.getInvetoryOnly(2)[m].id);
					base.writeD(account.getInvetoryOnly(2)[m].id);
					base.writeD(account.getInvetoryOnly(2)[m].id);
					base.writeC((byte)account.getInvetoryOnly(2)[m].equip_type);
					base.writeD(account.getInvetoryOnly(2)[m].count);
				}
				for (int n = 0; n < account.getInvetoryOnly(1).Count; n++)
				{
					base.writeD(account.getInvetoryOnly(1)[n].id);
					base.writeD(account.getInvetoryOnly(1)[n].id);
					base.writeD(account.getInvetoryOnly(1)[n].id);
					base.writeC((byte)account.getInvetoryOnly(1)[n].equip_type);
					base.writeD(account.getInvetoryOnly(1)[n].count);
				}
				for (int num = 0; num < account.getInvetoryOnly(3).Count; num++)
				{
					base.writeD(account.getInvetoryOnly(3)[num].id);
					base.writeD(account.getInvetoryOnly(3)[num].id);
					base.writeD(account.getInvetoryOnly(3)[num].id);
					base.writeC((byte)account.getInvetoryOnly(3)[num].equip_type);
					base.writeD(account.getInvetoryOnly(3)[num].count);
				}
				for (int num2 = 0; num2 < account.getInvetoryOnly(4).Count; num2++)
				{
					base.writeD(account.getInvetoryOnly(4)[num2].id);
					base.writeD(account.getInvetoryOnly(4)[num2].id);
					base.writeD(account.getInvetoryOnly(4)[num2].id);
					base.writeC((byte)account.getInvetoryOnly(4)[num2].equip_type);
					base.writeD(account.getInvetoryOnly(4)[num2].count);
				}
			}
			base.writeC((byte)Config.OutpostEnable);
			base.writeD(account.getBrooch());
			base.writeD(account.getInsignia());
			base.writeD(account.getMedal());
			base.writeD(account.getBlueOrder());
			base.writeC((byte)account.getMissionId());
			base.writeD(account.getCardId());
			mission = this.getMissionById(0);
			bool flag5 = account.getMission1() == account.getCard1_1();
			if (flag5)
			{
				bool flag6 = account.getMission2() == account.getCard1_2();
				if (flag6)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag7 = account.getMission2() == account.getCard1_2();
				if (flag7)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag8 = account.getMission3() == account.getCard1_3();
			if (flag8)
			{
				bool flag9 = account.getMission4() == account.getCard1_4();
				if (flag9)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag10 = account.getMission4() == account.getCard1_4();
				if (flag10)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(1);
			bool flag11 = account.getMission1() == account.getCard2_1();
			if (flag11)
			{
				bool flag12 = account.getMission2() == account.getCard2_2();
				if (flag12)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag13 = account.getMission2() == account.getCard2_2();
				if (flag13)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag14 = account.getMission3() == account.getCard2_3();
			if (flag14)
			{
				bool flag15 = account.getMission4() == account.getCard2_4();
				if (flag15)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag16 = account.getMission4() == account.getCard2_4();
				if (flag16)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(2);
			bool flag17 = account.getMission1() == account.getCard1_1();
			if (flag17)
			{
				bool flag18 = account.getMission2() == account.getCard3_2();
				if (flag18)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag19 = account.getMission2() == account.getCard3_2();
				if (flag19)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag20 = account.getMission3() == account.getCard1_3();
			if (flag20)
			{
				bool flag21 = account.getMission4() == account.getCard3_4();
				if (flag21)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag22 = account.getMission4() == account.getCard3_4();
				if (flag22)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(3);
			bool flag23 = account.getMission1() == account.getCard4_1();
			if (flag23)
			{
				bool flag24 = account.getMission2() == account.getCard4_2();
				if (flag24)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag25 = account.getMission2() == account.getCard4_2();
				if (flag25)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag26 = account.getMission3() == account.getCard4_3();
			if (flag26)
			{
				bool flag27 = account.getMission4() == account.getCard4_4();
				if (flag27)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag28 = account.getMission4() == account.getCard4_4();
				if (flag28)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(4);
			bool flag29 = account.getMission1() == account.getCard5_1();
			if (flag29)
			{
				bool flag30 = account.getMission2() == account.getCard5_2();
				if (flag30)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag31 = account.getMission2() == account.getCard5_2();
				if (flag31)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag32 = account.getMission3() == account.getCard5_3();
			if (flag32)
			{
				bool flag33 = account.getMission4() == account.getCard5_4();
				if (flag33)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag34 = account.getMission4() == account.getCard5_4();
				if (flag34)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(5);
			bool flag35 = account.getMission1() == account.getCard6_1();
			if (flag35)
			{
				bool flag36 = account.getMission2() == account.getCard6_2();
				if (flag36)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag37 = account.getMission2() == account.getCard6_2();
				if (flag37)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag38 = account.getMission3() == account.getCard6_3();
			if (flag38)
			{
				bool flag39 = account.getMission4() == account.getCard6_4();
				if (flag39)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag40 = account.getMission4() == account.getCard6_4();
				if (flag40)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(6);
			bool flag41 = account.getMission1() == account.getCard7_1();
			if (flag41)
			{
				bool flag42 = account.getMission2() == account.getCard7_2();
				if (flag42)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag43 = account.getMission2() == account.getCard7_2();
				if (flag43)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag44 = account.getMission3() == account.getCard7_3();
			if (flag44)
			{
				bool flag45 = account.getMission4() == account.getCard7_4();
				if (flag45)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag46 = account.getMission4() == account.getCard7_4();
				if (flag46)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(7);
			bool flag47 = account.getMission1() == account.getCard8_1();
			if (flag47)
			{
				bool flag48 = account.getMission2() == account.getCard8_2();
				if (flag48)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag49 = account.getMission2() == account.getCard8_2();
				if (flag49)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag50 = account.getMission3() == account.getCard8_3();
			if (flag50)
			{
				bool flag51 = account.getMission4() == account.getCard8_4();
				if (flag51)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag52 = account.getMission4() == account.getCard8_4();
				if (flag52)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(8);
			bool flag53 = account.getMission1() == account.getCard9_1();
			if (flag53)
			{
				bool flag54 = account.getMission2() == account.getCard9_2();
				if (flag54)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag55 = account.getMission2() == account.getCard9_2();
				if (flag55)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag56 = account.getMission3() == account.getCard9_3();
			if (flag56)
			{
				bool flag57 = account.getMission4() == account.getCard9_4();
				if (flag57)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag58 = account.getMission4() == account.getCard9_4();
				if (flag58)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			mission = this.getMissionById(9);
			bool flag59 = account.getMission1() == account.getCard10_1();
			if (flag59)
			{
				bool flag60 = account.getMission2() == account.getCard10_2();
				if (flag60)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag61 = account.getMission2() == account.getCard10_2();
				if (flag61)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			bool flag62 = account.getMission3() == account.getCard10_3();
			if (flag62)
			{
				bool flag63 = account.getMission4() == account.getCard10_4();
				if (flag63)
				{
					base.writeC(255);
				}
				else
				{
					base.writeC(239);
				}
			}
			else
			{
				bool flag64 = account.getMission4() == account.getCard10_4();
				if (flag64)
				{
					base.writeC(254);
				}
				else
				{
					base.writeC(0);
				}
			}
			base.writeB(new byte[]
			{
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			});
			base.writeC((byte)account.getCard1_1());
			base.writeC((byte)account.getCard1_2());
			base.writeC((byte)account.getCard1_3());
			base.writeC((byte)account.getCard1_4());
			base.writeC((byte)account.getCard2_1());
			base.writeC((byte)account.getCard2_2());
			base.writeC((byte)account.getCard2_3());
			base.writeC((byte)account.getCard2_4());
			base.writeC((byte)account.getCard3_1());
			base.writeC((byte)account.getCard3_2());
			base.writeC((byte)account.getCard3_3());
			base.writeC((byte)account.getCard3_4());
			base.writeC((byte)account.getCard4_1());
			base.writeC((byte)account.getCard4_2());
			base.writeC((byte)account.getCard4_3());
			base.writeC((byte)account.getCard4_4());
			base.writeC((byte)account.getCard5_1());
			base.writeC((byte)account.getCard5_2());
			base.writeC((byte)account.getCard5_3());
			base.writeC((byte)account.getCard5_4());
			base.writeC((byte)account.getCard6_1());
			base.writeC((byte)account.getCard6_2());
			base.writeC((byte)account.getCard6_3());
			base.writeC((byte)account.getCard6_4());
			base.writeC((byte)account.getCard7_1());
			base.writeC((byte)account.getCard7_2());
			base.writeC((byte)account.getCard7_3());
			base.writeC((byte)account.getCard7_4());
			base.writeC((byte)account.getCard8_1());
			base.writeC((byte)account.getCard8_2());
			base.writeC((byte)account.getCard8_3());
			base.writeC((byte)account.getCard8_4());
			base.writeC((byte)account.getCard9_1());
			base.writeC((byte)account.getCard9_2());
			base.writeC((byte)account.getCard9_3());
			base.writeC((byte)account.getCard9_4());
			base.writeC((byte)account.getCard10_1());
			base.writeC((byte)account.getCard10_2());
			base.writeC((byte)account.getCard10_3());
			base.writeC((byte)account.getCard10_4());
			base.writeB(new byte[]
			{
				1,
				1,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			});
			base.writeC((byte)account.title.getP1());
			base.writeC((byte)account.title.getP2());
			base.writeC((byte)account.title.getP3());
			base.writeC((byte)account.title.getP4());
			base.writeC((byte)account.title.getP5());
			base.writeC((byte)account.title.getP6());
			base.writeC(0);
			base.writeC(0);
			base.writeB(new byte[]
			{
				Convert.ToByte(account.title.getEquipedTitle1()),
				Convert.ToByte(account.title.getEquipedTitle2()),
				Convert.ToByte(account.title.getEquipedTitle3())
			});
			base.writeD(account.getTitleSlotCount());
			base.writeD(0);
			base.writeD(3);
			base.writeD(25);
			base.writeD(37);
			base.writeD(1);
			base.writeD(39);
			base.writeD(1);
			base.writeD(40);
			base.writeD(1);
			base.writeD(1);
			base.writeD(0);
			base.writeD(0);
			base.writeD(54);
			base.writeC(60);
			base.writeC(2);
			base.writeB(new byte[]
			{
				0,
				1,
				254,
				4,
				212,
				15,
				118,
				199,
				127,
				8
			});
			base.writeB(new byte[]
			{
				0,
				1,
				254,
				15,
				212,
				254,
				143,
				199,
				127,
				163
			});
			base.writeB(new byte[]
			{
				23,
				160,
				141,
				1,
				136,
				0,
				137,
				0,
				141,
				0,
				141,
				0,
				141,
				0,
				141,
				1,
				9,
				0,
				1,
				0,
				0,
				0,
				141,
				0,
				128,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				140,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				8,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0
			});
			base.writeB(new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				1,
				0,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1,
				1
			});
			base.writeC(1);
			base.writeB(new byte[]
			{
				238,
				3,
				3,
				0
			});
			base.writeD(1);
			base.writeD(1);
			base.writeC(1);
			base.writeH(50);
			base.writeD((account.getRank() == 53 || account.getRank() == 54) ? 1 : 0);
			base.writeD(702001024);
			base.writeC(1);
			base.writeB(new byte[5]);
		}

		public Mission getMissionById(int id)
		{
			Mission mission;
			Mission result;
			foreach (Mission current in TutorialParser.tutorial.Values)
			{
				bool flag = current.getId() == id;
				if (flag)
				{
					mission = current;
					result = mission;
					return result;
				}
			}
			mission = null;
			result = mission;
			return result;
		}
	}
}
