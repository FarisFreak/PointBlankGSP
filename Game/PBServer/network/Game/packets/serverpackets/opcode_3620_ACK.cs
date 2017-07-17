using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3620_ACK : SendBaseGamePacket
	{
		public opcode_3620_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3620);
			base.writeD(0);
		}
	}
}
