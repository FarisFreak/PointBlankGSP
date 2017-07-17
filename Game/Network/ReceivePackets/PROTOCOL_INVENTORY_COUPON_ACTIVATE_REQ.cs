using Network.SendPackets;
using PBServer;
using PBServer.network;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace Network.ReceivePackets
{
	internal class PROTOCOL_INVENTORY_COUPON_ACTIVATE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_INVENTORY_COUPON_ACTIVATE_REQ(GameClient Client, byte[] buff)
		{
			base.makeme(Client, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient().getPlayer() != null;
			if (flag)
			{
				Room room = base.getClient().getPlayer().getRoom();
				bool flag2 = room != null;
				if (flag2)
				{
					room.getRoomSlotByPlayer(base.getClient().getPlayer()).setState(SLOT_STATE.SLOT_STATE_INFO);
					foreach (Account current in base.getClient().getPlayer().getRoom().getAllPlayers())
					{
						current.getClient().sendPacket(new PROTOCOL_ROOM_GET_SLOTINFO_ACK(room));
					}
				}
			}
			base.getClient().getPlayer().sendPacket(new PROTOCOL_INVENTORY_COUPON_ACTIVATE_ACK());
		}
	}
}
