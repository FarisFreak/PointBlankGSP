using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_ROOM_IM_HOST : ReceiveBaseGamePacket
	{
		public CM_ROOM_IM_HOST(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				foreach (Account current in player.getRoom().getAllPlayers())
				{
					current.sendPacket(new SM_ROOM_IM_HOST(player.getSlot()));
				}
			}
		}
	}
}
