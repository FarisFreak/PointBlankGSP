using PBServer.managers;
using PBServer.model.clans;
using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;
using System.Collections.Generic;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_CS_CLIENT_ENTER_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_CS_CLIENT_ENTER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			GameClient client = base.getClient();
			List<Clan> clans = ClanManager.getInstance().getClans();
			bool flag = client.getPlayer() != null && client.getPlayer().getRoom() != null;
			if (flag)
			{
				client.getPlayer().getRoom().changeSlotState(client.getPlayer().getSlot(), SLOT_STATE.SLOT_STATE_CLAN, true);
			}
			bool flag2 = player.getClanId() == 0;
			if (flag2)
			{
				client.sendPacket(new PROTOCOL_CS_CLIENT_ENTER_ACK(0, player, clans));
			}
			bool flag3 = player.getClanId() > 0;
			if (flag3)
			{
				client.sendPacket(new PROTOCOL_CS_CLIENT_ENTER_ACK(1, player, clans));
				client.sendPacket(new PROTOCOL_CS_DETAIL_INFO_ACK(ClanManager.getInstance().get(player.getClanId())));
			}
			CLogger.getInstance().info("[Clan] " + base.getClient().getPlayer().getPlayerName().ToString() + " enters the clan screen.");
		}
	}
}
