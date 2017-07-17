using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_SHOP_TEST_1_ACK : SendBaseGamePacket
	{
		public PROTOCOL_SHOP_TEST_1_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(559);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(353);
		}
	}
}
