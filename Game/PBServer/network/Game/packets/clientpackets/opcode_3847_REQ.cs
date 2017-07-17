using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class opcode_3847_REQ : ReceiveBaseGamePacket
	{
		private int aiCount;

		private int aiLevel;

		private int allweapons;

		private int map_id;

		private string name;

		private Account p;

		private Room r;

		private int random_map;

		private int room_type;

		private int slot_count;

		private int special;

		private int stage4v4;

		public opcode_3847_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.p = base.getClient().getPlayer();
			this.r = this.p.getRoom();
			base.readH();
			base.readD();
			this.name = base.readS(23);
			this.map_id = (int)base.readC();
			base.readC();
			this.stage4v4 = (int)base.readC();
			this.room_type = (int)base.readC();
			base.readC();
			base.readC();
			this.slot_count = (int)base.readC();
			base.readC();
			this.allweapons = (int)base.readC();
			this.random_map = (int)base.readC();
			this.special = (int)base.readC();
			this.aiCount = (int)base.readC();
			this.aiLevel = (int)base.readC();
		}

		protected internal override void run()
		{
			this.p.getRoom().name = this.name;
			this.p.getRoom().map_id = this.map_id;
			this.p.getRoom().allweapons = this.allweapons;
			this.p.getRoom().random_map = this.random_map;
			this.p.getRoom().stage4v4 = this.stage4v4;
			this.p.getRoom().special = this.special;
			this.p.getRoom().room_type = this.room_type;
			this.p.getRoom()._aiCount = this.aiCount;
			this.p.getRoom()._aiLevel = this.aiLevel;
			foreach (Account current in this.r.getAllPlayers())
			{
				current.sendPacket(new opcode_3848_ACK(this.r));
			}
		}
	}
}
