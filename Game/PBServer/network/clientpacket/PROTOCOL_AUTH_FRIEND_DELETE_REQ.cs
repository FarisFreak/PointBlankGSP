using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_AUTH_FRIEND_DELETE_REQ : ReceiveBaseGamePacket
	{
		private int FriendNumered;

		public PROTOCOL_AUTH_FRIEND_DELETE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.FriendNumered = (int)base.readC();
			CLogger.getInstance().extra_info("[Friend] remove " + this.FriendNumered);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				FriendManager.getInstance().excludeFriendInDb(this.FriendNumered);
				player.friends.Remove(FriendManager.getInstance().get(this.FriendNumered));
				FriendManager.getInstance().getAccounts().Remove(FriendManager.getInstance().get(this.FriendNumered));
				base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(base.getClient().getPlayer()));
				base.getClient().sendPacket(new PROTOCOL_AUTH_FRIEND_DELETE_ACK());
			}
		}
	}
}
