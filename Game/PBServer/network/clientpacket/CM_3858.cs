using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class CM_3858 : ReceiveBaseGamePacket
	{
		private int autoBalans;

		private int kill_time;

		private string leader;

		private int limit;

		private int seeConf;

		public CM_3858(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.leader = base.readS(33);
			this.kill_time = base.readD();
			this.limit = (int)base.readC();
			this.seeConf = (int)base.readC();
			this.autoBalans = (int)base.readH();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = base.getClient().getPlayer().getRoom();
			room.killtime = this.kill_time;
			room.seeConf = this.seeConf;
			room.autobalans = this.autoBalans;
			room.limit = this.limit;
			foreach (Account current in room.getAllPlayers())
			{
				current.sendPacket(new SM_3858(room, this.leader));
			}
		}
	}
}
