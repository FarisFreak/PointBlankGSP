using PBServer.network;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	public class PROTOCOL_BATTLE_TIMERSYNC_REQ : ReceiveBaseGamePacket
	{
		private int _timeLost;

		private int battle = 1;

		private int unkC1;

		private int unkC2;

		private int unkD;

		public PROTOCOL_BATTLE_TIMERSYNC_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._timeLost = base.readD();
			this.unkD = base.readD();
			this.unkC1 = (int)base.readC();
			this.unkC2 = (int)base.readC();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				Room room = player.getRoom();
				room.setTimeLost(room.getTimeByMask() * 60);
				bool flag2 = this._timeLost < 1 && player.player_id == room.getLeader().player_id;
				if (flag2)
				{
					room.setState(ROOM_STATE.ROOM_STATE_BATTLE_END);
					foreach (Account current in room.getAllPlayers())
					{
						switch (room.getSlotState(current.getSlot()))
						{
						case SLOT_STATE.SLOT_STATE_LOAD:
						case SLOT_STATE.SLOT_STATE_RENDEZVOUS:
						case SLOT_STATE.SLOT_STATE_PRESTART:
						case SLOT_STATE.SLOT_STATE_BATTLE_READY:
						case SLOT_STATE.SLOT_STATE_BATTLE:
						{
							bool flag3 = this.battle == 1;
							if (flag3)
							{
								room.CalculateBattleResult(current);
								this.battle = 2;
							}
							current.sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current));
							break;
						}
						}
					}
					foreach (Account current2 in player.getRoom().getAllPlayers())
					{
						bool flag4 = current2.getSlot() == room.getLeader().getSlot();
						if (flag4)
						{
							for (int i = 0; i < 16; i++)
							{
								bool flag5 = room._slots[i].state == SLOT_STATE.SLOT_STATE_BATTLE || room._slots[i].state == SLOT_STATE.SLOT_STATE_PRESTART;
								if (flag5)
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
						}
					}
				}
			}
		}
	}
}
