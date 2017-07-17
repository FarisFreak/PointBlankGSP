using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BASE_QUEST_CHANGE_ACK : SendBaseGamePacket
	{
		private int Mission;

		private int Count;

		public PROTOCOL_BASE_QUEST_CHANGE_ACK(int Mission, int Count)
		{
			base.makeme();
			this.Mission = Mission;
			this.Count = Count;
		}

		protected internal override void write()
		{
			base.writeH(2600);
			base.writeC((byte)this.Mission);
			base.writeC((byte)this.Count);
		}
	}
}
