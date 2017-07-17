using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ : ReceiveBaseGamePacket
	{
		public PROTOCOL_LOBBY_QUICKJOIN_ROOM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
				bool flag2 = channel.getRooms().Count == 0;
				if (flag2)
				{
					base.getClient().sendPacket(new PROTOCOL_LOBBY_QUICKJOIN_ROOM_ACK());
				}
				else
				{
					bool flag3 = player != null;
					if (flag3)
					{
						Random random = new Random();
						int value = channel.getRooms().Count - 1;
						int num = random.Next(Convert.ToInt32(0), Convert.ToInt32(value));
						CLogger.getInstance().info("[Room] id chosen: " + num);
						Room room = channel.getRooms()[num];
						Room roomInId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(num);
						bool flag4 = roomInId != null;
						if (flag4)
						{
							int slot = roomInId.addPlayer(player);
							CLogger.getInstance().info("[Room] " + player.player_name + " walked into a room.");
							player.setSlot(slot);
							player.setRoom(roomInId);
							for (int i = 0; i < 16; i++)
							{
								int playerId = roomInId.getSlot(i)._playerId;
								bool flag5 = playerId > 0;
								if (flag5)
								{
									Account playerFromPlayerId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId);
									bool flag6 = playerFromPlayerId != null && playerFromPlayerId.player_id != base.getClient().getPlayer().player_id;
									if (flag6)
									{
										playerFromPlayerId.sendPacket(new PROTOCOL_ROOM_PLAYER_ENTER_ACK(player));
									}
								}
							}
							player.sendPacket(new PROTOCOL_LOBBY_JOIN_ROOM_ACK((long)num, player));
						}
						else
						{
							player.sendPacket(new PROTOCOL_LOBBY_JOIN_ROOM_ACK((2147479548L), null));
						}
					}
					else
					{
						player.sendPacket(new PROTOCOL_LOBBY_JOIN_ROOM_ACK((2147479548L), null));
					}
				}
			}
		}
	}
}
