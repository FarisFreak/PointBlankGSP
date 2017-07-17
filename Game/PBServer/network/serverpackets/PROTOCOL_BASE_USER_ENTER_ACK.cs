using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BASE_USER_ENTER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BASE_USER_ENTER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2580);
			base.writeD(0);
		}
	}
}
