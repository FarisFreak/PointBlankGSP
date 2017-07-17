using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.src.network.gsPacket.serverpackets
{
	internal class PROTOCOL_BATTLE_STARTBATTLE_ACK : SendBaseGamePacket
	{
		private Account _player;

		private Room _room;

		public PROTOCOL_BATTLE_STARTBATTLE_ACK(Account p)
		{
			base.makeme();
			this._player = p;
			this._room = p.getRoom();
		}

		protected internal override void write()
		{
			base.writeH(3334);
			base.writeD(this._room.isBattleInt());
			base.writeD(this._player.getSlot());
			base.writeD(this._player.char_red);
			base.writeD(this._player.char_blue);
			base.writeD(this._player.char_helmet);
			base.writeD(this._player.char_dino);
			base.writeD(this._player.char_beret);
			base.writeC(0);
			base.writeC(0);
			base.writeC(0);
			base.writeC(2);
			bool flag = this._room.room_type != 2 && this._room.room_type != 4;
			if (!flag)
			{
				base.writeH((short)this._room.getRedWinRounds());
				base.writeH((short)this._room.getBlueWinRounds());
			}
		}
	}
}
