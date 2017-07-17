using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_MISSION_ROUND_START_ACK : SendBaseGamePacket
	{
		private Room _r;

		public PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(Room r)
		{
			this._r = r;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3371);
			base.writeC(2);
			base.writeD(this._r.getTimeByMask() * 60);
			base.writeH(3);
		}
	}
}
