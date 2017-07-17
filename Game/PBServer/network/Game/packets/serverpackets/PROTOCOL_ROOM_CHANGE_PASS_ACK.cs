using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_CHANGE_PASS_ACK : SendBaseGamePacket
	{
		private string _pass;

		public PROTOCOL_ROOM_CHANGE_PASS_ACK(string pass)
		{
			base.makeme();
			this._pass = pass;
		}

		protected internal override void write()
		{
			base.writeH(3907);
			base.writeS(this._pass, 4);
		}
	}
}
