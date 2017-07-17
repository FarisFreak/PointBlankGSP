using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK : SendBaseGamePacket
	{
		private int mission;

		public PROTOCOL_BASE_QUEST_ACTIVE_IDX_CHANGE_ACK(int mission)
		{
			base.makeme();
			this.mission = mission;
		}

		protected internal override void write()
		{
			base.writeH(2602);
			base.writeD(0);
			base.writeC(6);
			base.writeD(100);
		}
	}
}
