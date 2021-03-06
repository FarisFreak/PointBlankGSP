using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_1546 : ReceiveBaseGamePacket
	{
		public CM_1546(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			base.getClient().getPlayer().sendPacket(new opcode_1546_ACK());
		}
	}
}
