using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class opcode_3620_REQ : ReceiveBaseGamePacket
	{
		private int unk;

		public opcode_3620_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.unk = (int)base.readH();
		}

		protected internal override void run()
		{
			base.getClient().getPlayer().sendPacket(new opcode_3620_ACK());
		}
	}
}
