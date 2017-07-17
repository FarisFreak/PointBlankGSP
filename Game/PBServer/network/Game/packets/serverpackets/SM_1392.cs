using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_1392 : SendBaseGamePacket
	{
		public SM_1392()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1393);
			base.writeD(0);
		}
	}
}
