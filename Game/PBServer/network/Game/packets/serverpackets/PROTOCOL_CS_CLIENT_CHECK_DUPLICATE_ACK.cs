using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_ACK : SendBaseGamePacket
	{
		private int error;

		public PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_ACK(int error)
		{
			base.makeme();
			this.error = error;
		}

		protected internal override void write()
		{
			base.writeH(1448);
			base.writeD(this.error);
		}
	}
}
