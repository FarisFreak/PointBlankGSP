using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_BOT_CHANGELEVEL_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_BOT_CHANGELEVEL_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			bool flag = room._aiLevel + 1 >= 10;
			if (flag)
			{
				room._aiLevel = 10;
			}
			else
			{
				room._aiLevel++;
			}
			foreach (Account current in player.getRoom().getAllPlayers())
			{
				current.sendPacket(new PROTOCOL_BATTLE_BOT_CHANGELEVEL_ACK(room));
			}
		}
	}
}
