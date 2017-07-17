using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class CM_CLAN_REQUESITES_FOR_CREATE : ReceiveBaseGamePacket
	{
		public CM_CLAN_REQUESITES_FOR_CREATE(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new SM_CLAN_REQUESITES_FOR_CREATE());
			}
		}
	}
}
