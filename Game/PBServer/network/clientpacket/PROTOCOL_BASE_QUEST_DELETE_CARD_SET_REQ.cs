using PBServer.network.serverpacket;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BASE_QUEST_DELETE_CARD_SET_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
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
				player.mission_id = 0;
				player.card_id = 0;
				AccountManager.getInstance().UpdateMission(player.getPlayerId(), 0, 0);
				base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_DELETE_CARD_SET_ACK());
			}
		}
	}
}
