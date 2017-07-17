using System;
using System.Text;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK : SendBaseGamePacket
	{
		private string _message;

		private byte[] messageb;

		public PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK(string msg)
		{
			base.makeme();
			this._message = msg;
		}

		public static byte[] StrToByteArray(string str)
		{
			ASCIIEncoding aSCIIEncoding = new ASCIIEncoding();
			return aSCIIEncoding.GetBytes(str);
		}

		protected internal override void write()
		{
			base.writeH(2055);
			this.messageb = PROTOCOL_SERVER_MESSAGE_ANNOUNCE_ACK.StrToByteArray(this._message);
			bool flag = this._message.Length > 0;
			if (flag)
			{
				base.writeD(2);
				base.writeH(67);
				base.writeS(this._message);
			}
		}
	}
}
