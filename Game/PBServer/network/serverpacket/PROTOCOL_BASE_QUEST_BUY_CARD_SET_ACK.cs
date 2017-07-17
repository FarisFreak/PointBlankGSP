using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_BASE_QUEST_BUY_CARD_SET_ACK : SendBaseGamePacket
	{
		private int _missionId;

		private Account player;

		public PROTOCOL_BASE_QUEST_BUY_CARD_SET_ACK(int missionId, Account p)
		{
			base.makeme();
			this._missionId = missionId;
			this.player = p;
		}

		protected internal override void write()
		{
			base.writeH(2606);
			base.writeD(1);
			base.writeD(this.player.getGP());
		}
	}
}
