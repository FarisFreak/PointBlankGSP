using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class CM_LOBBY_GET_PLAYERINFO2 : ReceiveBaseGamePacket
	{
		private int id;

		public CM_LOBBY_GET_PLAYERINFO2(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.id = base.readD();
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new SM_LOBBY_GET_PLAYERINFO2(this.id));
		}
	}
}
