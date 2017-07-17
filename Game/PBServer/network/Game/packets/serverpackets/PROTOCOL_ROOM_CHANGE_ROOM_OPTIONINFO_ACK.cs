using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK : SendBaseGamePacket
	{
		private string leader;

		private Room room;

		public PROTOCOL_ROOM_CHANGE_ROOM_OPTIONINFO_ACK(Room room, string leader)
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
