using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_INFO_ENTER_ACK : SendBaseGamePacket
	{
		public PROTOCOL_ROOM_INFO_ENTER_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3863);
		}
	}
}
