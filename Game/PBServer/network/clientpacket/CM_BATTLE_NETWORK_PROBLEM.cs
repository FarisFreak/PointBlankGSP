using PBServer.network.serverpacket;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class CM_BATTLE_NETWORK_PROBLEM : ReceiveBaseGamePacket
	{
		public CM_BATTLE_NETWORK_PROBLEM(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				Room room = base.getClient().getPlayer().getRoom();
				room.getSlot(player.getSlot()).state = SLOT_STATE.SLOT_STATE_NORMAL;
				foreach (Account current in room.getAllPlayers())
				{
					bool flag2 = Convert.ToInt32(room.getSlot(current.getSlot()).state) == 13;
					if (flag2)
					{
						current.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(current.getSlot()));
					}
				}
				base.getClient().getPlayer().sendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(2147483647));
				CLogger.getInstance().info("[Room] " + player.getPlayerName() + " connection problem... Return room...");
			}
		}
	}
}
