using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_AUTH_FRIEND_INVITED_REQ : ReceiveBaseGamePacket
	{
		private Account account;

		public PROTOCOL_AUTH_FRIEND_INVITED_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.account = base.getClient().getPlayer();
			CLogger.getInstance().info("[Friend] name: " + this.account.getPlayerName());
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				bool flag2 = AccountManager.getInstance().getAccountInName(this.account.getPlayerName()) != null;
				if (flag2)
				{
					FriendManager.getInstance().AddFriend(AccountManager.getInstance().getAccountInName(this.account.getPlayerName()).getPlayerId(), base.getClient().getPlayerId());
					base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(this.account.getPlayerName(), 0));
					base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(this.account));
				}
				else
				{
					base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INVITED_ACK(this.account.getPlayerName(), 0));
					base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(this.account));
				}
			}
		}
	}
}
