using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_SAVEINFO1 : SendBaseGamePacket
	{
		public SM_CLAN_SAVEINFO1()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_CLAN_SAVEINFO1");
			base.writeH(1363);
			base.writeD(0);
		}
	}
}
