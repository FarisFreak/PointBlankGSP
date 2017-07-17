using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_INFO_ACK : SendBaseGamePacket
	{
		private int _aiCount;

		private int _aiLevel;

		private int _all_weapons;

		private int _map_id;

		private string _name;

		private Account _player;

		private int _random_map;

		private Room _room;

		private int _room_type;

		public PROTOCOL_ROOM_CHANGE_INFO_ACK(Account p, string name, int map_id, int all_weapons, int aicount, int ailevel, int random_map, int map_type)
		{
			base.makeme();
			this._player = p;
			this._room = this._player.getRoom();
			this._name = name;
			this._map_id = map_id;
			this._all_weapons = all_weapons;
			this._aiCount = aicount;
			this._aiLevel = ailevel;
			this._random_map = random_map;
			this._room_type = map_type;
		}

		protected internal override void write()
		{
			base.writeH(3887);
			base.writeD(this._player.getSlot());
			base.writeS(this._name, 23);
			base.writeC((byte)this._map_id);
			base.writeH(0);
			base.writeC((byte)this._room_type);
			base.writeC(5);
			base.writeC(1);
			base.writeC((byte)this._room.getSlotCount());
			base.writeC(5);
			base.writeC((byte)this._all_weapons);
			base.writeC((byte)this._random_map);
			base.writeC((byte)this._room.special);
			base.writeS(this._room.getLeader().getPlayerName(), 33);
			base.writeD(this._room.killtime);
			base.writeC((byte)this._room.limit);
			base.writeC((byte)this._room.seeConf);
			base.writeH((short)this._room.autobalans);
			bool flag = this._aiCount > 0 && this._aiLevel > 0;
			if (flag)
			{
				base.writeC((byte)this._aiCount);
				base.writeC((byte)this._aiLevel);
			}
		}
	}
}
