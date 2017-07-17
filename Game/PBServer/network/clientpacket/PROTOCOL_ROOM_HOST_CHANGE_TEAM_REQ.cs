using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_ROOM_HOST_CHANGE_TEAM_REQ : ReceiveBaseGamePacket
	{
		private int host_changed = 1;

		public PROTOCOL_ROOM_HOST_CHANGE_TEAM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = base.getClient().getPlayer().getRoom();
			foreach (Account current in player.getRoom().getAllPlayers())
			{
				int slot = current.getSlot();
				current.setnewSlot(current.getSlot());
				int slot2 = current.getnewSlot();
				this.host_changed = room.setNewSlotHost(current, slot2, slot, this.host_changed);
				foreach (Account current2 in player.getRoom().getAllPlayers())
				{
					current2.sendPacket(new PROTOCOL_ROOM_CHANGE_TEAM_ACK(slot, player));
					current2.sendPacket(new PROTOCOL_ROOM_HOST_CHANGE_TEAM_ACK());
				}
				current.getRoom().updateInfo();
			}
		}
	}
}
