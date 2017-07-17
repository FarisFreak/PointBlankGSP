using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_PLAYER_UP_LEVEL : SendBaseGamePacket
	{
		private int _itemid;

		private int _rank;

		public SM_PLAYER_UP_LEVEL(int rank, int itemid)
		{
			base.makeme();
			this._rank = rank;
			this._itemid = itemid;
		}

		protected internal override void write()
		{
			base.writeH(2614);
			base.writeD(this._rank);
			base.writeD(1);
			base.writeD(this._itemid);
		}
	}
}
