using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_SHOP_ENTER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_SHOP_ENTER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2820);
			base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
		}
	}
}
