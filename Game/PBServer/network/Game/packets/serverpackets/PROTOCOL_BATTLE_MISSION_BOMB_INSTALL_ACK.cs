using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK : SendBaseGamePacket
	{
		public int zone;

		public int slot;

		public int x;

		public int y;

		public int z;

		public PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK(int zone, int slot, int x, int y, int z)
		{
			this.z = z;
			this.y = y;
			this.x = x;
			this.slot = slot;
			this.zone = zone;
		}

		protected internal override void write()
		{
			base.writeH(3357);
			base.writeD(this.slot);
			base.writeC((byte)this.zone);
			base.writeH(42);
			base.writeD(this.x);
			base.writeD(this.y);
			base.writeD(this.z);
		}
	}
}
