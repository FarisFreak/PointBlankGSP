using PBServer.network.Login.packets.serverpackets;
using System;

namespace PBServer.network.Login.packets.clientpacket
{
	public class PROTOCOL_UNK_2579_REQ : ReceiveBaseLoginPacket
	{
		private int _UNK;

		public PROTOCOL_UNK_2579_REQ(LoginClient lc, byte[] buff)
		{
			base.makeme(lc, buff);
		}

		protected internal override void read()
		{
			this._UNK = (int)base.readH();
			int length = (int)base.readC();
			string text = base.readS(length);
			long num = base.readQ();
			int num2 = (int)base.readC();
			byte[] array = base.readB(4);
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_UNK_2580_ACK(this._UNK));
		}
	}
}
