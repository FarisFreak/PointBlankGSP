using PBServer.managers;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_1392 : ReceiveBaseGamePacket
	{
		private int number;

		public CM_1392(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			base.readC();
			this.number = (int)base.readC();
			CLogger.getInstance().info("[Name] " + this.number);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				Message message = new Message
				{
					object_id = MessageManager.getInstance().getMessages().Count + 1,
					recipient_name = ClanManager.getInstance().get(player.getClanId()).getClanName(),
					owner_id = FriendManager.getInstance().getFriend2(this.number).getFriendId()
				};
				MessageManager.getInstance().AddMessage(message);
				player.sendPacket(new SM_1392());
				MessageManager.getInstance().createMessageInDb(ClanManager.getInstance().get(player.getClanId()).getClanName(), FriendManager.getInstance().getFriend2(this.number).getFriendId(), message.getObjId(), " ");
				bool flag2 = AccountManager.getInstance().getAccountInPlayerId(FriendManager.getInstance().getFriend2(this.number).getFriendId()) != null;
				if (flag2)
				{
					Account accountInPlayerId = AccountManager.getInstance().getAccountInPlayerId(FriendManager.getInstance().getFriend2(this.number).getFriendId());
					CLogger.getInstance().info("[Friend] " + accountInPlayerId.getPlayerName());
					accountInPlayerId.sendPacket(new SM_427_2(message.getRecName(), message.getObjId()));
				}
			}
		}
	}
}
