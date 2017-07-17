using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_SAVEINFO2 : SendBaseGamePacket
	{
		public SM_CLAN_SAVEINFO2()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_CLAN_SAVEINFO2");
			base.writeH(1365);
			base.writeD(0);
		}
	}
}
