using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_RESPAWN_FOR_AI_ACK : SendBaseGamePacket
	{
		private int slot;

		public PROTOCOL_BATTLE_RESPAWN_FOR_AI_ACK(int slot)
		{
			this.slot = slot;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3379);
			base.writeD(this.slot);
		}
	}
}
