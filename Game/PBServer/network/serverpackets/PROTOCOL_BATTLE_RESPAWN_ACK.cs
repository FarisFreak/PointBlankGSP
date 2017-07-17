using PBServer.network.clientpacket;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BATTLE_RESPAWN_ACK : SendBaseGamePacket
	{
		private ResInfo _info;

		private Room _room;

		private Account _p;

		public PROTOCOL_BATTLE_RESPAWN_ACK(ResInfo info, Account p, Room room)
		{
			base.makeme();
			this._info = info;
			this._room = room;
			this._p = p;
		}

		protected internal override void write()
		{
			base.writeH(3338);
			base.writeD(this._p.getSlot());
			base.writeD(2);
			base.writeD(1);
			base.writeD(this._info.first1);
			base.writeD(this._info.second1);
			base.writeD(this._info.third1);
			base.writeD(this._info.fourth1);
			base.writeD(this._info.fifth1);
			base.writeD(this._info.id1);
			base.writeB(new byte[]
			{
				64,
				64,
				64,
				64,
				64,
				1
			});
			base.writeD(this._info.red1);
			base.writeD(this._info.blue1);
			base.writeD(this._info.head1);
			base.writeD(this._info.beret1);
			base.writeD(this._info.dino1);
		}
	}
}
