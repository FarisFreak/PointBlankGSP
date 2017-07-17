using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.friends;
using System;
using System.Collections.Generic;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_AUTH_FRIEND_INFO_REQ : ReceiveBaseLoginPacket
	{
		public PROTOCOL_AUTH_FRIEND_INFO_REQ(LoginClient Client, byte[] data)
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
				Account player = base.getClient().getPlayer();
				List<Friends> friends = new List<Friends>();
				bool flag2 = AccountManager.getInstance().get(base.getClient().getLogin()).friends.Count > 0;
				if (flag2)
				{
					AccountManager.getInstance().get(base.getClient().getLogin()).friends = friends;
				}
				base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INFO_ACK(base.getClient()));
				base.getClient().sendPacket(new PROTOCOL_BASE_GET_SETTINGS_ACK(base.getClient()));
			}
		}
	}
}
