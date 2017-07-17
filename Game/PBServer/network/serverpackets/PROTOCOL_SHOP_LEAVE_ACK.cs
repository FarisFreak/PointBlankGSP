using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_SHOP_LEAVE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_SHOP_LEAVE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2818);
			base.writeD(0);
			base.writeD(0);
		}
	}
}
