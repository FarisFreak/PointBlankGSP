using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK : SendBaseGamePacket
	{
		private string message;

		private string owner;

		public PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(string owner, string message)
		{
			base.makeme();
			this.owner = owner;
			this.message = message;
		}

		protected internal override void write()
		{
			base.writeH(427);
			base.writeD(0);
			base.writeD(0);
			base.writeD(2);
			base.writeD(3);
			base.writeC(4);
			base.writeC(5);
			base.writeC(6);
			base.writeC(Convert.ToByte(this.owner.Length));
			base.writeC(33);
			base.writeS(this.owner, this.owner.Length);
			base.writeS(this.message, this.message.Length);
		}
	}
}
