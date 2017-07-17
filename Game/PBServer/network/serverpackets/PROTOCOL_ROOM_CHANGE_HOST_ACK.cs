using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_HOST_ACK : SendBaseGamePacket
	{
		private int slot;

		public PROTOCOL_ROOM_CHANGE_HOST_ACK(int slot)
		{
			base.makeme();
			this.slot = slot;
		}

		protected internal override void write()
		{
			base.writeH(3871);
			base.writeD(this.slot);
		}
	}
}
