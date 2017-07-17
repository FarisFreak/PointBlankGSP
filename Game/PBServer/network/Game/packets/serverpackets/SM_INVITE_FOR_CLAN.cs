using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_INVITE_FOR_CLAN : SendBaseGamePacket
	{
		public SM_INVITE_FOR_CLAN()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_INVITE_FOR_CLAN");
			base.writeH(427);
			base.writeB(new byte[]
			{
				33,
				0,
				171,
				1,
				66,
				171,
				7,
				1,
				242,
				199,
				113,
				0,
				0,
				0,
				0,
				0
			});
			base.writeB(new byte[]
			{
				5,
				1,
				15,
				151,
				126,
				4,
				0,
				9,
				0
			});
			base.writeS("TheNoTaG", 8);
		}
	}
}
