using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_MISSION_ROUND_END_ACK : SendBaseGamePacket
	{
		private int team;

		private Room room;

		private int type;

		public PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(int team, int type, Room room)
		{
			base.makeme();
			this.team = team;
			this.room = room;
			this.type = type;
		}

		protected internal override void write()
		{
			base.writeH(3353);
			base.writeC((byte)this.team);
			base.writeC((byte)this.type);
			base.writeH((short)this.room.getRedWinRounds());
			base.writeH((short)this.room.getBlueWinRounds());
		}
	}
}
