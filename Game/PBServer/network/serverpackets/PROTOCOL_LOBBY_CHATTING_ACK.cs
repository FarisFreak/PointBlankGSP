using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_CHATTING_ACK : SendBaseGamePacket
	{
		protected Chat _chat;

		private Account player;

		public PROTOCOL_LOBBY_CHATTING_ACK(Chat chat, Account player)
		{
			this._chat = chat;
			this.player = player;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3093);
			bool flag = this.player._rank == 53 || this.player._rank == 54;
			if (flag)
			{
				base.writeD(this.player.getClient().getPlayerId());
				base.writeC((byte)(this.player.getPlayerName().Length + 1));
				base.writeS(this.player.getPlayerName(), this.player.getPlayerName().Length + 1);
				base.writeC((byte)this.player.getNameColor());
				base.writeC(5);
				base.writeH((short)(this._chat.chat.Length + 1));
				base.writeS(this._chat.chat, this._chat.chat.Length + 1);
			}
			else
			{
				base.writeD(this.player.getClient().getPlayerId());
				base.writeC((byte)(this.player.getPlayerName().Length + 1));
				base.writeS(this.player.getPlayerName(), this.player.getPlayerName().Length + 1);
				base.writeC((byte)this.player.getNameColor());
				base.writeC((byte)this.player.access_level);
				base.writeH((short)(this._chat.chat.Length + 1));
				base.writeS(this._chat.chat, this._chat.chat.Length + 1);
			}
		}
	}
}
