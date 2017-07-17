using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3906_ACK : SendBaseGamePacket
	{
		public opcode_3906_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3907);
			base.writeD(2);
		}
	}
}
