using PBServer.network.serverpackets;
using PBServer.src.managers;
using System;
using System.Net;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_USER_ENTER_REQ : ReceiveBaseGamePacket
	{
		private byte[] _IP;

		private string account;

		private int Account_len;

		public PROTOCOL_BASE_USER_ENTER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.Account_len = (int)base.readC();
			this.account = base.readS(this.Account_len - 1);
			base.readQ();
			int num2 = (int)base.readC();
			int num3 = (int)base.readC();
			this._IP = base.readB(4);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				try
				{
					base.getClient().setAccount(AccountManager.getInstance().get(this.account).player_id);
					base.getClient().restoreAccount(this.account);
					AccountManager.getInstance().get(this.account).setClient(base.getClient());
					AccountManager.getInstance().get(this.account).setLocalAddress(this._IP);
					AccountManager.getInstance().get(this.account).setPublicAddress(((IPEndPoint)base.getClient()._address).Address.ToString());
					base.getClient().sendPacket(new PROTOCOL_BASE_USER_ENTER_ACK());
				}
				catch (Exception ex)
				{
					CLogger.getInstance().warning(ex.ToString());
					base.getClient().close();
				}
				CLogger.getInstance().info("[Server] " + base.getClient().getPlayer().getPlayerName().ToString() + " entered the game.");
			}
		}
	}
}
