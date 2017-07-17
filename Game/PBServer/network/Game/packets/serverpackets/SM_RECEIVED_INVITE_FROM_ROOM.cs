using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_RECEIVED_INVITE_FROM_ROOM : SendBaseGamePacket
	{
		public SM_RECEIVED_INVITE_FROM_ROOM()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_RECEIVED_INVITE_FROM_ROOM");
			base.writeH(2053);
			base.writeB(new byte[]
			{
				49,
				0,
				5,
				8,
				70,
				117,
				109,
				97,
				80,
				114,
				97,
				81,
				117,
				101
			});
		}
	}
}
