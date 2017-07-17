using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK : SendBaseGamePacket
	{
		private int error;

		public PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK(int error)
		{
			base.makeme();
			this.error = error;
		}

		protected internal override void write()
		{
			base.writeH(549);
			base.writeD(this.error);
		}
	}
}
