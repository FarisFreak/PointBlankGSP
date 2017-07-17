using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK : SendBaseGamePacket
	{
		public PROTOCOL_CS_MEMBER_INFO_CHANGE_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1355);
			base.writeD(1);
			base.writeC(2);
		}
	}
}
