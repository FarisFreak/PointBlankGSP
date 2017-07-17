using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.friends;
using System;

namespace PBServer.network.serverpackets
{
	[PacketSend(Id = 274)]
	public class PROTOCOL_AUTH_FRIEND_INFO_ACK : SendBaseLoginPacket
	{
		private LoginClient _lc;

		public PROTOCOL_AUTH_FRIEND_INFO_ACK(LoginClient lc)
		{
			base.makeme();
			this._lc = lc;
		}

		protected internal override void write()
		{
			Account account = AccountManager.getInstance().get(this._lc.getLogin());
			bool flag = FriendManager.getInstance().getFriends(account.getPlayerId()).Count != 0;
			if (flag)
			{
				foreach (Friends current in FriendManager.getInstance().getFriends(account.getPlayerId()))
				{
					account.friends.Add(current);
				}
			}
			base.writeH(274);
			base.writeC((byte)account.friends.Count);
			bool flag2 = FriendManager.getInstance().getFriends(account.getPlayerId()).Count == 0;
			if (flag2)
			{
				base.writeC(33);
				base.writeS("", 33);
				base.writeQ(0L);
				base.writeD(0);
				base.writeC(0);
				base.writeC(0);
			}
			else
			{
				foreach (Friends current2 in account.friends)
				{
					base.writeC(33);
					base.writeS(Convert.ToString((AccountManager.getInstance().getAccountInPlayerId(current2.getFriendId()) == null || account == null) ? "" : AccountManager.getInstance().getAccountInPlayerId(current2.getFriendId()).getPlayerName()), Convert.ToInt32((AccountManager.getInstance().getAccountInPlayerId(current2.getFriendId()) == null || account == null) ? 33 : 33));
					base.writeC(Convert.ToByte(current2.FriendNumered));
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
					base.writeC(Convert.ToByte((AccountManager.getInstance().getAccountInPlayerId(current2.getFriendId()) == null || account == null) ? 0 : AccountManager.getInstance().getAccountInPlayerId(current2.getFriendId()).getRank()));
					base.writeC(3);
					base.writeC(3);
					base.writeC(3);
				}
			}
			base.writeH(1);
			base.writeC(10);
			base.writeC(33);
			base.writeS(account.getPlayerName(), 33);
		}
	}
}
