using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_CHATTING_ACK : SendBaseGamePacket
	{
		protected Chat _chat;

		private Account player;

		public PROTOCOL_ROOM_CHATTING_ACK(Chat chat, Account player)
		{
			this._chat = chat;
			this.player = player;
			base.makeme();
		}

		protected internal override void write()
		{
			bool flag = this.player._rank == 53 || this.player._rank == 54;
			if (flag)
			{
				base.writeH(3851);
				base.writeH(this._chat.chat_type);
				base.writeD(this.player.getSlot());
				base.writeC(5);
				base.writeD(this._chat.chat.Length + 1);
				base.writeS(this._chat.chat, this._chat.chat.Length + 1);
			}
			else
			{
				base.writeH(3851);
				base.writeH(this._chat.chat_type);
				base.writeD(this.player.getSlot());
				base.writeC((byte)this.player.access_level);
				base.writeD(this._chat.chat.Length + 1);
				base.writeS(this._chat.chat, this._chat.chat.Length + 1);
			}
		}
	}
}
