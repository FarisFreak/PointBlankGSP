using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class opcode_2845_REQ : ReceiveBaseGamePacket
	{
		public opcode_2845_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new opcode_2845_ACK());
			}
		}
	}
}
