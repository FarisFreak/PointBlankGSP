using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_GET_POINT_CASH_ACK : SendBaseGamePacket
	{
		private Account _player;

		public PROTOCOL_AUTH_GET_POINT_CASH_ACK(Account player)
		{
			base.makeme();
			this._player = player;
		}

		protected internal override void write()
		{
			base.writeH(545);
			base.writeD(1);
			base.writeD(this._player.getGP());
			base.writeD(this._player.getMoney());
		}
	}
}
