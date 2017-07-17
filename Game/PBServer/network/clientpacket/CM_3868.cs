using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class CM_3868 : ReceiveBaseGamePacket
	{
		public CM_3868(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
		}

		protected internal override void run()
		{
			base.getClient().getPlayer().sendPacket(new SM_3868());
		}
	}
}
