using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3413_ACK : SendBaseGamePacket
	{
		public opcode_3413_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3413);
			base.writeD(1);
			base.writeC(2);
			base.writeS("Created by MoMz", 18);
		}
	}
}
