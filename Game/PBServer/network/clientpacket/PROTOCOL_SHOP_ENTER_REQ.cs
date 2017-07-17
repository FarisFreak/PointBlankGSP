using PBServer.network.serverpackets;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_SHOP_ENTER_REQ : ReceiveBaseGamePacket
	{
		private int _v;

		public PROTOCOL_SHOP_ENTER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this._v = base.readD();
		}

		protected internal override void run()
		{
			CLogger.getInstance().info("[Shop] " + base.getClient().getPlayer().getPlayerName().ToString() + " entered the shop.");
			bool flag = base.getClient() != null;
			if (flag)
			{
				GameClient client = base.getClient();
				bool flag2 = client.getPlayer() != null && client.getPlayer().getRoom() != null;
				if (flag2)
				{
					client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_SHOP, true);
				}
				client.sendPacket(new PROTOCOL_SHOP_ENTER_ACK());
			}
		}
	}
}
