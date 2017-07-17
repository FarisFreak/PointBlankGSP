using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_LEAVE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_LOBBY_LEAVE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3084);
			base.writeD(0);
		}
	}
}
