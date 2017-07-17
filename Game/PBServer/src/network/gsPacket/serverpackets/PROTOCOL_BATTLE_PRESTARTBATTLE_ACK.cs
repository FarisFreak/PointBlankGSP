using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;
using System.Net;

namespace PBServer.src.network.gsPacket.serverpackets
{
	internal class PROTOCOL_BATTLE_PRESTARTBATTLE_ACK : SendBaseGamePacket
	{
		private Account _player;

		private Room _room;

		public PROTOCOL_BATTLE_PRESTARTBATTLE_ACK(Account p)
		{
			base.makeme();
			this._player = p;
			this._room = p.getRoom();
		}

		protected internal override void write()
		{
			base.writeH(3349);
			base.writeD((int)((short)this._room.isBattleInt()));
			base.writeD(this._player.getSlot());
			base.writeC((byte)this._room.getServerType());
			base.writeB(this._player.getRoom().getLeader().publicAdddress());
			base.writeH(29890);
			base.writeB(this._player.getRoom().getLeader().publicAdddress());
			base.writeH(29890);
			base.writeC(0);
			base.writeB(this._player.publicAdddress());
			base.writeH(29890);
			base.writeB(this._player.publicAdddress());
			base.writeH(29890);
			base.writeC(0);
			base.writeB(IPAddress.Parse(Config.UDPHost).GetAddressBytes());
			base.writeE(60000);
			base.writeB(new byte[]
			{
				145,
				0,
				0,
				0,
				71,
				6,
				0,
				0
			});
			base.writeC(0);
			base.writeB(new byte[]
			{
				10,
				34,
				0,
				1,
				16,
				3,
				30,
				5,
				6,
				7,
				4,
				9,
				22,
				11,
				27,
				8,
				14,
				15,
				2,
				17,
				18,
				33,
				20,
				21,
				19,
				23,
				24,
				25,
				26,
				12,
				28,
				29,
				13,
				31,
				32
			});
		}
	}
}
