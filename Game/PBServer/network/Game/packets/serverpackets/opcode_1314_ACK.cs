using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_1314_ACK : SendBaseGamePacket
	{
		public opcode_1314_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1315);
			base.writeD(0);
			base.writeD(1);
			base.writeH(3);
		}
	}
}
