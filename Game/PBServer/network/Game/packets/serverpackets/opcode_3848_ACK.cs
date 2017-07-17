using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3848_ACK : SendBaseGamePacket
	{
		private Room room;

		public opcode_3848_ACK(Room room)
		{
			base.makeme();
			this.room = room;
		}

		protected internal override void write()
		{
			base.writeH(3848);
			base.writeD(this.room.getRoomId());
			base.writeS(this.room.name, 23);
			base.writeC((byte)this.room.map_id);
			base.writeH(0);
			base.writeC((byte)this.room.room_type);
			base.writeC(5);
			base.writeC((byte)this.room.getAllPlayers().Count);
			base.writeC(1);
			base.writeC(5);
			base.writeC((byte)this.room.allweapons);
			base.writeC((byte)this.room.random_map);
			base.writeC((byte)this.room.special);
			base.writeS(this.room.getLeader().getPlayerName(), 33);
			base.writeD(this.room.killtime);
			base.writeC((byte)this.room.limit);
			base.writeC((byte)this.room.seeConf);
			base.writeH((short)this.room.autobalans);
			base.writeC((byte)this.room._aiCount);
			base.writeC((byte)this.room._aiLevel);
		}
	}
}
