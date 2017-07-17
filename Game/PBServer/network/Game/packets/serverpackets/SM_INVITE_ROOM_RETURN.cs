using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_INVITE_ROOM_RETURN : SendBaseGamePacket
	{
		public SM_INVITE_ROOM_RETURN()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_INVITE_ROOM_RETURN");
			base.writeH(3885);
			base.writeD(0);
		}
	}
}
