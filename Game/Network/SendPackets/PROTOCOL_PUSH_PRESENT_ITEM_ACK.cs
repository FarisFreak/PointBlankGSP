using PBServer;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_PUSH_PRESENT_ITEM_ACK : SendBaseGamePacket
	{
		public PROTOCOL_PUSH_PRESENT_ITEM_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(516);
		}
	}
}
