using PBServer.network.serverpacket;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_TITLE_USE_REQ : ReceiveBaseGamePacket
	{
		private byte slot;

		private byte titleId;

		public PROTOCOL_TITLE_USE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.slot = base.readB(1)[0];
			this.titleId = base.readB(1)[0];
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			CLogger.getInstance().info("[Title] " + base.getClient().getPlayer().getPlayerName().ToString() + " used a title.");
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_TITLE_USE_ACK((int)this.slot, (int)this.titleId, player));
			}
		}
	}
}
