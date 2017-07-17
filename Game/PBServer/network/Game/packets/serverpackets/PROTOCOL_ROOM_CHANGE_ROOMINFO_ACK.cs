using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK : SendBaseGamePacket
	{
		private Room _room;

		public PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(Room r)
		{
			this._room = r;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3848);
			base.writeD(this._room.getRoomId());
			base.writeS(this._room.name, 23);
			base.writeC((byte)this._room.map_id);
			base.writeH(0);
			base.writeC((byte)this._room.room_type);
			base.writeC(5);
			base.writeC((byte)this._room.getAllPlayers().Count);
			base.writeC((byte)this._room.getSlotCount());
			base.writeC(5);
			base.writeC((byte)this._room.allweapons);
			base.writeC((byte)this._room.random_map);
			base.writeC((byte)this._room.special);
			base.writeS(this._room.getLeader().getPlayerName(), 33);
			base.writeD(this._room.killtime);
			base.writeC((byte)this._room.limit);
			base.writeC((byte)this._room.seeConf);
			base.writeH((short)this._room.autobalans);
			base.writeC((byte)this._room._aiCount);
			base.writeC((byte)this._room._aiLevel);
		}
	}
}
