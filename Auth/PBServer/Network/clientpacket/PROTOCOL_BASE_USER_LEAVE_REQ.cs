using PBServer.network.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_USER_LEAVE_REQ : ReceiveBaseLoginPacket
	{
		public PROTOCOL_BASE_USER_LEAVE_REQ(LoginClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				AccountManager.getInstance().get(base.getClient().getLogin()).setOnlineStatus(false);
				base.getClient().sendPacket(new PROTOCOL_BASE_USER_LEAVE_ACK(base.getClient().getPlayer()));
				base.getClient().close();
			}
		}
	}
}
