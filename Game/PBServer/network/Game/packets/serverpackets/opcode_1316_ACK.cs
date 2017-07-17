using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1316_ACK : SendBaseGamePacket
	{
		public opcode_1316_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1317);
			base.writeD(0);
		}
	}
}
