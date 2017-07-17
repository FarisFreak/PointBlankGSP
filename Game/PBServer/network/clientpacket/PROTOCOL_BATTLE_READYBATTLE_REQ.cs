using PBServer.network.BattleConnect;
using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BATTLE_READYBATTLE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_READYBATTLE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
			Room room = base.getClient().getPlayer().getRoom();
			Account player = base.getClient().getPlayer();
			Account playerFromPlayerId = channel.getPlayerFromPlayerId(base.getClient().getPlayer().getRoom().getLeader().player_id);
			bool flag = room.getLeader().player_id == base.getClient().getPlayer().player_id;
			if (flag)
			{
				bool flag2 = room.isBattleInt() == 0;
				if (flag2)
				{
					room.setFigth(1);
					room.setTimeLost(room.getTimeByMask() * 60);
				}
				player.getRoom().changeSlotState(base.getClient().getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_LOAD, true);
				for (int i = 0; i < 16; i++)
				{
					int playerId = room.getSlot(i)._playerId;
					bool flag3 = playerId > 0;
					if (flag3)
					{
						Account playerFromPlayerId2 = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId);
						bool flag4 = playerFromPlayerId2 != null;
						if (flag4)
						{
							bool flag5 = channel.getRoomInId(room.getRoomId()).getSlotState(i) == SLOT_STATE.SLOT_STATE_READY;
							if (flag5)
							{
								channel.getRoomInId(room.getRoomId()).changeSlotState(i, SLOT_STATE.SLOT_STATE_LOAD, true);
							}
							room.setState(ROOM_STATE.ROOM_STATE_LOADING);
							playerFromPlayerId2.CheckCorrectInventory();
							playerFromPlayerId2.sendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(playerFromPlayerId2, room));
						}
					}
				}
				bool flag6 = base.getClient().getPlayer().getRoom().getLeader().player_id == base.getClient().getPlayer().player_id && base.getClient().getPlayer().getRoom().server_type > 1;
				if (flag6)
				{
					bool flag7 = base.getClient().getPlayer().customAddress == null;
					if (flag7)
					{
						UdpHandler.getInstance().CreateBattleUdpRoom(base.getClient().getPlayer().getRoom(), base.getClient().getPlayer().getRoom().server_type);
					}
					else
					{
						UdpHandler.getInstance().CreateBattleUdpRoom(base.getClient().getPlayer().getRoom(), base.getClient().getPlayer().getRoom().server_type);
					}
				}
			}
			else
			{
				bool flag8 = room.getSlotState(playerFromPlayerId.getSlot()) == SLOT_STATE.SLOT_STATE_PRESTART || room.getSlotState(playerFromPlayerId.getSlot()) == SLOT_STATE.SLOT_STATE_RENDEZVOUS || room.getSlotState(playerFromPlayerId.getSlot()) == SLOT_STATE.SLOT_STATE_LOAD || room.getSlotState(playerFromPlayerId.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE_READY || room.getSlotState(playerFromPlayerId.getSlot()) == SLOT_STATE.SLOT_STATE_BATTLE;
				if (flag8)
				{
					ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(room.getSlot(player.getSlot())._playerId).getRoom().changeSlotState(base.getClient().getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_LOAD, true);
					player.sendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(player, room));
					UdpHandler.getInstance().AddPlayerInUdpRoom(player, room.getLeader());
				}
				else
				{
					int playerId = room.getSlot(player.getSlot())._playerId;
					int slot = base.getClient().getPlayer().getSlot();
					bool flag9 = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId).getRoom().getSlotState(slot) == SLOT_STATE.SLOT_STATE_NORMAL;
					if (flag9)
					{
						ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId).getRoom().changeSlotState(slot, SLOT_STATE.SLOT_STATE_READY, true);
					}
					else
					{
						bool flag10 = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId).getRoom().getSlotState(slot) == SLOT_STATE.SLOT_STATE_READY;
						if (flag10)
						{
							ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId).getRoom().changeSlotState(slot, SLOT_STATE.SLOT_STATE_NORMAL, true);
						}
					}
				}
			}
			foreach (Account current in base.getClient().getPlayer().getRoom().getReadyPlayerList())
			{
				current.getClient().sendPacket(new PROTOCOL_ROOM_GET_SLOTINFO_ACK(room));
			}
			player.getRoom().updateInfo();
		}
	}
}
