using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_ROOM_GET_NEW_HOST_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_ROOM_GET_NEW_HOST_REQ(GameClient Client, byte[] data)
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
			Room room = player.getRoom();
			player.sendPacket(new PROTOCOL_ROOM_GET_NEW_HOST_ACK());
		}
	}
}
