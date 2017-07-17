using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_RECV_WHISPER_ACK : SendBaseGamePacket
	{
		private string _msg;

		private int _msglen;

		private string _sender;

		public PROTOCOL_AUTH_RECV_WHISPER_ACK(string sender, int msglen, string msg)
		{
			base.makeme();
			this._sender = sender;
			this._msglen = msglen;
			this._msg = msg;
		}

		protected internal override void write()
		{
			base.writeH(294);
			base.writeS(this._sender, 34);
			base.writeH((short)(this._msg.Length + 10));
			base.writeS(this._msg, this._msg.Length);
		}
	}
}
