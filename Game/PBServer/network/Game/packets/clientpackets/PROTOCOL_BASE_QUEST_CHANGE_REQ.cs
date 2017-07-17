using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BASE_QUEST_CHANGE_REQ : ReceiveBaseGamePacket
	{
		private int mission_id;

		private int mission_count;

		public PROTOCOL_BASE_QUEST_CHANGE_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			this.mission_id = base.readD();
			this.mission_count = base.readD();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			base.getClient().getPlayer().sendPacket(new PROTOCOL_BASE_QUEST_CHANGE_ACK(this.mission_id, this.mission_count));
		}
	}
}
