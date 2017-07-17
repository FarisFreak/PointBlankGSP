using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class S_UPDATE_ROOMLIST : SendBaseGamePacket
	{
		public S_UPDATE_ROOMLIST()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2575);
			base.writeD(0);
		}
	}
}
