using PBServer.managers;
using PBServer.network.serverpackets;
using PBServer.src.model;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.clientpacket
{
	internal class CM_CHAT_CLAN : ReceiveBaseGamePacket
	{
		private int _len;

		private Chat chat = new Chat();

		public CM_CHAT_CLAN(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.chat.chat_type = base.readH();
			this._len = (int)base.readH();
			this.chat.chat = base.readS(this._len);
			this.chat.playername = base.getClient().getPlayer().getPlayerName();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			List<Account> clanPlayers = ClanManager.getInstance().getClanPlayers(player.getClanId());
			foreach (Account current in clanPlayers)
			{
				current.sendPacket(new PROTOCOL_CHAT_CLAN_ACK(this.chat, base.getClient().getPlayer()));
			}
		}
	}
}
