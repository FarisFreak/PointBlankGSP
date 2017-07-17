using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1546_ACK : SendBaseGamePacket
	{
		public opcode_1546_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1547);
			base.writeD(0);
		}
	}
}
