using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BASE_QUEST_GET_INFO_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BASE_QUEST_GET_INFO_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2596);
			base.writeC(0);
			base.writeB(new byte[85]);
			base.writeH(1);
			base.writeC(0);
			base.writeC(13);
		}
	}
}
