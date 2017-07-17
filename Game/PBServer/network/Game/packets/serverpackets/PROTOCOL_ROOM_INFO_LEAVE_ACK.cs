using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_INFO_LEAVE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_ROOM_INFO_LEAVE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3865);
		}
	}
}
