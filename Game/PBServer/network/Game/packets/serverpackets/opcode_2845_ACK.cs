using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_2845_ACK : SendBaseGamePacket
	{
		public opcode_2845_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(2846);
			base.writeD(200004006);
			base.writeD(601002003);
			base.writeD(702001001);
			base.writeD(803007001);
			base.writeD(904007002);
			base.writeD(1001001005);
			base.writeD(1001002006);
			base.writeD(1102003001);
			base.writeD(0);
			base.writeD(1006001024);
		}
	}
}
