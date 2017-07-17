using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_INVENTORY_ITEM_ACK : SendBaseGamePacket
	{
		public PROTOCOL_INVENTORY_ITEM_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(537);
			base.writeD(1);
			base.writeQ(1L);
			base.writeD(1);
			base.writeD(1);
			base.writeC(1);
			base.writeD(1);
		}
	}
}
