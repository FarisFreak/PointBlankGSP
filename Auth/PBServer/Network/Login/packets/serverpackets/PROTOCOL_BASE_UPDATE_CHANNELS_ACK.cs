using System;

namespace PBServer.network.Login.packets.serverpackets
{
	public class PROTOCOL_BASE_UPDATE_CHANNELS_ACK : SendBaseLoginPacket
	{
		public PROTOCOL_BASE_UPDATE_CHANNELS_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2576);
			base.writeD(0);
		}
	}
}
