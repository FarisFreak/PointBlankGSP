using PBServer.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_CLAN_SAVEINFO1 : ReceiveBaseGamePacket
	{
		private string unk;

		public CM_CLAN_SAVEINFO1(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.unk = base.readS(280);
			CLogger.getInstance().extra_info("String: " + this.unk);
			CLogger.getInstance().extra_info("[Clan News] informaion were successfully saved.");
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			ClanManager.getInstance().UpdateClanNews(player.getClanId(), this.unk);
		}
	}
}
