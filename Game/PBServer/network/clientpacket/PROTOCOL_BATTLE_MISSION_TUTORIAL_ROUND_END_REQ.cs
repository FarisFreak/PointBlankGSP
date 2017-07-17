using PBServer.network.serverpacket;
using PBServer.src.model.accounts;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				base.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_TUTORIAL_ROUND_END_ACK());
				base.getClient().sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(player));
			}
		}
	}
}
