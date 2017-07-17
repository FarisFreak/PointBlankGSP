using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK : SendBaseGamePacket
	{
		private Room _r;

		public PROTOCOL_LOBBY_GET_ROOMINFOADD_ACK(Room r)
		{
			base.makeme();
			this._r = r;
		}

		protected internal override void write()
		{
			base.writeH(3088);
			base.writeS(this._r.getLeader().getPlayerName(), 33);
			base.writeC((byte)this._r.killtime);
			base.writeC((byte)(this._r.getRedWinRounds() + this._r.getBlueWinRounds()));
			base.writeH((short)this._r._timeRoom);
			base.writeC((byte)this._r.limit);
			base.writeC((byte)this._r.seeConf);
			base.writeH((short)this._r.autobalans);
		}
	}
}
