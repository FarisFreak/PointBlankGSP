using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1320_ACK : SendBaseGamePacket
	{
		public opcode_1320_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1321);
			base.writeD(0);
			base.writeC(50);
			base.writeS("LAOL", 33);
		}
	}
}
