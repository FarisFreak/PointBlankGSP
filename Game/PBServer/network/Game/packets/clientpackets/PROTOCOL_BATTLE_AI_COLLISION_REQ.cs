using PBServer.network.BattleConnect;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_AI_COLLISION_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_BATTLE_AI_COLLISION_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			bool flag = player != null && room != null;
			if (flag)
			{
				bool flag2 = room._aiLevel < 10;
				if (flag2)
				{
					room._aiLevel++;
				}
				for (int i = 0; i < 16; i++)
				{
					Account playerFromPlayerId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(room.getSlot(i)._playerId);
					bool flag3 = playerFromPlayerId != null;
					if (flag3)
					{
						playerFromPlayerId.sendPacket(new PROTOCOL_BATTLE_AI_COLLISION_ACK(room));
					}
				}
				UdpHandler.getInstance().PingUdpServer();
			}
		}
	}
}
