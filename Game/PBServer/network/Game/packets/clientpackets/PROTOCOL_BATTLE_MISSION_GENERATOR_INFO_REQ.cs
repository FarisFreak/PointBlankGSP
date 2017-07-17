using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			foreach (Account current in player.getRoom().getAllPlayers())
			{
				current.sendPacket(new PROTOCOL_BATTLE_MISSION_GENERATOR_INFO_ACK());
			}
		}
	}
}
