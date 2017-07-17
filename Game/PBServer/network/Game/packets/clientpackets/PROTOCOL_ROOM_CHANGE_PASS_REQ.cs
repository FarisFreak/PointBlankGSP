using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	internal class PROTOCOL_ROOM_CHANGE_PASS_REQ : ReceiveBaseGamePacket
	{
		private string _pass;

		public PROTOCOL_ROOM_CHANGE_PASS_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._pass = base.readS(4);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			player.getRoom().password = this._pass;
			foreach (Account current in player.getRoom().getAllPlayers())
			{
				current.sendPacket(new PROTOCOL_ROOM_CHANGE_PASS_ACK(this._pass));
			}
		}
	}
}
