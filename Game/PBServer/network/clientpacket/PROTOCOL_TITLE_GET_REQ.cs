using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_TITLE_GET_REQ : ReceiveBaseGamePacket
	{
		private int _titleIdx;

		public PROTOCOL_TITLE_GET_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this._titleIdx = (int)base.readB(1)[0];
		}

		protected internal override void run()
		{
			int num = 2147483647;
			int num2 = 1;
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				int rank = player.getRank();
				switch (this._titleIdx)
				{
				case 1:
				{
					bool flag2 = rank >= 1;
					if (flag2)
					{
						num2 = 1;
						num = 0;
						player.title.titlePos1 += 2;
						player.title.title1 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 2:
				{
					bool flag3 = rank >= 2 && player.title.title1 == 1;
					if (flag3)
					{
						num2 = 1;
						num = 0;
						player.title.titlePos1 += 4;
						player.title.title2 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 3:
				{
					bool flag4 = rank >= 3 && player.title.title2 == 1;
					if (flag4)
					{
						num2 = 1;
						num = 0;
						player.title.titlePos1 += 8;
						player.title.title3 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 4:
				{
					bool flag5 = rank >= 4 && player.title.title3 == 1;
					if (flag5)
					{
						num2 = 1;
						num = 0;
						player.title.titlePos1 += 16;
						player.title.title4 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 5:
				{
					bool flag6 = rank >= 5 && player.title.title4 == 1;
					if (flag6)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos1 += 32;
						player.title.title5 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 6:
				{
					bool flag7 = rank >= 5 && player.title.title4 == 1;
					if (flag7)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos1 += 64;
						player.title.title6 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 7:
				{
					bool flag8 = rank >= 5 && player.title.title4 == 1;
					if (flag8)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos1 += 128;
						player.title.title7 = 1;
						TitleManager.getInstance().UpdateTitles(player.getPlayerId(), player.title.title1, player.title.title2, player.title.title3, player.title.title4, player.title.title5, player.title.title6, player.title.title7);
						TitleManager.getInstance().UpdatePosTitles(player.getPlayerId(), player.title.titlePos1);
					}
					break;
				}
				case 8:
				{
					bool flag9 = rank >= 8 && player.title.title5 == 1;
					if (flag9)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos2++;
						player.title.title8 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(100003014, 0, player.getPlayerId(), "SG 550 S. 10U", 10, 1, player));
					}
					break;
				}
				case 9:
				{
					bool flag10 = rank >= 12 && player.title.title8 == 1;
					if (flag10)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos2 += 2;
						player.title.title9 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
					}
					break;
				}
				case 10:
				{
					bool flag11 = rank >= 17 && player.title.title9 == 1;
					if (flag11)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos2 += 4;
						player.title.title10 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(100003013, 0, player.getPlayerId(), "G36C Ext. 10U", 10, 1, player));
					}
					break;
				}
				case 11:
				{
					bool flag12 = rank >= 21 && player.title.title10 == 1 && player.title.title28 == 1;
					if (flag12)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos2 += 8;
						player.title.title11 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
					}
					break;
				}
				case 12:
				{
					bool flag13 = rank >= 26 && player.title.title11 == 1;
					if (flag13)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos2 += 16;
						player.title.title12 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(100003036, 0, player.getPlayerId(), "AUG A3 10U", 10, 1, player));
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(100003015, 0, player.getPlayerId(), "AK SOPMOD 10U", 10, 1, player));
					}
					break;
				}
				case 13:
				{
					bool flag14 = rank >= 31 && player.title.title11 == 1;
					if (flag14)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos2 += 32;
						player.title.title13 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1103003001, 0, player.getPlayerId(), "Boina de Assalto", 100, 0, player));
					}
					break;
				}
				case 14:
				{
					bool flag15 = rank >= 8 && player.title.title6 == 1;
					if (flag15)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos2 += 64;
						player.title.title14 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
					}
					break;
				}
				case 15:
				{
					bool flag16 = rank >= 12 && player.title.title14 == 1;
					if (flag16)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos2 += 128;
						player.title.title15 = 1;
						TitleManager.getInstance().UpdateTitles2(player.getPlayerId(), player.title.title8, player.title.title9, player.title.title10, player.title.title11, player.title.title12, player.title.title13, player.title.title14, player.title.title15);
						TitleManager.getInstance().UpdatePosTitles2(player.getPlayerId(), player.title.titlePos2);
					}
					break;
				}
				case 16:
				{
					bool flag17 = rank >= 17 && player.title.title15 == 1;
					if (flag17)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos3++;
						player.title.title16 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
					}
					break;
				}
				case 17:
				{
					bool flag18 = rank >= 21 && player.title.title16 == 1 && player.title.title32 == 1;
					if (flag18)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos3 += 2;
						player.title.title17 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
					}
					break;
				}
				case 18:
				{
					bool flag19 = rank >= 26 && player.title.title17 == 1;
					if (flag19)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos3 += 4;
						player.title.title18 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(300005005, 0, player.getPlayerId(), "L115A1 10U", 10, 1, player));
					}
					break;
				}
				case 19:
				{
					bool flag20 = rank >= 31 && player.title.title18 == 1;
					if (flag20)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos3 += 8;
						player.title.title19 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1103003003, 0, player.getPlayerId(), "Boina dos Snipers", 100, 0, player));
					}
					break;
				}
				case 20:
				{
					bool flag21 = rank >= 8 && player.title.title7 == 1;
					if (flag21)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos3 += 16;
						player.title.title20 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(200004007, 0, player.getPlayerId(), "MP5K G. 10U", 10, 1, player));
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(200004009, 0, player.getPlayerId(), "Spectre W. 10U", 10, 1, player));
					}
					break;
				}
				case 21:
				{
					bool flag22 = rank >= 12 && player.title.title20 == 1;
					if (flag22)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos3 += 32;
						player.title.title21 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
					}
					break;
				}
				case 22:
				{
					bool flag23 = rank >= 17 && player.title.title21 == 1;
					if (flag23)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos3 += 64;
						player.title.title22 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(200004011, 0, player.getPlayerId(), "P90 Ext. 10U", 10, 1, player));
					}
					break;
				}
				case 23:
				{
					bool flag24 = rank >= 21 && player.title.title22 == 1 && player.title.title42 == 1;
					if (flag24)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos3 += 128;
						player.title.title23 = 1;
						TitleManager.getInstance().UpdateTitles3(player.getPlayerId(), player.title.title16, player.title.title17, player.title.title18, player.title.title19, player.title.title20, player.title.title21, player.title.title22, player.title.title23);
						TitleManager.getInstance().UpdatePosTitles3(player.getPlayerId(), player.title.titlePos3);
					}
					break;
				}
				case 24:
				{
					bool flag25 = rank >= 26 && player.title.title23 == 1;
					if (flag25)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos4++;
						player.title.title24 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(200004013, 0, player.getPlayerId(), "Kriss S.V 10U", 10, 1, player));
					}
					break;
				}
				case 25:
				{
					bool flag26 = rank >= 31 && player.title.title24 == 1;
					if (flag26)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos4 += 2;
						player.title.title25 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1103003002, 0, player.getPlayerId(), "Boina SMG", 10, 0, player));
					}
					break;
				}
				case 26:
				{
					bool flag27 = rank >= 8 && player.title.title5 == 1;
					if (flag27)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 4;
						player.title.title26 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(702015001, 0, player.getPlayerId(), "Dual Knife 10U", 10, 1, player));
					}
					break;
				}
				case 27:
				{
					bool flag28 = rank >= 12 && player.title.title26 == 1;
					if (flag28)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 8;
						player.title.title27 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
					}
					break;
				}
				case 28:
				{
					bool flag29 = rank >= 17 && player.title.title27 == 1;
					if (flag29)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 16;
						player.title.title28 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(702001004, 0, player.getPlayerId(), "Amok Kukri 10U", 10, 1, player));
					}
					break;
				}
				case 29:
				{
					bool flag30 = rank >= 31 && player.title.title28 == 1;
					if (flag30)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 32;
						player.title.title29 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(702001007, 0, player.getPlayerId(), "Mini Axe 10U", 10, 1, player));
					}
					break;
				}
				case 30:
				{
					bool flag31 = rank >= 8 && player.title.title6 == 1;
					if (flag31)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 64;
						player.title.title30 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(601013001, 0, player.getPlayerId(), "P99&HAK 10U", 10, 1, player));
					}
					break;
				}
				case 31:
				{
					bool flag32 = rank >= 12 && player.title.title30 == 1;
					if (flag32)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos4 += 128;
						player.title.title31 = 1;
						TitleManager.getInstance().UpdateTitles4(player.getPlayerId(), player.title.title24, player.title.title25, player.title.title26, player.title.title27, player.title.title28, player.title.title29, player.title.title30, player.title.title31);
						TitleManager.getInstance().UpdatePosTitles4(player.getPlayerId(), player.title.titlePos4);
					}
					break;
				}
				case 32:
				{
					bool flag33 = rank >= 17 && player.title.title31 == 1;
					if (flag33)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5++;
						player.title.title32 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(601014001, 0, player.getPlayerId(), "Dual Handgun 10U", 10, 1, player));
					}
					break;
				}
				case 33:
				{
					bool flag34 = rank >= 26 && player.title.title32 == 1;
					if (flag34)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 2;
						player.title.title33 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(601014002, 0, player.getPlayerId(), "Dual D-Eagle 10U", 10, 1, player));
					}
					break;
				}
				case 34:
				{
					bool flag35 = rank >= 31 && player.title.title33 == 1;
					if (flag35)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 4;
						player.title.title34 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1103003005, 0, player.getPlayerId(), "Boina de Pistoleiro", 10, 0, player));
					}
					break;
				}
				case 35:
				{
					bool flag36 = rank >= 8 && player.title.title7 == 1;
					if (flag36)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 8;
						player.title.title35 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(400006004, 0, player.getPlayerId(), "870MCS W. 10U", 10, 1, player));
					}
					break;
				}
				case 36:
				{
					bool flag37 = rank >= 12 && player.title.title35 == 1;
					if (flag37)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 16;
						player.title.title36 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
					}
					break;
				}
				case 37:
				{
					bool flag38 = rank >= 17 && player.title.title36 == 1;
					if (flag38)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos5 += 32;
						player.title.title37 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(400006003, 0, player.getPlayerId(), "SPAS-15 10U", 10, 1, player));
					}
					break;
				}
				case 38:
				{
					bool flag39 = rank >= 26 && player.title.title37 == 1;
					if (flag39)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 64;
						player.title.title38 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(400006003, 0, player.getPlayerId(), "SPAS15 10U", 10, 1, player));
					}
					break;
				}
				case 39:
				{
					bool flag40 = rank >= 31 && player.title.title38 == 1;
					if (flag40)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos5 += 128;
						player.title.title39 = 1;
						TitleManager.getInstance().UpdateTitles5(player.getPlayerId(), player.title.title32, player.title.title33, player.title.title34, player.title.title35, player.title.title36, player.title.title37, player.title.title38, player.title.title39);
						TitleManager.getInstance().UpdatePosTitles5(player.getPlayerId(), player.title.titlePos5);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(1103003004, 0, player.getPlayerId(), "Boina de Shotgun", 10, 0, player));
					}
					break;
				}
				case 40:
				{
					bool flag41 = rank >= 8 && player.title.title7 == 1;
					if (flag41)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos6++;
						player.title.title40 = 1;
						TitleManager.getInstance().UpdateTitles6(player.getPlayerId(), player.title.title40, player.title.title41, player.title.title42, player.title.title43, player.title.title44);
						TitleManager.getInstance().UpdatePosTitles6(player.getPlayerId(), player.title.titlePos6);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(803007004, 0, player.getPlayerId(), "C-5 10U", 10, 1, player));
					}
					break;
				}
				case 41:
				{
					bool flag42 = rank >= 12 && player.title.title40 == 1;
					if (flag42)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos6 += 2;
						player.title.title41 = 1;
						TitleManager.getInstance().UpdateTitles6(player.getPlayerId(), player.title.title40, player.title.title41, player.title.title42, player.title.title43, player.title.title44);
						TitleManager.getInstance().UpdatePosTitles6(player.getPlayerId(), player.title.titlePos6);
					}
					break;
				}
				case 42:
				{
					bool flag43 = rank >= 17 && player.title.title41 == 1;
					if (flag43)
					{
						num2 = 2;
						num = 0;
						player.title.titlePos6 += 4;
						player.title.title42 = 1;
						TitleManager.getInstance().UpdateTitles6(player.getPlayerId(), player.title.title40, player.title.title41, player.title.title42, player.title.title43, player.title.title44);
						TitleManager.getInstance().UpdatePosTitles6(player.getPlayerId(), player.title.titlePos6);
						player.sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(904007005, 0, player.getPlayerId(), "WP Smoke 10U", 10, 1, player));
					}
					break;
				}
				case 43:
				{
					bool flag44 = rank >= 21 && player.title.title42 == 1;
					if (flag44)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos6 += 8;
						player.title.title43 = 1;
						TitleManager.getInstance().UpdateTitles6(player.getPlayerId(), player.title.title40, player.title.title41, player.title.title42, player.title.title43, player.title.title44);
						TitleManager.getInstance().UpdatePosTitles6(player.getPlayerId(), player.title.titlePos6);
					}
					break;
				}
				case 44:
				{
					bool flag45 = rank >= 31 && player.title.title43 == 1;
					if (flag45)
					{
						num2 = 3;
						num = 0;
						player.title.titlePos6 += 16;
						player.title.title44 = 1;
						TitleManager.getInstance().UpdateTitles6(player.getPlayerId(), player.title.title40, player.title.title41, player.title.title42, player.title.title43, player.title.title44);
						TitleManager.getInstance().UpdatePosTitles6(player.getPlayerId(), player.title.titlePos6);
					}
					break;
				}
				}
			}
			bool flag46 = base.getClient().getPlayer().getTitleSlotCount() > num2;
			if (flag46)
			{
				num2 = base.getClient().getPlayer().getTitleSlotCount();
			}
			else
			{
				base.getClient().getPlayer().setTitleSlotCount(num2);
				AccountManager.getInstance().UpdateTitleSlotCount(base.getClient().getPlayerId(), base.getClient().getPlayer().getTitleSlotCount());
			}
			base.getClient().sendPacket(new PROTOCOL_TITLE_GET_ACK(num, num2));
			bool flag47 = num == 0;
			if (flag47)
			{
				CLogger.getInstance().info("[Title] " + base.getClient().getPlayer().getPlayerName().ToString() + " acquired a title.");
			}
			else
			{
				CLogger.getInstance().info("[Title] " + base.getClient().getPlayer().getPlayerName().ToString() + " tried to get a title.");
			}
		}
	}
}
