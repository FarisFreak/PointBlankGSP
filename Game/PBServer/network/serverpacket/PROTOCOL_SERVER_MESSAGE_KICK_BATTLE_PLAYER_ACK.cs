using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK : SendBaseGamePacket
	{
		private int error;

		public PROTOCOL_SERVER_MESSAGE_KICK_BATTLE_PLAYER_ACK(int error)
		{
			base.makeme();
			this.error = error;
		}

		protected internal override void write()
		{
			base.writeH(2052);
			base.writeD(this.error);
		}
	}
}
