using PBServer.src.model.accounts;
using PBServer.src.network.gsPacket.serverpackets;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_GIVEUPBATTLE_REQ : ReceiveBaseGamePacket
	{
		private int slot = 0;

		public PROTOCOL_BATTLE_GIVEUPBATTLE_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.slot = base.readD();
		}

		protected internal override void run()
		{
			Account[] array = base.getClient().getPlayer().getRoom().getAllPlayers().ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				Account account = array[i];
				account.sendPacket(new PROTOCOL_BATTLE_GIVEUPBATTLE_ACK(this.slot));
			}
		}
	}
}
