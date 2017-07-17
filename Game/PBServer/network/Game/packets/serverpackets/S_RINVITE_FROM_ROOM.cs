using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class S_RINVITE_FROM_ROOM : SendBaseGamePacket
	{
		public S_RINVITE_FROM_ROOM()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3604);
			base.writeD(0);
		}
	}
}
