using System;

namespace PBServer.network.serverpackets
{
	[PacketSend(Id = 2564)]
	internal class PROTOCOL_BASE_LOGIN_ACK : SendBaseLoginPacket
	{
		protected long _result;

		public PROTOCOL_BASE_LOGIN_ACK(long result)
		{
			base.makeme();
			this._result = result;
		}

		protected internal override void write()
		{
			base.writeH(2564);
			base.writeQ(this._result);
			base.writeB(new byte[]
			{
				189,
				197,
				19,
				0
			});
			base.writeQ(0L);
		}
	}
}
