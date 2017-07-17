using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_GET_ROOMINFO_REQ : ReceiveBaseGamePacket
	{
		private int roomId;

		public PROTOCOL_LOBBY_GET_ROOMINFO_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.roomId = (int)base.readC();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Room roomInId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(this.roomId);
				bool flag2 = roomInId != null && roomInId.getLeader() != null;
				if (flag2)
				{
					base.getClient().sendPacket(new PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK(roomInId));
				}
			}
		}
	}
}
