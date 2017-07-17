using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_REQUESITES_FOR_CREATE : SendBaseGamePacket
	{
		public SM_CLAN_REQUESITES_FOR_CREATE()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1417);
			base.writeC((byte)Config.NecessaryRank);
			base.writeD(Config.NecessaryGold);
		}
	}
}
