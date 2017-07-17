using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ : ReceiveBaseGamePacket
	{
		private int unk;

		private int unk2;

		public PROTOCOL_AUTH_SHOP_DELETE_ITEM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.unk = (int)base.readH();
			this.unk2 = base.readD();
			CLogger.getInstance().extra_info("Unk: " + this.unk);
			CLogger.getInstance().extra_info("Unk2: " + this.unk2);
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_DELETE_ITEM_ACK());
			AccountManager.getInstance().DeleteItem(base.getClient().getPlayer(), this.unk2);
		}
	}
}
