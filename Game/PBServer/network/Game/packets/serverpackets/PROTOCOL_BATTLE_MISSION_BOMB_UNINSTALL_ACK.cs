using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK : SendBaseGamePacket
	{
		public int slot;

		public PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK(int slot)
		{
			this.slot = slot;
		}

		protected internal override void write()
		{
			base.writeH(3359);
			base.writeD(this.slot);
		}
	}
}
