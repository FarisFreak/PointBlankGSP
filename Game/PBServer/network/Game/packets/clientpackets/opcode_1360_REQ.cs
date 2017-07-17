using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class opcode_1360_REQ : ReceiveBaseGamePacket
	{
		private int unk1;

		private int unk2;

		private int unk3;

		private int unk4;

		public opcode_1360_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.unk1 = (int)base.readC();
			this.unk2 = (int)base.readC();
			this.unk3 = (int)base.readC();
			this.unk4 = (int)base.readC();
			CLogger.getInstance().info("unk1 " + this.unk1);
			CLogger.getInstance().info("unk2 " + this.unk2);
			CLogger.getInstance().info("unk3 " + this.unk3);
			CLogger.getInstance().info("unk4 " + this.unk4);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new opcode_1360_ACK());
			}
		}
	}
}
