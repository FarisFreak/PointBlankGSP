using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_MESSENGER_NOTE_SEND_ACK : SendBaseGamePacket
	{
		private int error;

		public PROTOCOL_MESSENGER_NOTE_SEND_ACK(int error)
		{
			base.makeme();
			this.error = error;
		}

		protected internal override void write()
		{
			base.writeH(418);
			base.writeD(this.error);
		}
	}
}
