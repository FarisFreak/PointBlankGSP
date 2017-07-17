using Managers.Active;
using PBServer.model.players;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_INVENTORY_EQUIP_NOTUSED_REQ : ReceiveBaseGamePacket
	{
		private int obj_id;

		public PROTOCOL_INVENTORY_EQUIP_NOTUSED_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.obj_id = base.readD();
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				try
				{
					Account player = base.getClient().getPlayer();
					foreach (ItemsModel current in player.getInventory().getItemsAll())
					{
						bool flag2 = current.object_id == this.obj_id;
						if (flag2)
						{
							current.equip_type = 2;
						}
					}
					bool flag3 = DAOM.getInstance().getItem(this.obj_id) != null;
					if (flag3)
					{
						DAOM.getInstance().getItem(this.obj_id).equip_type = 2;
					}
					AccountManager.getInstance().updateStatusItem(this.obj_id);
					player.sendPacket(new PROTOCOL_INVENTORY_EQUIP_NOTUSED_ACK(this.obj_id, 2, player));
					player.sendPacket(new PROTOCOL_INVENTORY_ADD_ITEM_ACK(this.obj_id, 1, player.getPlayerId(), "", 86400, 2, player));
				}
				catch (Exception ex)
				{
					CLogger.getInstance().info(ex.ToString());
				}
			}
		}
	}
}
