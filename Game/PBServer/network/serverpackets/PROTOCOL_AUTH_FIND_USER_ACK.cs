using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_FIND_USER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_FIND_USER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(298);
			base.writeC(255);
		}
	}
}
