using PBServer;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK : SendBaseGamePacket
	{
		private Room room;

		private Account account;

		public PROTOCOL_BATTLE_LEAVEP2PSERVER_ACK(Room _room, Account _account)
		{
			this.room = _room;
			this.account = _account;
		}

		protected internal override void write()
		{
			base.writeH(3347);
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
						base.writeB(this.room.getLeader().publicAdddress());
						base.writeH(29890);
						base.writeB(playerBySlot.publicAdddress());
						base.writeH(29890);
						base.writeC(0);
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
