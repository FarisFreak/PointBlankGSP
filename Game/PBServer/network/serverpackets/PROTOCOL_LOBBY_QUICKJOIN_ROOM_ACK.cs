using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK : SendBaseGamePacket
	{
		public PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3078);
			base.writeB(new byte[]
			{
				4,
				0,
				6,
				12,
				0,
				0,
				0,
				128
			});
		}
	}
}
