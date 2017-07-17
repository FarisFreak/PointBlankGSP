using System;

namespace PBServer.network.serverpackets
{
	public class SM_3868 : SendBaseGamePacket
	{
		public SM_3868()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3869);
			base.writeB(new byte[]
			{
				29,
				15,
				255,
				255,
				255,
				255
			});
		}
	}
}
