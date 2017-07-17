using PBServer.network.serverpackets;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_AUTH_FIND_USER_REQ : ReceiveBaseGamePacket
	{
		private string name;

		public PROTOCOL_AUTH_FIND_USER_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.name = base.readS(33);
			CLogger.getInstance().info("[Player] name " + this.name);
		}

		protected internal override void run()
		{
			base.getClient().sendPacket(new PROTOCOL_AUTH_FIND_USER_ACK());
		}
	}
}
