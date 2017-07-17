using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_TITLE_GET_ACK : SendBaseGamePacket
	{
		private int _errNo;

		private int _OpenedSlot;

		public PROTOCOL_TITLE_GET_ACK(int errNo, int OpenedSlot)
		{
			base.makeme();
			this._errNo = errNo;
			this._OpenedSlot = OpenedSlot;
		}

		protected internal override void write()
		{
			base.writeH(2620);
			bool flag = this._errNo == 0;
			if (flag)
			{
				base.writeD(0);
				base.writeD(this._OpenedSlot);
			}
			else
			{
				base.writeD(8);
				base.writeD(0);
				base.writeQ(217L);
			}
		}
	}
}
