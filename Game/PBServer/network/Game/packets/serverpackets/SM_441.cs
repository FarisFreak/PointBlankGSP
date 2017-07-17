using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_441 : SendBaseGamePacket
	{
		public SM_441()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(441);
			base.writeD(0);
		}
	}
}
