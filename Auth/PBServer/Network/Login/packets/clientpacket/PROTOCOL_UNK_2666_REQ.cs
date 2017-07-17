using PBServer.network.Login.packets.serverpackets;
using System;

namespace PBServer.network.Login.packets.clientpacket
{
	public class PROTOCOL_UNK_2666_REQ : ReceiveBaseLoginPacket
	{
		public PROTOCOL_UNK_2666_REQ(LoginClient lc, byte[] buff)
		{
			base.makeme(lc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_UNK_2667_ACK());
		}
	}
}
