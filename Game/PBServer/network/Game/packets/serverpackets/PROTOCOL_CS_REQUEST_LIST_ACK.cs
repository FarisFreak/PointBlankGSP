using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_REQUEST_LIST_ACK : SendBaseGamePacket
	{
		public PROTOCOL_CS_REQUEST_LIST_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1323);
			base.writeC(0);
			base.writeC(20);
			base.writeC(12);
		}
	}
}
