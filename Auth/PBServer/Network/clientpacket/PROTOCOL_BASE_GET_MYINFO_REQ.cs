using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_GET_MYINFO_REQ : ReceiveBaseLoginPacket
	{
		public PROTOCOL_BASE_GET_MYINFO_REQ(LoginClient Client, byte[] data)
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
				base.getClient().sendPacket(new PROTOCOL_BASE_GET_CLAN_PLAYERS_ACK(base.getClient()));
				base.getClient().sendPacket(new PROTOCOL_BASE_GET_MYINFO_ACK(base.getClient()));
			}
		}
	}
}
