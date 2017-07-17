using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2608);
			base.writeD(0);
		}
	}
}
