using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_DISBAND : SendBaseGamePacket
	{
		public SM_CLAN_DISBAND()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1313);
			base.writeD(0);
		}
	}
}
