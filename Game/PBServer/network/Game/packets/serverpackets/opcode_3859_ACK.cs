using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3859_ACK : SendBaseGamePacket
	{
		private int slot;

		public opcode_3859_ACK(int slot)
		{
			base.makeme();
			this.slot = slot;
		}

		protected internal override void write()
		{
			base.writeH(3859);
			base.writeD(this.slot);
			base.writeB(new byte[20]);
		}
	}
}
