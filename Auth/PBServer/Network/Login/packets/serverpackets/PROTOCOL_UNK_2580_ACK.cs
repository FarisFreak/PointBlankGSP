using System;

namespace PBServer.network.Login.packets.serverpackets
{
	public class PROTOCOL_UNK_2580_ACK : SendBaseLoginPacket
	{
		private int _UNK;

		public PROTOCOL_UNK_2580_ACK(int val)
		{
			base.makeme();
			this._UNK = val;
		}

		protected internal override void write()
		{
			base.writeH(2580);
			base.writeD(0);
		}
	}
}
