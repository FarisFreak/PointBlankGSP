using System;

namespace PBServer.network.Login.packets.serverpackets
{
	public class PROTOCOL_UNK_2662_ACK : SendBaseLoginPacket
	{
		public PROTOCOL_UNK_2662_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2662);
			base.writeB(new byte[12]);
			base.writeB(new byte[256]);
		}
	}
}
