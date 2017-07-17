using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_ROOM_CHANGE_HOST_REQ : ReceiveBaseGamePacket
	{
		private int slot;

		public PROTOCOL_ROOM_CHANGE_HOST_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.slot = base.readD();
			CLogger.getInstance().info("[Slot] the new owner: " + this.slot);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			player.getRoom().setNewLeader(this.slot);
			player.getRoom().updateInfo();
			player.sendPacket(new PROTOCOL_ROOM_CHANGE_HOST_ACK(this.slot));
		}
	}
}
