using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_ENTER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_LOBBY_ENTER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3080);
		}
	}
}
