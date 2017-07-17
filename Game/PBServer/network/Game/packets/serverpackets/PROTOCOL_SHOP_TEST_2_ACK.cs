using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_SHOP_TEST_2_ACK : SendBaseGamePacket
	{
		public PROTOCOL_SHOP_TEST_2_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(567);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(353);
		}
	}
}
