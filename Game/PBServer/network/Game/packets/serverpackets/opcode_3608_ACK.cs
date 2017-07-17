using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_3608_ACK : SendBaseGamePacket
	{
		private int _autobalans;

		private int _killtime;

		private string _leader;

		private int _limit;

		private int _seeConf;

		public opcode_3608_ACK(int autobalans, int seeConf, int killtime, int limit, string leader)
		{
			base.makeme();
			this._autobalans = autobalans;
			this._seeConf = seeConf;
			this._killtime = killtime;
			this._limit = limit;
			this._leader = leader;
		}

		protected internal override void write()
		{
			base.writeH(3859);
			base.writeS(this._leader, 33);
			base.writeD(this._killtime);
			base.writeC((byte)this._limit);
			base.writeC((byte)this._seeConf);
			base.writeH((short)this._autobalans);
		}
	}
}
