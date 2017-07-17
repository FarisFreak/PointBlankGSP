using System;

namespace PBServer.src.network.Game.packets.serverpackets
{
	internal class PROTOCOL_ROOM_CHANGE_SLOT_ACK : SendBaseGamePacket
	{
		private int _slot;

		public PROTOCOL_ROOM_CHANGE_SLOT_ACK(int slot)
		{
			this._slot = slot;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3850);
			base.writeD(this._slot);
		}
	}
}
