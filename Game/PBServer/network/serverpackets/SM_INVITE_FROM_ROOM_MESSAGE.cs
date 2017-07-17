using System;

namespace PBServer.network.serverpackets
{
	public class SM_INVITE_FROM_ROOM_MESSAGE : SendBaseGamePacket
	{
		private string inviter;

		private int room_id;

		public SM_INVITE_FROM_ROOM_MESSAGE(string inviter, int room_id)
		{
			base.makeme();
			this.inviter = inviter;
			this.room_id = room_id;
		}

		protected internal override void write()
		{
			base.writeH(2053);
			base.writeS(this.inviter, 33);
			base.writeD(this.room_id);
		}
	}
}
