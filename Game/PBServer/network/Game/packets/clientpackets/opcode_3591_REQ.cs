using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class opcode_3591_REQ : ReceiveBaseGamePacket
	{
		private int _aiCount;

		private int _aiLevel;

		private int _allweapons;

		private int _autoBalans;

		private int _killMask;

		private int _limit;

		private int _mapId;

		private string _name;

		private int _random_map;

		private int _room_type;

		private int _seeConf;

		private int _special;

		private int _stage4v4;

		private int _unk1;

		private int _unk10;

		private int _unk2;

		private int _unk4;

		private int _unk7;

		private int _unk8;

		private int _unk9;

		public opcode_3591_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this._unk1 = (int)base.readH();
			this._unk2 = base.readD();
			this._name = base.readS(23);
			this._mapId = (int)base.readC();
			this._unk4 = (int)base.readC();
			this._stage4v4 = (int)base.readC();
			this._room_type = (int)base.readC();
			this._unk7 = (int)base.readC();
			this._unk8 = (int)base.readC();
			this._unk9 = (int)base.readC();
			this._unk10 = (int)base.readC();
			this._allweapons = (int)base.readC();
			this._random_map = (int)base.readC();
			this._special = (int)base.readC();
			base.readS(33);
			this._killMask = (int)base.readC();
			base.readC();
			base.readC();
			base.readC();
			this._limit = (int)base.readC();
			this._seeConf = (int)base.readC();
			this._autoBalans = (int)base.readH();
			this._aiCount = (int)base.readC();
			this._aiLevel = (int)base.readC();
			CLogger.getInstance().info(":: " + this._name);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			player.getRoom().name = this._name;
			player.getRoom().map_id = this._mapId;
			player.getRoom().allweapons = this._allweapons;
			player.getRoom()._aiCount = this._aiCount;
			player.getRoom()._aiLevel = this._aiLevel;
			player.getRoom().random_map = this._random_map;
			player.getRoom().room_type = this._room_type;
			player.getRoom().special = this._special;
			player.getRoom().autobalans = this._autoBalans;
			player.getRoom().seeConf = this._seeConf;
			player.getRoom().stage4v4 = this._stage4v4;
			foreach (Account current in player.getRoom().getAllPlayers())
			{
				current.sendPacket(new PROTOCOL_ROOM_CHANGE_ROOMINFO_ACK(player.getRoom()));
			}
		}
	}
}
