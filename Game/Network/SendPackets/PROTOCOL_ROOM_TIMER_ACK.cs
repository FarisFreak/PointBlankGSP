using PBServer;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_ROOM_TIMER_ACK : SendBaseGamePacket
	{
		protected internal override void write()
		{
			base.writeH(3340);
			base.writeC(5);
		}
	}
}
