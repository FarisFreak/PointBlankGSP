using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_561_ACK : SendBaseGamePacket
	{
		public opcode_561_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(561);
			base.writeC(0);
			base.writeH(0);
			base.writeC(1);
			base.writeD(4000);
		}
	}
}
