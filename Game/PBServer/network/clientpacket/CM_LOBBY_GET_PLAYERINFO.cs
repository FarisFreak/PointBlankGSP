using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	public class CM_LOBBY_GET_PLAYERINFO : ReceiveBaseGamePacket
	{
		private int id_p;

		public CM_LOBBY_GET_PLAYERINFO(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.id_p = base.readD();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new SM_LOBBY_GET_PLAYERINFO(this.id_p));
			}
		}
	}
}
