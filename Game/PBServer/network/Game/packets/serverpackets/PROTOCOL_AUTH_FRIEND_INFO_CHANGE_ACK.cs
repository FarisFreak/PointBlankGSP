using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK : SendBaseGamePacket
	{
		private Account _p;

		public PROTOCOL_AUTH_FRIEND_INFO_CHANGE_ACK(Account p)
		{
			this._p = p;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(279);
			base.writeC((byte)this._p.getRank());
			base.writeC(0);
			base.writeC(33);
			base.writeS(this._p.getPlayerName(), 33);
			base.writeB(new byte[]
			{
				0,
				0,
				6,
				3,
				80,
				32,
				32,
				1,
				0,
				0,
				0,
				0,
				0,
				25,
				159,
				73,
				0
			});
		}
	}
}
