using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_ACK : SendBaseGamePacket
	{
		public PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3395);
			base.writeC(10);
			base.writeC(11);
			base.writeD(200);
		}
	}
}
