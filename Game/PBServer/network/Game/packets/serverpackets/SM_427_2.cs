using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class SM_427_2 : SendBaseGamePacket
	{
		private string clan_name;

		private int message_id;

		public SM_427_2(string clan_name, int message_id)
		{
			base.makeme();
			this.clan_name = clan_name;
			this.message_id = message_id;
		}

		protected internal override void write()
		{
			base.writeH(427);
			byte[] array = new byte[]
			{
				0,
				249,
				171,
				247,
				63,
				171,
				253,
				254,
				242,
				199,
				113,
				252,
				251,
				250,
				255,
				255
			};
			array[0] = Convert.ToByte(this.message_id);
			base.writeB(array);
			base.writeB(new byte[]
			{
				21,
				7,
				15,
				151,
				126
			});
			base.writeS(this.clan_name, 16);
			base.writeB(new byte[]
			{
				2,
				1
			});
		}
	}
}
