using PBServer;
using PBServer.network;
using PBServer.src.managers;
using System;

namespace Network.ReceivePackets
{
	public class PROTOCOL_UNK_2654_REQ : ReceiveBaseLoginPacket
	{
		public PROTOCOL_UNK_2654_REQ(LoginClient lc, byte[] buff)
		{
			base.makeme(lc, buff);
		}

		protected internal override void read()
		{
			AccountManager.getInstance().get(base.getClient().getLogin()).setOnlineStatus(false);
			base.getClient().close();
		}

		protected internal override void run()
		{
			CLogger.getInstance().info("[Player] A player left without entering any channel.");
		}
	}
}
