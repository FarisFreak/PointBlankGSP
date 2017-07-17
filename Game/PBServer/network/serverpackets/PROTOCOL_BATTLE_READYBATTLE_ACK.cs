using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BATTLE_READYBATTLE_ACK : SendBaseGamePacket
	{
		private Account _player;

		private Room _room;

		public PROTOCOL_BATTLE_READYBATTLE_ACK(Account p, Room r)
		{
			base.makeme();
			this._room = r;
			this._player = p;
		}

		protected internal override void write()
		{
			base.writeH(3426);
			base.writeH((short)this._room.map_id);
			base.writeC((byte)this._room.stage4v4);
			base.writeC((byte)this._room.room_type);
			base.writeC((byte)this._room.getReadyPlayerList().Count);
			foreach (Account current in this._room.getReadyPlayerList())
			{
				base.writeC((byte)current.getSlot());
				base.writeD(current.char_red);
				base.writeD(current.char_blue);
				base.writeD(current.char_helmet);
				base.writeD(current.char_beret);
				base.writeD(current.char_dino);
				base.writeD(current.weapon_primary);
				base.writeD(current.weapon_secondary);
				base.writeD(current.weapon_melee);
				base.writeD(current.weapon_thrown_normal);
				base.writeD(current.weapon_thrown_special);
				base.writeD(0);
				base.writeC((byte)current.title.getEquipedTitle1());
				base.writeC((byte)current.title.getEquipedTitle2());
				base.writeC((byte)current.title.getEquipedTitle3());
			}
		}
	}
}
