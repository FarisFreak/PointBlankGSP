using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1538_ACK : SendBaseGamePacket
	{
		public opcode_1538_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1539);
			base.writeD(0);
		}
	}
}
