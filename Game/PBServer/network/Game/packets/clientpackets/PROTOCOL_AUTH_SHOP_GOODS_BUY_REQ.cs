using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ : ReceiveBaseGamePacket
	{
		public int _count;

		public int _equip;

		private int _item;

		public string _item_name;

		public int _pcash;

		public int _pgold;

		private int _unk;

		private int _unk1;

		private int _unk2;

		public int id_player;

		public PROTOCOL_AUTH_SHOP_GOODS_BUY_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
			this.id_player = base.getClient().getPlayerId();
		}

		protected internal override void read()
		{
			this._unk = (int)base.readH();
			this._unk1 = (int)base.readC();
			this._item = base.readD();
			this._unk2 = (int)base.readC();
			bool flag = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 600000000;
			if (flag)
			{
				this._unk1 = 1;
			}
			bool flag2 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 700000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 600000000;
			if (flag2)
			{
				this._unk2 = 2;
			}
			bool flag3 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 800000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 700000000;
			if (flag3)
			{
				this._unk2 = 3;
			}
			bool flag4 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 900000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 800000000;
			if (flag4)
			{
				this._unk2 = 4;
			}
			bool flag5 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1000000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 900000000;
			if (flag5)
			{
				this._unk2 = 5;
			}
			bool flag6 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1001002000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1001001000;
			if (flag6)
			{
				this._unk2 = 6;
			}
			bool flag7 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1001003000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1001002000;
			if (flag7)
			{
				this._unk2 = 7;
			}
			bool flag8 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1104004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1104003000;
			if (flag8)
			{
				this._unk2 = 8;
			}
			bool flag9 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1105004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1105003000;
			if (flag9)
			{
				this._unk2 = 8;
			}
			bool flag10 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1102004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1102003000;
			if (flag10)
			{
				this._unk2 = 8;
			}
			bool flag11 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1103004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1103003000;
			if (flag11)
			{
				this._unk2 = 10;
			}
			bool flag12 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1006004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1006001000;
			if (flag12)
			{
				this._unk2 = 9;
			}
			bool flag13 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1301510000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1300002000;
			if (flag13)
			{
				this._unk2 = 11;
			}
			bool flag14 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 600000000;
			if (flag14)
			{
				this._unk1 = 1;
			}
			bool flag15 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 700000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 600000000;
			if (flag15)
			{
				this._unk1 = 1;
			}
			bool flag16 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 800000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 700000000;
			if (flag16)
			{
				this._unk1 = 1;
			}
			bool flag17 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 900000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 800000000;
			if (flag17)
			{
				this._unk1 = 1;
			}
			bool flag18 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1000000000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 900000000;
			if (flag18)
			{
				this._unk1 = 1;
			}
			bool flag19 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1001002000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1001001000;
			if (flag19)
			{
				this._unk1 = 2;
			}
			bool flag20 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1001003000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1001002000;
			if (flag20)
			{
				this._unk1 = 2;
			}
			bool flag21 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1104004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1104003000;
			if (flag21)
			{
				this._unk1 = 2;
			}
			bool flag22 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1102004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1102003000;
			if (flag22)
			{
				this._unk1 = 2;
			}
			bool flag23 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1102004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1102003000;
			if (flag23)
			{
				this._unk1 = 2;
			}
			bool flag24 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1105004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1105003000;
			if (flag24)
			{
				this._unk1 = 2;
			}
			bool flag25 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1103004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1103003000;
			if (flag25)
			{
				this._unk1 = 2;
			}
			bool flag26 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1006004000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1006001000;
			if (flag26)
			{
				this._unk1 = 2;
			}
			bool flag27 = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() < 1301510000 && ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId() > 1300002000;
			if (flag27)
			{
				this._unk1 = 3;
			}
			this._item_name = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemName();
			this._count = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemCount();
			this._equip = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemEquip();
			this._pgold = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemGold();
			this._pcash = ShopInfoManager.getInstance().getInfoItem2(this._item).getItemCash();
			CLogger.getInstance().warning("[Shop] " + base.getClient().getPlayer().getPlayerName().ToString() + " buy item name: " + ShopInfoManager.getInstance().getInfoItem(ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId()).getItemName());
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = ShopInfoManager.getInstance().getInfoItem2(this._item) == null || base.getClient().getPlayer().getGP() < this._pgold || base.getClient().getPlayer().getMoney() < this._pcash;
			if (flag)
			{
				base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(2147483647, null, null));
			}
			else
			{
				base.getClient().getPlayer().setGP(base.getClient().getPlayer().getGP() - this._pgold);
				base.getClient().getPlayer().setMoney(base.getClient().getPlayer().getMoney() - this._pcash);
				AccountManager.getInstance().UpdateMGP(base.getClient().getPlayer().getPlayerId(), base.getClient().getPlayer().getGP(), base.getClient().getPlayer().getMoney());
				base.getClient().sendPacket(new PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(0, ShopInfoManager.getInstance().getInfoItem2(this._item), base.getClient().getPlayer()));
				base.getClient().sendPacket(new PROTOCOL_INVENTORY_GET_INFO_ACK(ShopInfoManager.getInstance().getInfoItem2(this._item).getItemId(), this._unk2, this.id_player, this._item_name, this._count, this._equip, player));
			}
		}
	}
}
