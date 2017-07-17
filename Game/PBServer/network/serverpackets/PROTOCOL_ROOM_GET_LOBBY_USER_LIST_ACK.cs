using PBServer.src.model;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK : SendBaseGamePacket
	{
		private Channel client;

		public PROTOCOL_ROOM_GET_LOBBY_USER_LIST_ACK(Channel ch)
		{
			base.makeme();
			this.client = ch;
		}

		protected internal override void write()
		{
			bool flag = this.client.getWaitPlayers().Count == 0;
			int num;
			if (flag)
			{
				num = 0;
			}
			else
			{
				bool flag2 = this.client.getWaitPlayers().Count > 8;
				if (flag2)
				{
					num = 8;
				}
				else
				{
					num = this.client.getWaitPlayers().Count;
				}
			}
			base.writeH(3855);
			base.writeD(num);
			int num2 = num;
			for (int i = 0; i < num2; i++)
			{
				Account account = this.client.getWaitPlayers()[i];
				base.writeD(i);
				base.writeD(account.getRank());
				base.writeC(33);
				base.writeS(account.getPlayerName(), 33);
			}
		}
	}
}
