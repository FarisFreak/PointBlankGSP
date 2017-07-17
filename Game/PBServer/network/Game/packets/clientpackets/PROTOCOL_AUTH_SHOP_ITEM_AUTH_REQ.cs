using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ : ReceiveBaseGamePacket
	{
		private int error;

		public PROTOCOL_AUTH_SHOP_ITEM_AUTH_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.error = base.readD();
		}

		protected internal override void run()
		{
			bool flag = this.error == 0;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_ITEMLIST_ACK());
				base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_GOODSLIST_ACK());
				base.getClient().sendPacket(new PROTOCOL_SHOP_TEST_1_ACK());
				base.getClient().sendPacket(new PROTOCOL_SHOP_TEST_2_ACK());
				base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK());
			}
			base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK());
		}
	}
}
