using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_PASSWORD_ERROR_ACK : SendBaseGamePacket
	{
		public PROTOCOL_LOBBY_PASSWORD_ERROR_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3082);
			base.writeB(new byte[]
			{
				4,
				0,
				10,
				12,
				5,
				16,
				0,
				128
			});
		}
	}
}
