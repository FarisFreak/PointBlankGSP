using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	internal class CM_REMOVE_MESSAGE_IN_BOX : ReceiveBaseGamePacket
	{
		public CM_REMOVE_MESSAGE_IN_BOX(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new SM_REMOVE_MESSAGE_IN_BOX());
			}
		}
	}
}
