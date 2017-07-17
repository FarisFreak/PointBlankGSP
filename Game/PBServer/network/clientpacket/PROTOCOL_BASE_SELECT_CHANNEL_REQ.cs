using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_SELECT_CHANNEL_REQ : ReceiveBaseGamePacket
	{
		private int id_channel;

		public PROTOCOL_BASE_SELECT_CHANNEL_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.id_channel = base.readD();
			base.getClient().setChannelId(this.id_channel);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_BASE_SELECT_CHANNEL_ACK(this.id_channel));
			}
		}
	}
}
