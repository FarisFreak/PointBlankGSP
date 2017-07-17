using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_CREATE_ROOM_REQ : ReceiveBaseGamePacket
	{
		private string _player_name;

		private Room _room;

		private int _roomId;

		private int _unk2;

		private int _unk4;

		private int test1;

		private int test2;

		private int unkc3;

		private int unkc4;

		private int unkc5;

		public PROTOCOL_LOBBY_CREATE_ROOM_REQ(GameClient client, byte[] data)
		{
			base.makeme(client, data);
		}

		protected internal override void read()
		{
			CLogger.getInstance().info("[Room] " + base.getClient().getPlayer().getPlayerName().ToString() + " It created a room.");
			int num = (int)base.readH();
			base.getClient().getPlayer();
			this._room = new Room(ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRooms().Count, base.getClient().getChannelId());
			this._roomId = base.readD();
			this._room.name = base.readS(18);
			base.readB(5);
			this._room.map_id = (int)base.readC();
			this._unk2 = (int)base.readC();
			this._room.stage4v4 = (int)base.readC();
			this._room.room_type = (int)base.readC();
			this.test1 = (int)base.readC();
			this.test2 = (int)base.readC();
			this._room.initSlotCount((int)base.readC());
			this._unk4 = (int)base.readC();
			this._room.allweapons = (int)base.readC();
			this._room.random_map = (int)base.readC();
			this._room.special = (int)base.readC();
			this._player_name = base.readS(33);
			this._room.killtime = (int)base.readC();
			this.unkc3 = (int)base.readC();
			this.unkc4 = (int)base.readC();
			this.unkc5 = (int)base.readC();
			this._room.limit = (int)base.readC();
			this._room.seeConf = (int)base.readC();
			this._room.autobalans = (int)base.readH();
			this._room.password = base.readS(4);
			bool flag = this._room.special == 6;
			if (flag)
			{
				this._room._aiCount = (int)base.readC();
				this._room._aiLevel = (int)base.readC();
			}
			this._room._channelId = base.getClient().getChannelId();
			int slot = this._room.addPlayer(base.getClient().getPlayer());
			base.getClient().getPlayer().setRoom(this._room);
			base.getClient().getPlayer().setSlot(slot);
			ChannelInfoHolder.getChannel(base.getClient().getChannelId()).addRoom(this._room);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_LOBBY_CREATE_ROOM_ACK(this._room));
				CLogger.getInstance().info("[Room] " + this._room.map_id + " It created a room.");
			}
		}
	}
}
