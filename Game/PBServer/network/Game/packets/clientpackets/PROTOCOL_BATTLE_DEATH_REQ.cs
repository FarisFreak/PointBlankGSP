using PBServer.model;
using PBServer.model.ENUMS;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;
using System.Threading;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_DEATH_REQ : ReceiveBaseGamePacket
	{
		private FragInfos _kills;

		private int TeamWin = -1;

		public PROTOCOL_BATTLE_DEATH_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			this._kills = new FragInfos();
			int num = (int)base.readH();
			this._kills.victimIdx = (int)base.readC();
			this._kills.killsCount = (int)base.readC();
			this._kills.killerIdx = (int)base.readC();
			this._kills.weapon = base.readD();
			this._kills.bytes13 = base.readB(13);
			int num2 = this._kills.killsCount - 1;
			for (int i = 0; i <= num2; i++)
			{
				Frag item = new Frag
				{
					unk_c_1 = (int)base.readC(),
					hitspotNum = (int)base.readC(),
					unk_c_3 = (int)base.readC(),
					unk_c_4 = (int)base.readC(),
					bytes131 = base.readB(13)
				};
				this._kills.frags.Add(item);
			}
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				Room room = player.getRoom();
				bool flag2 = room != null;
				if (flag2)
				{
					SLOT sLOT = room.getSlots()[this._kills.killerIdx];
					int num = this._kills.weapon / 100000;
					sLOT.killMessage = 0;
					int num2 = this._kills.killsCount - 1;
					for (int i = 0; i <= num2; i++)
					{
						Frag frag = this._kills.frags[i];
						bool flag3 = this._kills.killsCount > 1;
						if (flag3)
						{
							int num3 = (num == 8030) ? 0 : ((num != 9030) ? 1 : 0);
							sLOT.killMessage = ((num3 != 0) ? 1 : 2);
						}
						else
						{
							int num3 = 0;
							bool flag4 = frag.hitspotNum >> 4 == 3;
							if (flag4)
							{
								num3 = 4;
							}
							else
							{
								bool flag5 = frag.hitspotNum >> 4 == 1 && frag.hitspotNum % 2 == 1 && num == 7020;
								if (flag5)
								{
									num3 = 6;
								}
							}
							bool flag6 = num3 > 0;
							if (flag6)
							{
								int num4 = sLOT.lastKillState >> 12;
								int num5 = num3;
								if (num5 != 0)
								{
									if (num5 != 4)
									{
										if (num5 == 6)
										{
											bool flag7 = num4 != 6;
											if (flag7)
											{
												sLOT.repeatLastState = false;
											}
											int num6 = sLOT.killsOnLife + 1;
											sLOT.lastKillState = (num3 << 12 | num6);
											int num7 = sLOT.lastKillState & 15;
											bool repeatLastState = sLOT.repeatLastState;
											if (repeatLastState)
											{
												bool flag8 = num7 > 1;
												if (flag8)
												{
													sLOT.killMessage = 6;
												}
											}
											else
											{
												sLOT.repeatLastState = true;
											}
										}
									}
									else
									{
										bool flag9 = num4 != 4;
										if (flag9)
										{
											sLOT.repeatLastState = false;
										}
										int num6 = sLOT.killsOnLife + 1;
										sLOT.lastKillState = (num3 << 12 | num6);
										int num7 = sLOT.lastKillState & 15;
										bool repeatLastState2 = sLOT.repeatLastState;
										if (repeatLastState2)
										{
											sLOT.killMessage = ((num7 <= 1) ? 4 : 5);
										}
										else
										{
											sLOT.killMessage = 4;
											sLOT.repeatLastState = true;
										}
									}
								}
								else
								{
									bool flag10 = sLOT.killsOnLife == 1;
									if (flag10)
									{
										this._kills.Message = 3;
									}
									else
									{
										bool flag11 = sLOT.killsOnLife == 2;
										if (flag11)
										{
											this._kills.Message = 3;
										}
									}
								}
							}
							else
							{
								sLOT.lastKillState = 0;
								sLOT.repeatLastState = false;
							}
						}
						SLOT sLOT2 = room.getSlots()[frag.getDeatSlot()];
						sLOT2.allDeaths++;
						sLOT2.killMessage = 0;
						sLOT2.lastKillState = 0;
						sLOT2.resetkillsOnLife();
						sLOT2.repeatLastState = false;
						bool flag12 = this._kills.killerIdx != frag.getDeatSlot();
						if (flag12)
						{
							sLOT.allKills++;
							sLOT.killsOnLife++;
						}
						bool flag13 = frag.getDeatSlot() % 2 == 0 && frag.getDeatSlot() != this._kills.killerIdx;
						if (flag13)
						{
							room.addDeaths(TeamEnum.CHARACTER_TEAM_RED);
							room.addKills(TeamEnum.CHARACTER_TEAM_BLUE);
						}
						else
						{
							bool flag14 = frag.getDeatSlot() % 2 != 0 && frag.getDeatSlot() != this._kills.killerIdx;
							if (flag14)
							{
								room.addDeaths(TeamEnum.CHARACTER_TEAM_BLUE);
								room.addKills(TeamEnum.CHARACTER_TEAM_RED);
							}
						}
					}
					bool flag15 = sLOT.killMessage == 4 || sLOT.killMessage == 5;
					if (flag15)
					{
						sLOT.headshotsInPlay++;
					}
					bool flag16 = room.special == 6;
					if (flag16)
					{
						bool flag17 = player.getSlot() % 2 == 0;
						if (flag17)
						{
							SLOT slot = room.getSlot(this._kills.killerIdx);
							slot.botScore += 5 + room.getSlot(this._kills.killerIdx).killsOnLife * room._aiLevel;
						}
						else
						{
							SLOT slot2 = room.getSlot(this._kills.killerIdx);
							slot2.botScore += 5 + room.getSlot(this._kills.killerIdx).killsOnLife * room._aiLevel;
						}
					}
					for (int j = 0; j < room.getSlots().Length; j++)
					{
						int playerId = room.getSlot(j)._playerId;
						bool flag18 = playerId > 0;
						if (flag18)
						{
							Account playerFromPlayerId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId);
							bool flag19 = playerFromPlayerId != null;
							if (flag19)
							{
								playerFromPlayerId.sendPacket(new PROTOCOL_BATTLE_DEATH_ACK(playerFromPlayerId, this._kills));
							}
						}
					}
					bool flag20 = room.special != 6;
					if (flag20)
					{
						SLOT slot3 = room.getSlot(this._kills.killerIdx);
						bool flag21 = base.getClient().getPlayer() == slot3.getPlayer();
						if (flag21)
						{
							for (int k = 0; k < this._kills.killsCount; k++)
							{
								base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(242, 1));
							}
							bool flag22 = slot3.getKillMessage() == 7;
							if (flag22)
							{
								base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(243, 1));
							}
							bool flag23 = slot3.getKillMessage() == 8;
							if (flag23)
							{
								base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(243, 1));
							}
							bool flag24 = slot3.getKillMessage() == 9;
							if (flag24)
							{
								base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(243, 1));
							}
						}
						bool flag25 = sLOT == room.getRoomSlotByPlayer(base.getClient().getPlayer());
						if (flag25)
						{
							base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(241, 1));
						}
						bool flag26 = room.room_type == 2;
						if (flag26)
						{
							bool flag27 = room.getBlueKills() == room.redTeamCount;
							if (flag27)
							{
								this.TeamWin = 1;
							}
							else
							{
								bool flag28 = room.getRedKills() == room.blueTeamCount;
								if (flag28)
								{
									this.TeamWin = 0;
								}
							}
						}
						bool flag29 = room.room_type == 4;
						if (flag29)
						{
							bool flag30 = room.getBlueKills() == room.redTeamCount;
							if (flag30)
							{
								this.TeamWin = 1;
							}
							else
							{
								bool flag31 = room.getRedKills() == room.blueTeamCount;
								if (flag31)
								{
									this.TeamWin = 0;
								}
							}
						}
					}
				}
				bool flag32 = this.TeamWin >= 0;
				if (flag32)
				{
					bool flag33 = this.TeamWin != 1 || room.getBombState() != 1;
					if (flag33)
					{
						room.setRedKills(0);
						room.setBlueKills(0);
						bool flag34 = this.TeamWin == 1;
						if (flag34)
						{
							room.setBlueWinRounds(room.getBlueWinRounds() + 1);
						}
						else
						{
							room.setRedWinRounds(room.getRedWinRounds() + 1);
						}
						bool flag35 = Math.Max(room.getRedWinRounds(), room.getBlueWinRounds()) >= room.getKillsByMask();
						if (flag35)
						{
							foreach (Account current in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								SLOT roomSlotByPlayer = room.getRoomSlotByPlayer(current);
								current.getClient().sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current));
								roomSlotByPlayer.setKillMessage(0);
								roomSlotByPlayer.setLastKillMessage(0);
								roomSlotByPlayer.setOneTimeKills(0);
								roomSlotByPlayer.setAllKills(0);
								roomSlotByPlayer.setAllDeahts(0);
							}
							room.setRedKills(0);
							room.setRedDeaths(0);
							room.setBlueKills(0);
							room.setBlueDeaths(0);
							room.setFigth(0);
							room.setBlueWinRounds(0);
							room.setRedWinRounds(0);
							room.setBombState(0);
						}
						else
						{
							foreach (Account current2 in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								SLOT roomSlotByPlayer2 = room.getRoomSlotByPlayer(current2);
								roomSlotByPlayer2.setKillMessage(0);
								roomSlotByPlayer2.setLastKillMessage(0);
								roomSlotByPlayer2.setOneTimeKills(0);
								roomSlotByPlayer2.lastKillState = 0;
								room.setRedKills(0);
								room.setRedDeaths(0);
								room.setBlueKills(0);
								room.setBlueDeaths(0);
								room.setBombState(0);
								current2.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(this.TeamWin, this.TeamWin, base.getClient().getPlayer().getRoom()));
							}
							Thread.Sleep(8000);
							foreach (Account current3 in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								current3.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(current3.getRoom()));
							}
						}
					}
					this.TeamWin = -1;
				}
			}
		}
	}
}
