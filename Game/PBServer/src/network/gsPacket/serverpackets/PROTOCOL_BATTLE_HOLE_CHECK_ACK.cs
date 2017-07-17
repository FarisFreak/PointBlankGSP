using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.src.network.gsPacket.serverpackets
{
	internal class PROTOCOL_BATTLE_HOLE_CHECK_ACK : SendBaseGamePacket
	{
		private Room room;

		public PROTOCOL_BATTLE_HOLE_CHECK_ACK(Room room)
		{
			base.makeme();
			this.room = room;
		}

		protected internal override void write()
		{
			base.writeH(3330);
			bool flag = this.room != null;
			if (flag)
			{
				base.writeD(this.room.getLeader().getSlot());
				for (int i = 0; i < 16; i++)
				{
					Account playerBySlot = this.room.getPlayerBySlot(i);
					bool flag2 = playerBySlot != null;
					if (flag2)
					{
						bool flag3 = playerBySlot.getRoom().getSlotState(i) == SLOT_STATE.SLOT_STATE_BATTLE || playerBySlot.getRoom().getSlotState(i) == SLOT_STATE.SLOT_STATE_PRESTART;
						if (flag3)
						{
							this.room.setNewLeader(i);
							base.writeB(playerBySlot.publicAdddress());
							base.writeH(29890);
							base.writeB(playerBySlot.publicAdddress());
							base.writeH(29890);
							base.writeC(0);
						}
					}
					else
					{
						base.writeB(new byte[13]);
					}
				}
			}
		}
	}
}
