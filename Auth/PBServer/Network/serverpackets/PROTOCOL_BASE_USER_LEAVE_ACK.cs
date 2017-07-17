using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	internal class PROTOCOL_BASE_USER_LEAVE_ACK : SendBaseLoginPacket
	{
		private Account _p;

		public PROTOCOL_BASE_USER_LEAVE_ACK(Account p)
		{
			base.makeme();
			this._p = p;
		}

		protected internal override void write()
		{
			base.writeH(2578);
			base.writeD(0);
		}
	}
}
