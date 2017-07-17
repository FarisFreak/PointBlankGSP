using PBServer.network;
using PBServer.src.model.accounts;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	public class PROTOCOL_BATTLE_HOLE_CHECK_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_HOLE_CHECK_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			CLogger.getInstance().info("[Room] " + player.getPlayerName() + " new owner of room in the game.");
			player.sendPacket(new PROTOCOL_BATTLE_HOLE_CHECK_ACK(player.getRoom()));
		}
	}
}
