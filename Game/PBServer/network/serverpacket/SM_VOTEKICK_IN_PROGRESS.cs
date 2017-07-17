using System;

namespace PBServer.network.serverpacket
{
	public class SM_VOTEKICK_IN_PROGRESS : SendBaseGamePacket
	{
		public SM_VOTEKICK_IN_PROGRESS()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3399);
			base.writeD(0);
		}
	}
}
