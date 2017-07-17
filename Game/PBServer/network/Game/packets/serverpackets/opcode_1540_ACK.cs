using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1540_ACK : SendBaseGamePacket
	{
		public opcode_1540_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1541);
			base.writeD(0);
		}
	}
}
