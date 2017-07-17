using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_PLAYER_EXIT_GAME : ReceiveBaseGamePacket
	{
		public CM_PLAYER_EXIT_GAME(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			base.getClient().close();
		}
	}
}
