using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_CLAN_QUANTITY : SendBaseGamePacket
	{
		private int size;

		public SM_CLAN_QUANTITY(int size)
		{
			base.makeme();
			this.size = size;
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Send: SM_CLAN_QUANTITY");
			base.writeH(1452);
			base.writeD(this.size);
		}
	}
}
