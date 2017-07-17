using System;

namespace PBServer.network.serverpackets
{
	public class SM_REMOVE_MESSAGE_IN_BOX : SendBaseGamePacket
	{
		public SM_REMOVE_MESSAGE_IN_BOX()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(425);
			base.writeD(1);
		}
	}
}
