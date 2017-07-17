using PBServer.network.serverpackets;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_INVENTORY_ENTER_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_INVENTORY_ENTER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				GameClient client = base.getClient();
				bool flag2 = client.getPlayer() != null && client.getPlayer().getRoom() != null;
				if (flag2)
				{
					client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_INVENTORY, true);
				}
				GameClient client2 = base.getClient();
				int playerId = client2.getPlayerId();
				client.sendPacket(new PROTOCOL_INVENTORY_ENTER_ACK(playerId, client2));
				CLogger.getInstance().info("[Inventory] " + base.getClient().getPlayer().getPlayerName().ToString() + " entered inventory.");
			}
		}
	}
}
