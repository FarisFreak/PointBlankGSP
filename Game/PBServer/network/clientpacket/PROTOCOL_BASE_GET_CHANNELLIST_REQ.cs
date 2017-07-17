using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_GET_CHANNELLIST_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BASE_GET_CHANNELLIST_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			CLogger.getInstance().info("[Channel] " + base.getClient().getPlayer().getPlayerName() + " choose a channel.");
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_BASE_GET_CHANNELLIST_ACK());
			}
		}
	}
}
