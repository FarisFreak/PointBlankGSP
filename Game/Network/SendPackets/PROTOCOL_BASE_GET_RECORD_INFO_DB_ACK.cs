using PBServer;
using System;

namespace Network.SendPackets
{
	internal class PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK : SendBaseGamePacket
	{
		private int _player_id;

		public PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK(int player_id)
		{
			this._player_id = player_id;
		}

		protected internal override void write()
		{
			base.writeH(2592);
			base.writeC((byte)this._player_id);
			base.writeC(0);
		}
	}
}
