using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2051);
			base.writeC(3);
			base.writeC(8);
		}
	}
}
