using Network.SendPackets;
using PBServer;
using PBServer.network;
using PBServer.src.model.accounts;
using System;

namespace Network.ReceivePackets
{
	internal class PROTOCOL_BASE_GET_RECORD_INFO_DB_REQ : ReceiveBaseGamePacket
	{
		private int player_id;

		public PROTOCOL_BASE_GET_RECORD_INFO_DB_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.player_id = base.readD();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				try
				{
					Account player = base.getClient().getPlayer();
					player.sendPacket(new PROTOCOL_BASE_GET_RECORD_INFO_DB_ACK(player.getPlayerId()));
				}
				catch (Exception ex)
				{
					CLogger.getInstance().info(ex.ToString());
				}
			}
		}
	}
}
