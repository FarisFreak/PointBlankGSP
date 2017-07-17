using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_TITLE_DETACH_REQ : ReceiveBaseGamePacket
	{
		private int _slot;

		public PROTOCOL_TITLE_DETACH_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this._slot = (int)base.readH();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			CLogger.getInstance().info("[Title] " + base.getClient().getPlayer().getPlayerName().ToString() + " unequip a title.");
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_TITLE_DETACH_ACK(this._slot, player));
			}
		}
	}
}
