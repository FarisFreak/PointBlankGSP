using PBServer.network;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	internal class PROTOCOL_BATTLE_STARTBATTLE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_STARTBATTLE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			SLOT roomSlotByPlayer = room.getRoomSlotByPlayer(base.getClient().getPlayer());
			base.getClient().sendPacket(new PROTOCOL_BATTLE_AI_COLLISION_ACK(room));
			base.getClient().sendPacket(new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(room));
			bool flag = room.getSlotState(player.getSlot()) == SLOT_STATE.SLOT_STATE_PRESTART;
			if (flag)
			{
				room.changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_BATTLE_READY, true);
			}
			room.RoomTask(room);
			bool flag2 = room.special != 6;
			if (flag2)
			{
				base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(240, 1));
			}
		}
	}
}
