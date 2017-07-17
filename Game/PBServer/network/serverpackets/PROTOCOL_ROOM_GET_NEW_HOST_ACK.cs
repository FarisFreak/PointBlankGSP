using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_GET_NEW_HOST_ACK : SendBaseGamePacket
	{
		public PROTOCOL_ROOM_GET_NEW_HOST_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3873);
			base.writeB(new byte[]
			{
				0,
				33,
				15,
				255,
				255,
				255,
				255
			});
		}
	}
}
