using System;

namespace PBServer.network.Login.packets.serverpackets
{
	public class PROTOCOL_UNK_2667_ACK : SendBaseLoginPacket
	{
		public PROTOCOL_UNK_2667_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2667);
			for (int i = 0; i < 51; i++)
			{
				base.writeC((byte)i);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(255);
				base.writeC(1);
				base.writeC(1);
				base.writeC(1);
				base.writeC(1);
			}
		}
	}
}
