using PBServer.data.model;
using PBServer.data.xml.holders;
using PBServer.model.players;
using PBServer.network.serverpackets;
using PBServer.src.data.xml.holders;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_LOBBY_CREATE_NICK_NAME_REQ : ReceiveBaseGamePacket
	{
		private string name;

		private byte name_lenght;

		public PROTOCOL_LOBBY_CREATE_NICK_NAME_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.name_lenght = base.readC();
			this.name = base.readS((int)(this.name_lenght - 1));
		}

		protected internal override void run()
		{
			GameClient client = base.getClient();
			PlayerTemplate playerTemplate = PlayerTemplateHolder.getPlayerTemplate(Config.PlayerTemplateId);
			bool flag = !AccountManager.getInstance().isPlayerNameExist(this.name);
			if (flag)
			{
				AccountManager.getInstance().get(base.getClient().getPlayer().name).setRank(playerTemplate._rank);
				AccountManager.getInstance().get(base.getClient().getPlayer().name).setExp(playerTemplate._exp);
				AccountManager.getInstance().get(base.getClient().getPlayer().name).setGP(playerTemplate._gp);
				AccountManager.getInstance().get(base.getClient().getPlayer().name).setPlayerName(this.name);
				PlayerInventory playerInventory = new PlayerInventory(base.getClient().getPlayer().getPlayerId());
				Account account = AccountManager.getInstance().get(base.getClient().getPlayer().name);
				int num = AccountManager.getInstance().CreatePlayer(client.getPlayer().name, account);
				bool flag2 = num >= 0;
				if (flag2)
				{
					for (int i = 0; i < playerTemplate._startInventory.Count; i++)
					{
						ItemsModel item = new ItemsModel
						{
							id = playerTemplate._startInventory[i].id,
							slot = playerTemplate._startInventory[i].slot
						};
						playerInventory.getItemsAll().Add(item);
					}
					account.setInventory(playerInventory);
					base.getClient().setAccount(account.player_id);
					base.getClient().sendPacket(new PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK(0L));
					ChannelInfoHolder.getChannel(base.getClient().getChannelId()).addPlayer(account);
				}
				else
				{
					bool flag3 = num == -1;
					if (flag3)
					{
						base.getClient().sendPacket(new PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK(2147483373L));
					}
					else
					{
						base.getClient().sendPacket(new PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK(2147483373L));
					}
				}
			}
			else
			{
				base.getClient().sendPacket(new PROTOCOL_LOBBY_CREATE_NICK_NAME_ACK(2147483373L));
			}
			CLogger.getInstance().debug("[Create Player] Player Name: " + this.name);
		}
	}
}
