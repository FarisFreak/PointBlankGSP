using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_INVENTORY_LEAVE_ACK : SendBaseGamePacket
	{
		private int type;

		public PROTOCOL_INVENTORY_LEAVE_ACK(int type)
		{
			base.makeme();
			this.type = type;
		}

		protected internal override void write()
		{
			base.writeH(3590);
			base.writeD(this.type);
			bool flag = this.type < 0;
			if (flag)
			{
				base.writeD(0);
			}
		}
	}
}
