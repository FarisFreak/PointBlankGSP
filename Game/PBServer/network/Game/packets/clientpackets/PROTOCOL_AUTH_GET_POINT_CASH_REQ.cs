using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_AUTH_GET_POINT_CASH_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_AUTH_GET_POINT_CASH_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
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
				player.sendPacket(new PROTOCOL_AUTH_GET_POINT_CASH_ACK(player));
			}
		}
	}
}
