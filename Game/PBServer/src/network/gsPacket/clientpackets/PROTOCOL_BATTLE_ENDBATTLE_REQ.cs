using PBServer.network;
using PBServer.network.BattleConnect;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	public class PROTOCOL_BATTLE_ENDBATTLE_REQ : ReceiveBaseGamePacket
	{
		private int itemid;

		public PROTOCOL_BATTLE_ENDBATTLE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.itemid = base.readD();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			CLogger.getInstance().info("[Battle] " + player.getPlayerName() + " It came out during the match.");
			player._statistic.setEscapes(player._statistic.getEscapes_s() + 1);
			AccountManager.getInstance().updateEscapes(player);
			UdpHandler.getInstance().RemovePlayerInRoom(player);
			bool flag = player.getSlot() == player.getRoom().getLeader().getSlot() && player.getRoom().getReadyPlayerList().Count == 1;
			if (flag)
			{
				for (int i = 0; i < 16; i++)
				{
					bool flag2 = room._slots[i].state == SLOT_STATE.SLOT_STATE_BATTLE || room._slots[i].state == SLOT_STATE.SLOT_STATE_PRESTART;
					if (flag2)
					{
						room.changeSlotState(i, SLOT_STATE.SLOT_STATE_NORMAL, true);
					}
					room._slots[i].allDeaths = 0;
					room._slots[i].allKills = 0;
					room._slots[i].killMessage = 0;
					room._slots[i].killsOnLife = 0;
					room._slots[i].lastKillState = 0;
					room._slots[i].repeatLastState = false;
					room._slots[i].botScore = 0;
					room._slots[i].headshotsInPlay = 0;
				}
				room._redKills = 0;
				room._redDeaths = 0;
				room._blueKills = 0;
				room._blueDeaths = 0;
				room._timeRoom = room.getTimeByMask() * 60;
				room.setState(ROOM_STATE.ROOM_STATE_READY);
				player.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(player));
			}
			else
			{
				bool flag3 = player.getSlot() == player.getRoom().getLeader().getSlot() && player.getRoom().getAllPlayers().Count > 1 && player.getRoom().special == 6;
				if (flag3)
				{
					foreach (Account current in player.getRoom().getAllPlayers())
					{
						bool flag4 = current != null && player.getRoom().getSlotState(current.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE;
						if (flag4)
						{
							bool flag5 = player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE || player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
							if (flag5)
							{
								player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
							}
							player.getRoom().getSlot(player.getSlot()).allDeaths = 0;
							player.getRoom().getSlot(player.getSlot()).allKills = 0;
							player.getRoom().getSlot(player.getSlot()).killMessage = 0;
							player.getRoom().getSlot(player.getSlot()).killsOnLife = 0;
							player.getRoom().getSlot(player.getSlot()).lastKillState = 0;
							player.getRoom().getSlot(player.getSlot()).repeatLastState = false;
							player.getRoom().getSlot(player.getSlot()).botScore = 0;
							player.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(player));
							current.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player.getSlot()));
							bool flag6 = player.getPlayerId() != current.getPlayerId();
							if (flag6)
							{
								current.sendPacket(new PROTOCOL_BATTLE_HOLE_CHECK_ACK(player.getRoom()));
							}
						}
					}
				}
				else
				{
					bool flag7 = player.getSlot() == player.getRoom().getLeader().getSlot() && player.getRoom().getAllPlayers().Count == 2 && player.getRoom().special != 6;
					if (flag7)
					{
						foreach (Account current2 in player.getRoom().getAllPlayers())
						{
							bool flag8 = player.getSlot() != current2.getSlot() && player.getRoom().getSlotState(current2.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE;
							if (flag8)
							{
								CLogger.getInstance().info("[Battle] End of the match to give up eancia.");
								bool flag9 = player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE || player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
								if (flag9)
								{
									player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
								}
								player.getRoom().getSlot(player.getSlot()).allDeaths = 0;
								player.getRoom().getSlot(player.getSlot()).allKills = 0;
								player.getRoom().getSlot(player.getSlot()).killMessage = 0;
								player.getRoom().getSlot(player.getSlot()).killsOnLife = 0;
								player.getRoom().getSlot(player.getSlot()).lastKillState = 0;
								player.getRoom().getSlot(player.getSlot()).repeatLastState = false;
								player.getRoom().getSlot(player.getSlot()).botScore = 0;
								room._redKills = 0;
								room._redDeaths = 0;
								room._blueKills = 0;
								room._blueDeaths = 0;
								room._timeRoom = room.getTimeByMask() * 60;
								room.setState(ROOM_STATE.ROOM_STATE_READY);
								current2.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player.getSlot()));
								current2.sendPacket(new PROTOCOL_BATTLE_HOLE_CHECK_ACK(player.getRoom()));
								player.getRoom().setState(ROOM_STATE.ROOM_STATE_BATTLE_END);
								current2.getRoom().CalculateBattleResult(current2);
								current2.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current2));
							}
						}
					}
					else
					{
						bool flag10 = player.getSlot() != player.getRoom().getLeader().getSlot() && player.getRoom().getAllPlayers().Count == 2 && player.getRoom().special != 6;
						if (flag10)
						{
							foreach (Account current3 in player.getRoom().getAllPlayers())
							{
								bool flag11 = player.getSlot() != current3.getSlot() && player.getRoom().getSlotState(current3.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE;
								if (flag11)
								{
									CLogger.getInstance().info("[Battle] End of the match to give up eancia.");
									bool flag12 = player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE || player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
									if (flag12)
									{
										player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
									}
									player.getRoom().getSlot(player.getSlot()).allDeaths = 0;
									player.getRoom().getSlot(player.getSlot()).allKills = 0;
									player.getRoom().getSlot(player.getSlot()).killMessage = 0;
									player.getRoom().getSlot(player.getSlot()).killsOnLife = 0;
									player.getRoom().getSlot(player.getSlot()).lastKillState = 0;
									player.getRoom().getSlot(player.getSlot()).repeatLastState = false;
									player.getRoom().getSlot(player.getSlot()).botScore = 0;
									room._redKills = 0;
									room._redDeaths = 0;
									room._blueKills = 0;
									room._blueDeaths = 0;
									room._timeRoom = room.getTimeByMask() * 60;
									room.setState(ROOM_STATE.ROOM_STATE_READY);
									current3.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player.getSlot()));
									current3.sendPacket(new PROTOCOL_BATTLE_HOLE_CHECK_ACK(player.getRoom()));
									player.getRoom().setState(ROOM_STATE.ROOM_STATE_BATTLE_END);
									current3.getRoom().CalculateBattleResult(current3);
									current3.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current3));
								}
							}
						}
						else
						{
							bool flag13 = player.getSlot() != player.getRoom().getLeader().getSlot() && player.getRoom().getAllPlayers().Count > 2;
							if (flag13)
							{
								bool flag14 = player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE || player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
								if (flag14)
								{
									player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
								}
								player.getRoom().getSlot(player.getSlot()).allDeaths = 0;
								player.getRoom().getSlot(player.getSlot()).allKills = 0;
								player.getRoom().getSlot(player.getSlot()).killMessage = 0;
								player.getRoom().getSlot(player.getSlot()).killsOnLife = 0;
								player.getRoom().getSlot(player.getSlot()).lastKillState = 0;
								player.getRoom().getSlot(player.getSlot()).repeatLastState = false;
								player.getRoom().getSlot(player.getSlot()).botScore = 0;
								foreach (Account current4 in player.getRoom().getAllPlayers())
								{
									current4.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player.getSlot()));
								}
								player.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(player));
							}
							else
							{
								bool flag15 = player.getSlot() != player.getRoom().getLeader().getSlot() && player.getRoom().getAllPlayers().Count > 1 && player.getRoom().special == 6;
								if (flag15)
								{
									foreach (Account current5 in player.getRoom().getAllPlayers())
									{
										bool flag16 = current5 != null && player.getRoom().getSlotState(current5.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE;
										if (flag16)
										{
											bool flag17 = player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE || player.getRoom().getSlot(player.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
											if (flag17)
											{
												player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
											}
											player.getRoom().getSlot(player.getSlot()).allDeaths = 0;
											player.getRoom().getSlot(player.getSlot()).allKills = 0;
											player.getRoom().getSlot(player.getSlot()).killMessage = 0;
											player.getRoom().getSlot(player.getSlot()).killsOnLife = 0;
											player.getRoom().getSlot(player.getSlot()).lastKillState = 0;
											player.getRoom().getSlot(player.getSlot()).repeatLastState = false;
											player.getRoom().getSlot(player.getSlot()).botScore = 0;
											player.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(player));
											current5.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(player.getSlot()));
										}
									}
								}
								else
								{
									CLogger.getInstance().info("[Batte] Failure to remove the player.");
								}
							}
						}
					}
				}
			}
		}
	}
}
