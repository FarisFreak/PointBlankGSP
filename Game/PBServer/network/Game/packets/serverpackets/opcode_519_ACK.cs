using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class opcode_519_ACK : SendBaseGamePacket
	{
		public opcode_519_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(519);
			base.writeD(0);
			base.writeC(11);
			base.writeC(1);
			base.writeH(0);
			base.writeS("TEST", 16);
			base.writeC(0);
			base.writeB(new byte[29]);
			base.writeS("BallDev", 33);
			base.writeS("Clan Test Point Blank EPICPB.Th", 255);
			base.writeB(new byte[389]);
		}
	}
}
