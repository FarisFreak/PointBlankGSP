using PBServer.managers;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_422 : ReceiveBaseGamePacket
	{
		private int message_id;

		public CM_422(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			base.readC();
			this.message_id = (int)base.readC();
			CLogger.getInstance().info("[Message]: " + this.message_id);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				bool flag2 = ClanManager.getInstance().getClanForName(MessageManager.getInstance().getMessageForObjId(this.message_id).getRecName()) != null;
				if (flag2)
				{
					player.setClanId(ClanManager.getInstance().getClanForName(MessageManager.getInstance().getMessageForObjId(this.message_id).getRecName()).getClanId());
					AccountManager.getInstance().UpdateClan(player.getPlayerId(), player.getClanId());
				}
				bool flag3 = player.getRoom() != null;
				if (flag3)
				{
					player.getRoom().updateInfo();
				}
				player.sendPacket(new SM_441());
			}
		}
	}
}
