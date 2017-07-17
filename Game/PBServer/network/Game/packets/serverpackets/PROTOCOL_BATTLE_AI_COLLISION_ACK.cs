using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_AI_COLLISION_ACK : SendBaseGamePacket
	{
		private Room _room;

		public PROTOCOL_BATTLE_AI_COLLISION_ACK(Room r)
		{
			this._room = r;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3890);
			base.writeC(Convert.ToByte((this._room._aiLevel <= 10) ? this._room._aiLevel : 10));
			for (int i = 0; i < 8; i++)
			{
				base.writeD(1);
				base.writeD(1);
			}
		}
	}
}
