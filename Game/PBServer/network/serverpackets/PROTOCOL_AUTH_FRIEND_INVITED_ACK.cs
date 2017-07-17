using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_AUTH_FRIEND_INVITED_ACK : SendBaseGamePacket
	{
		private int error;

		private string name;

		public PROTOCOL_AUTH_FRIEND_INVITED_ACK(string player_name, int error)
		{
			base.makeme();
			this.name = player_name;
			this.error = error;
		}

		protected internal override void write()
		{
			base.writeH(276);
			bool flag = this.error == 0;
			if (flag)
			{
				base.writeB(new byte[]
				{
					27,
					0,
					23,
					1,
					1,
					0,
					8
				});
				base.writeS(this.name, this.name.Length);
			}
		}
	}
}
