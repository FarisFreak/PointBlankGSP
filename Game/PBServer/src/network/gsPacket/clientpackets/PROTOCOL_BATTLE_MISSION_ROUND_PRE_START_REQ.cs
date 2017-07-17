using Network.SendPackets;
using PBServer.network;
using PBServer.network.BattleConnect;
using PBServer.src.model.accounts;
using System;

namespace PBServer.src.network.gsPacket.clientpackets
{
	public class PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_REQ : ReceiveBaseGamePacket
	{
		private int itemid;

		public PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.itemid = base.readD();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			UdpHandler.getInstance().RemovePlayerInRoom(player);
			player.sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK());
		}
	}
}
