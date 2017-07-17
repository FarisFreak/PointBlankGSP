using PBServer.network.Game.packets.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_ROOM_GET_PLAYERINFO_REQ : ReceiveBaseGamePacket
	{
		private int _slot;

		public PROTOCOL_ROOM_GET_PLAYERINFO_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readH();
			this._slot = base.readD();
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_ROOM_GET_PLAYERINFO_ACK(this._slot, base.getClient().getPlayer()));
		}
	}
}
