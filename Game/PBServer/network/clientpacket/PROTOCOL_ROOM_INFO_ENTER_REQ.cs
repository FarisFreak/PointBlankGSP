using PBServer.network.serverpackets;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_ROOM_INFO_ENTER_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_ROOM_INFO_ENTER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
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
				client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_INFO, true);
			}
			client.sendPacket(new PROTOCOL_ROOM_INFO_ENTER_ACK());
			CLogger.getInstance().info("[Profile] " + base.getClient().getPlayer().getPlayerName().ToString() + " entered in the profile.");
		}
	}
}
