using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1360_ACK : SendBaseGamePacket
	{
		public opcode_1360_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1361);
			base.writeD(0);
		}
	}
}
