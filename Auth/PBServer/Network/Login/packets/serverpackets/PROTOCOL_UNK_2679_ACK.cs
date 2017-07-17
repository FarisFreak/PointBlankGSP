using System;

namespace PBServer.network.Login.packets.serverpackets
{
	public class PROTOCOL_UNK_2679_ACK : SendBaseLoginPacket
	{
		public PROTOCOL_UNK_2679_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2679);
			base.writeD(0);
		}
	}
}
