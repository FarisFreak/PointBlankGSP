using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_BOT_CHANGELEVEL_ACK : SendBaseGamePacket
	{
		private Room room;

		public PROTOCOL_BATTLE_BOT_CHANGELEVEL_ACK(Room room)
		{
			this.room = room;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3377);
			base.writeC(Convert.ToByte((this.room._aiLevel <= 10) ? this.room._aiLevel : 10));
			for (int i = 0; i < 8; i++)
			{
				base.writeD(1);
				base.writeD(1);
			}
		}
	}
}
