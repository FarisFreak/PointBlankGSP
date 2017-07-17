using PBServer.network.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ : ReceiveBaseGamePacket
	{
		private string novo_nome;

		public PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.novo_nome = base.readS(33);
			CLogger.getInstance().info("[Coupon] new name: " + this.novo_nome);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				bool flag2 = AccountManager.getInstance().getAccountInName(this.novo_nome) == null;
				if (flag2)
				{
					base.getClient().sendPacket(new PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK(0));
				}
				else
				{
					base.getClient().sendPacket(new PROTOCOL_AUTH_USE_ITEM_CHECK_NICK_ACK(2147483647));
				}
			}
		}
	}
}
