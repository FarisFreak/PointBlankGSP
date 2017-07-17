using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_INVENTORY_ITEM_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_INVENTORY_ITEM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_INVENTORY_ITEM_ACK());
		}
	}
}
