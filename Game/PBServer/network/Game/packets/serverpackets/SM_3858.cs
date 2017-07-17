using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_3858 : SendBaseGamePacket
	{
		private string leader;

		private Room room;

		public SM_3858(Room room, string leader)
		{
			this.room = room;
			this.leader = leader;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3859);
			base.writeS(this.leader, 33);
			base.writeD(this.room.killtime);
			base.writeC((byte)this.room.limit);
			base.writeC((byte)this.room.seeConf);
			base.writeH((short)this.room.autobalans);
		}
	}
}
