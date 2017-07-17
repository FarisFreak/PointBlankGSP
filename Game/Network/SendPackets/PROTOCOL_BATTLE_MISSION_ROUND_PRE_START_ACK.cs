using PBServer;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK : SendBaseGamePacket
	{
		protected internal override void write()
		{
			base.writeH(3351);
			base.writeH(0);
			base.writeC(255);
			base.writeC(0);
			base.writeQ(0L);
		}
	}
}
