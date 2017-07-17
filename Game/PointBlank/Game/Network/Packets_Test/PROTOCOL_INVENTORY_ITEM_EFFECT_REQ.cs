using PBServer;
using PBServer.network;
using System;

namespace PointBlank.Game.Network.Packets_Test
{
	internal class PROTOCOL_INVENTORY_ITEM_EFFECT_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_INVENTORY_ITEM_EFFECT_REQ(GameClient Client, byte[] buff)
		{
			base.makeme(Client, buff);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
		}
	}
}
