using System;

namespace PBServer.src.network.gsPacket.serverpackets
{
	internal class PROTOCOL_BATTLE_GIVEUPBATTLE_ACK : SendBaseGamePacket
	{
		private int slot;

		public PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(int slot)
		{
			base.makeme();
			this.slot = slot;
		}

		protected internal override void write()
		{
			base.writeH(3385);
			base.writeD(this.slot);
			base.writeB(new byte[20]);
		}
	}
}
