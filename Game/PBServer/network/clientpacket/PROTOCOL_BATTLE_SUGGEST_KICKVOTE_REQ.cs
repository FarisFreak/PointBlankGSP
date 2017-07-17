using PBServer.network.serverpacket;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BATTLE_SUGGEST_KICKVOTE_REQ : ReceiveBaseGamePacket
	{
		private int _slot;

		private int unk;

		public PROTOCOL_BATTLE_SUGGEST_KICKVOTE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this._slot = (int)base.readH();
			CLogger.getInstance().info("[Votekick] UNK1: " + this._slot);
			this.unk = (int)base.readC();
			CLogger.getInstance().info("[Votekick] UNK2: " + this.unk);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			CLogger.getInstance().info("[Votekick] " + base.getClient().getPlayer().getPlayerName().ToString() + " initiating a vote kick.");
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_BATTLE_SUGGEST_KICKVOTE_ACK());
			}
		}
	}
}
