using PBServer;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_INVENTORY_COUPON_ACTIVATE_ACK : SendBaseGamePacket
	{
		protected internal override void write()
		{
			base.writeH(537);
			byte[] expr_15 = new byte[13];
			expr_15[8] = 4;
			expr_15[9] = 1;
			base.writeB(expr_15);
		}
	}
}
