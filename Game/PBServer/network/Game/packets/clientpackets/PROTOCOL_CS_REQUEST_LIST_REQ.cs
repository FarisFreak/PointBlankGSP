using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_CS_REQUEST_LIST_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_CS_REQUEST_LIST_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			base.getClient().getPlayer().sendPacket(new PROTOCOL_CS_REQUEST_LIST_ACK());
		}
	}
}
