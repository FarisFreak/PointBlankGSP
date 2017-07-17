using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3397);
			base.writeD(0);
		}
	}
}
