using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_AUTH_RECV_WHISPER_REQ : ReceiveBaseGamePacket
	{
		private string _message;

		private int _messageLength;

		private string _recvrName;

		private string _sender;

		public PROTOCOL_AUTH_RECV_WHISPER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this._sender = base.getClient().getPlayer().getPlayerName();
			base.readH();
			this._recvrName = base.readS(33);
			this._messageLength = (int)base.readH();
			this._message = base.readS(this._messageLength);
			CLogger.getInstance().info("[Whisper] " + base.getClient().getPlayer().getPlayerName() + " sent a private message to " + this._recvrName);
		}

		protected internal override void run()
		{
			Account accountInName = AccountManager.getInstance().getAccountInName(this._recvrName);
			bool flag = accountInName == null || accountInName._connection == null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_AUTH_SEND_WHISPER_ACK(this._recvrName, this._messageLength, this._message, this._sender, 2147483647));
			}
			else
			{
				base.getClient().sendPacket(new PROTOCOL_AUTH_SEND_WHISPER_ACK(this._recvrName, this._messageLength, this._message, this._sender, 0));
				accountInName.sendPacket(new PROTOCOL_AUTH_RECV_WHISPER_ACK(this._sender, this._messageLength, this._message));
			}
		}
	}
}
