using PBServer.network.BattleConnect;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BATTLE_SENDPING_ACK : SendBaseGamePacket
	{
		private byte[] _slots;

		public PROTOCOL_BATTLE_SENDPING_ACK(byte[] slots)
		{
			this._slots = slots;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3345);
			base.writeB(this._slots);
			UdpHandler.getInstance().PingUdpServer();
		}
	}
}
