using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_CHAT_CLAN_ACK : SendBaseGamePacket
	{
		protected Chat _chat;

		private Account player;

		public PROTOCOL_CHAT_CLAN_ACK(Chat chat, Account player)
		{
			this._chat = chat;
			this.player = player;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(1359);
			base.writeD(0);
			base.writeS(" " + this._chat.playername, 34);
			base.writeS(" " + this._chat.chat, this._chat.chat.Length + 1);
		}
	}
}
