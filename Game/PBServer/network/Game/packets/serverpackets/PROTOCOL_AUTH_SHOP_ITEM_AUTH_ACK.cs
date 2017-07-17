using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_SHOP_ITEM_AUTH_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2822);
			base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
		}
	}
}
