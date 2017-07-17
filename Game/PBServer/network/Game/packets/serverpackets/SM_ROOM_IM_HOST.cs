using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_ROOM_IM_HOST : SendBaseGamePacket
	{
		private int slot;

		public SM_ROOM_IM_HOST(int slot)
		{
			base.makeme();
			this.slot = slot;
		}

		protected internal override void write()
		{
			CLogger.getInstance().info("Recebendo: SM_ROOM_IM_HOST");
			base.writeH(3867);
			base.writeD(this.slot);
		}
	}
}
