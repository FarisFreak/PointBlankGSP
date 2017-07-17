using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_SEND_WHISPER_ACK : SendBaseGamePacket
	{
		private int _error;

		private string _msg;

		private int _msglen;

		private string _name;

		private string _sender;

		public PROTOCOL_AUTH_SEND_WHISPER_ACK(string name, int msglen, string msg, string sender, int error)
		{
			base.makeme();
			this._name = name;
			this._msglen = msglen;
			this._msg = msg;
			this._sender = sender;
			this._error = error;
		}

		protected internal override void write()
		{
			base.writeH(291);
			bool flag = this._error == 0;
			if (flag)
			{
				base.writeD(0);
				base.writeS(this._name, 33);
				base.writeH((short)this._msglen);
				base.writeS(this._msg, this._msglen);
			}
			else
			{
				base.writeD(41);
			}
		}
	}
}
