using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_ROOM_INFO_LEAVE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_ROOM_INFO_LEAVE_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			GameClient client = base.getClient();
			bool flag = client.getPlayer() != null && client.getPlayer().getRoom() != null;
			if (flag)
			{
				client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
			}
			client.sendPacket(new PROTOCOL_ROOM_INFO_LEAVE_ACK());
			CLogger.getInstance().info("[Profile] " + base.getClient().getPlayer().getPlayerName().ToString() + " out profile.");
		}
	}
}
