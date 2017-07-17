using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BATTLE_SENDPING_REQ : ReceiveBaseGamePacket
	{
		private byte[] slots;

		public PROTOCOL_BATTLE_SENDPING_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.slots = base.readB(16);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				Room room = player.getRoom();
				int num = 0;
				bool flag2 = room != null;
				if (flag2)
				{
					for (int i = 0; i < 16; i++)
					{
						Account playerBySlot = room.getPlayerBySlot(i);
						bool flag3 = playerBySlot != null;
						if (flag3)
						{
							playerBySlot.sendPacket(new PROTOCOL_BATTLE_SENDPING_ACK(this.slots));
							bool flag4 = playerBySlot.getRoom().getSlotState(playerBySlot.getSlot()) == SLOT_STATE.SLOT_STATE_LOAD || playerBySlot.getRoom().getSlotState(playerBySlot.getSlot()) == SLOT_STATE.SLOT_STATE_RENDEZVOUS || playerBySlot.getRoom().getSlotState(playerBySlot.getSlot()) == SLOT_STATE.SLOT_STATE_PRESTART;
							if (flag4)
							{
								num++;
							}
						}
					}
					bool flag5 = num == 0;
					if (flag5)
					{
						player.getRoom().ChangeRoomState(ROOM_STATE.ROOM_STATE_BATTLE, player);
					}
				}
			}
		}
	}
}
