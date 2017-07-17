using PBServer.network.BattleConnect;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_CHAT_NORMAL_REQ : ReceiveBaseGamePacket
	{
		private int _len;

		private Chat chat = new Chat();

		public PROTOCOL_CHAT_NORMAL_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this.chat.chat_type = base.readH();
			this._len = (int)base.readH();
			this.chat.chat = base.readS(this._len);
			this.chat.playername = base.getClient().getPlayer().getPlayerName();
		}

		protected internal override void run()
		{
			CLogger.getInstance().info(string.Concat(new string[]
			{
				"[Chat Normal] ",
				base.getClient().getPlayer().getPlayerName(),
				" send message: [",
				this.chat.chat,
				"]"
			}));
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			bool flag = room != null;
			if (flag)
			{
				try
				{
					bool flag2 = this.chat.chat.StartsWith("cmd ");
					if (flag2)
					{
						string text = this.chat.chat.Substring(4);
						bool flag3 = text.StartsWith("map ");
						if (flag3)
						{
							int map = int.Parse(text.Substring(4));
							this.chat.playername = "ServerCMD";
							this.chat.chat = "Changed map to " + map.ToString();
							room.CMDChangeMap(map, player);
						}
						else
						{
							bool flag4 = text.StartsWith("player go");
							if (flag4)
							{
								room.changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_LOAD, true);
								bool flag5 = base.getClient().getPlayer().getRoom().getLeader().player_id == base.getClient().getPlayer().player_id;
								if (flag5)
								{
									UdpHandler.getInstance().CreateBattleUdpRoom(base.getClient().getPlayer().getRoom(), 2);
								}
								this.chat.playername = "ServerCMD";
								this.chat.chat = "Player go!!!";
								room.setState(ROOM_STATE.ROOM_STATE_LOADING);
								player.sendPacket(new PROTOCOL_BATTLE_READYBATTLE_ACK(player, room));
								CLogger.getInstance().info("[Game::Chat]: Player enter command 'player go' player=" + base.getClient().getPlayer().player_name);
							}
						}
					}
					for (int i = 0; i < 15; i++)
					{
						Account playerBySlot = room.getPlayerBySlot(i);
						bool flag6 = playerBySlot != null;
						if (flag6)
						{
							playerBySlot.sendPacket(new PROTOCOL_ROOM_CHATTING_ACK(this.chat, player));
						}
					}
				}
				catch (Exception ex)
				{
					CLogger.getInstance().warning(ex.ToString());
				}
			}
			else
			{
				Channel channel = ChannelInfoHolder.getChannel(base.getClient().getChannelId());
				bool flag7 = channel != null;
				if (flag7)
				{
					for (int j = 0; j < channel.getWaitPlayers().Count; j++)
					{
						bool flag8 = channel.getWaitPlayers()[j] != null;
						if (flag8)
						{
							channel.getWaitPlayers()[j].sendPacket(new PROTOCOL_LOBBY_CHATTING_ACK(this.chat, player));
						}
					}
				}
			}
		}
	}
}
