using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(543);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
		}
	}
}
