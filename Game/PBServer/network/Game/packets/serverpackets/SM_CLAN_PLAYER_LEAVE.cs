using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_PLAYER_LEAVE : SendBaseGamePacket
	{
		public SM_CLAN_PLAYER_LEAVE()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_CLAN_PLAYER_LEAVE");
			base.writeH(1333);
			base.writeD(0);
		}
	}
}
