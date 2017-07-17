using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_CS_CLIENT_LEAVE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_CS_CLIENT_LEAVE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1444);
		}
	}
}
