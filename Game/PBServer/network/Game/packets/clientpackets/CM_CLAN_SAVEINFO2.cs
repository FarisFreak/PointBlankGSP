using PBServer.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_CLAN_SAVEINFO2 : ReceiveBaseGamePacket
	{
		private string clan_info;

		public CM_CLAN_SAVEINFO2(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.clan_info = base.readS(280);
			CLogger.getInstance().extra_info("[Clan Info] informaion were successfully saved.");
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			ClanManager.getInstance().UpdateClanInfo(player.getClanId(), this.clan_info);
		}
	}
}
