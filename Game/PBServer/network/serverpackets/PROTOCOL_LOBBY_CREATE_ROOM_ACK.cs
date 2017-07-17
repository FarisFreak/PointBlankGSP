using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_CREATE_ROOM_ACK : SendBaseGamePacket
	{
		private Room _room;

		public PROTOCOL_LOBBY_CREATE_ROOM_ACK(Room r)
		{
			base.makeme();
			this._room = r;
		}

		protected internal override void write()
		{
			base.writeH(3090);
			base.writeD(this._room.getRoomId());
			base.writeD(this._room.getRoomId());
			base.writeS(this._room.name, 23);
			base.writeC((byte)this._room.map_id);
			base.writeC(0);
			base.writeC((byte)this._room.stage4v4);
			base.writeC((byte)this._room.room_type);
			base.writeC((byte)this._room.getAllPlayers().Count);
			base.writeC(0);
			base.writeC((byte)this._room.getSlotCount());
			base.writeC(5);
			base.writeC((byte)this._room.allweapons);
			base.writeC((byte)this._room.random_map);
			base.writeC((byte)this._room.special);
			base.writeS(this._room.getLeader().getPlayerName(), 33);
			base.writeC((byte)this._room.killtime);
			base.writeC(0);
			base.writeC(0);
			base.writeC(0);
			base.writeC((byte)this._room.limit);
			base.writeC((byte)this._room.seeConf);
			base.writeH((short)this._room.autobalans);
		}
	}
}
