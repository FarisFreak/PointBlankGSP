using PBServer.network.serverpackets;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_CS_CLIENT_LEAVE_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_CS_CLIENT_LEAVE_REQ(GameClient Client, byte[] data)
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
				client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
			}
			client.sendPacket(new PROTOCOL_CS_CLIENT_LEAVE_ACK());
			CLogger.getInstance().info("[Clan] " + base.getClient().getPlayer().getPlayerName().ToString() + " leaves the clan screen.");
		}
	}
}
