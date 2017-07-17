using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_TEAM_ACK : SendBaseGamePacket
	{
		private int _oldSlot;

		private Account _p;

		private Room _r;

		public PROTOCOL_ROOM_CHANGE_TEAM_ACK(int oldSlot, Account player)
		{
			base.makeme();
			this._p = player;
			this._r = this._p.getRoom();
			this._oldSlot = oldSlot;
		}

		protected internal override void write()
		{
			base.writeH(3877);
			base.writeC(0);
			base.writeC((byte)this._r.getLeader().getSlot());
			base.writeC(1);
			base.writeC((byte)this._oldSlot);
			base.writeC((byte)this._p.getSlot());
			base.writeC((byte)this._r.getSlotState(this._oldSlot));
			base.writeC((byte)this._r.getSlotState(this._p.getSlot()));
		}
	}
}
