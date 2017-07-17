using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK : SendBaseGamePacket
	{
		private long _status;

		public PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK(long status)
		{
			base.makeme();
			this._status = status;
		}

		protected internal override void write()
		{
			base.writeH(3102);
			base.writeQ(this._status);
		}
	}
}
