using PBServer.managers;
using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_REQ : ReceiveBaseGamePacket
	{
		private string clanName;

		public PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this.clanName = base.readS((int)base.readC());
		}

		protected internal override void run()
		{
			bool flag = ClanManager.getInstance().getClanForName(this.clanName) == null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_ACK(0));
			}
			else
			{
				base.getClient().sendPacket(new PROTOCOL_CS_CLIENT_CHECK_DUPLICATE_ACK(2147483647));
			}
		}
	}
}
