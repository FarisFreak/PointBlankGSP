using PBServer.network;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	internal class PROTOCOL_BATTLE_PRESTARTBATTLE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_PRESTARTBATTLE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = base.getClient() != null;
			if (flag)
			{
				player.getRoom().setState(ROOM_STATE.ROOM_STATE_PRE_BATTLE);
				player.getRoom().changeSlotState(base.getClient().getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_PRESTART, true);
				player.sendPacket(new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(player.getRoom()));
				bool flag2 = player.getRoom().server_type == 1 && player.getRoom().server_type == 2 && player.getRoom().server_type == 3;
				if (flag2)
				{
					Account[] array = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(player.getRoom().getRoomId()).getAllPlayers().ToArray();
					for (int i = 0; i < array.Length; i++)
					{
						Account account = array[i];
						bool flag3 = account.getRoom().getSlot(account.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
						if (flag3)
						{
							player.sendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(account));
						}
					}
					bool flag4 = player.player_id != player.getRoom().getLeader().player_id;
					if (flag4)
					{
						player.getRoom().getLeader().sendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(player));
					}
				}
				else
				{
					bool flag5 = player.player_id == player.getRoom().getLeader().player_id;
					if (flag5)
					{
						player.sendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(player));
						Account[] array2 = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(player.getRoom().getRoomId()).getAllPlayers().ToArray();
						for (int j = 0; j < array2.Length; j++)
						{
							Account account2 = array2[j];
							bool flag6 = account2.player_id != player.player_id && account2.getRoom().getSlot(account2.getSlot()).state == SLOT_STATE.SLOT_STATE_PRESTART;
							if (flag6)
							{
								player.sendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(account2));
							}
						}
					}
					else
					{
						player.sendPacket(new PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(player));
					}
				}
			}
		}
	}
}
