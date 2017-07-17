using PBServer.network.Game.packets.serverpackets;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_JOIN_ROOM_REQ : ReceiveBaseGamePacket
	{
		private string password;

		private int roomID;

		public PROTOCOL_LOBBY_JOIN_ROOM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.roomID = base.readD();
			this.password = base.readS(4);
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				Room roomInId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getRoomInId(this.roomID);
				bool flag2 = roomInId != null;
				if (flag2)
				{
					bool flag3 = roomInId.password.Length > 0 && this.password != roomInId.password && player.getRank() != 53;
					if (flag3)
					{
						CLogger.getInstance().info("[Room] " + player.player_name + " wrong password to enter the room.");
						player.sendPacket(new PROTOCOL_LOBBY_PASSWORD_ERROR_ACK());
					}
					else
					{
						int slot = roomInId.addPlayer(player);
						CLogger.getInstance().info("[Room] " + player.player_name + " walked into a room.");
						player.setSlot(slot);
						player.setRoom(roomInId);
						for (int i = 0; i < 16; i++)
						{
							int playerId = roomInId.getSlot(i)._playerId;
							bool flag4 = playerId > 0;
							if (flag4)
							{
								Account playerFromPlayerId = ChannelInfoHolder.getChannel(base.getClient().getChannelId()).getPlayerFromPlayerId(playerId);
								bool flag5 = playerFromPlayerId != null && playerFromPlayerId.player_id != base.getClient().getPlayer().player_id;
								if (flag5)
								{
									playerFromPlayerId.sendPacket(new PROTOCOL_ROOM_PLAYER_ENTER_ACK(player));
								}
							}
						}
						player.sendPacket(new PROTOCOL_LOBBY_JOIN_ROOM_ACK((long)this.roomID, player));
					}
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
