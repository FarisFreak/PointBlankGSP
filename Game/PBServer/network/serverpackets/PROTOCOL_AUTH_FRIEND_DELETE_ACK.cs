using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_FRIEND_DELETE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_FRIEND_DELETE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(285);
			base.writeB(new byte[]
			{
				4,
				0,
				29,
				1,
				0,
				0,
				0,
				0,
				1,
				0,
				18,
				1,
				0
			});
		}
	}
}
