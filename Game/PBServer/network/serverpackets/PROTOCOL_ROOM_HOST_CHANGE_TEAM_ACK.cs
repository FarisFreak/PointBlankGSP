using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_HOST_CHANGE_TEAM_ACK : SendBaseGamePacket
	{
		public PROTOCOL_ROOM_HOST_CHANGE_TEAM_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3875);
			base.writeD(0);
		}
	}
}
