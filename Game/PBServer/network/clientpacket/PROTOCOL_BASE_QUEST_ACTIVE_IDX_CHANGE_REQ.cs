using PBServer.network.serverpacket;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ : ReceiveBaseGamePacket
	{
		private int card_number;

		public PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			base.readC();
			this.card_number = (int)base.readC();
			base.readC();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				player.card_id = this.card_number;
				AccountManager.getInstance().UpdateMission(player.getPlayerId(), player.getMissionId(), player.getCardId());
				base.getClient().sendPacket(new PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK(this.card_number));
			}
		}
	}
}
