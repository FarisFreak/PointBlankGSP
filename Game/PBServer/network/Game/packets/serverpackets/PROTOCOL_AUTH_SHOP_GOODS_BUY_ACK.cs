using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK : SendBaseGamePacket
	{
		private int _slot;

		private int error;

		private ShopInfo item;

		private Account player;

		public PROTOCOL_AUTH_SHOP_GOODS_BUY_ACK(int error, ShopInfo item, Account player)
		{
			base.makeme();
			this.error = error;
			this.item = item;
			this.player = player;
		}

		protected internal override void write()
		{
			bool flag = this.item.getItemId() < 700000000 && this.item.getItemId() > 600000000;
			if (flag)
			{
				this._slot = 2;
			}
			bool flag2 = this.item.getItemId() < 800000000 && this.item.getItemId() > 700000000;
			if (flag2)
			{
				this._slot = 3;
			}
			bool flag3 = this.item.getItemId() < 900000000 && this.item.getItemId() > 800000000;
			if (flag3)
			{
				this._slot = 4;
			}
			bool flag4 = this.item.getItemId() < 1000000000 && this.item.getItemId() > 900000000;
			if (flag4)
			{
				this._slot = 5;
			}
			bool flag5 = this.item.getItemId() < 1001002000 && this.item.getItemId() > 1001001000;
			if (flag5)
			{
				this._slot = 6;
			}
			bool flag6 = this.item.getItemId() < 1001003000 && this.item.getItemId() > 1001002000;
			if (flag6)
			{
				this._slot = 7;
			}
			bool flag7 = this.item.getItemId() < 1104004000 && this.item.getItemId() > 1104003000;
			if (flag7)
			{
				this._slot = 8;
			}
			bool flag8 = this.item.getItemId() < 1105004000 && this.item.getItemId() > 1105003000;
			if (flag8)
			{
				this._slot = 8;
			}
			bool flag9 = this.item.getItemId() < 1102004000 && this.item.getItemId() > 1102003000;
			if (flag9)
			{
				this._slot = 8;
			}
			bool flag10 = this.item.getItemId() < 1103004000 && this.item.getItemId() > 1103003000;
			if (flag10)
			{
				this._slot = 10;
			}
			bool flag11 = this.item.getItemId() < 1006004000 && this.item.getItemId() > 1006001000;
			if (flag11)
			{
				this._slot = 9;
			}
			bool flag12 = this.item.getItemId() < 1301510000 && this.item.getItemId() > 1300002000;
			if (flag12)
			{
				this._slot = 11;
			}
			base.writeH(531);
			bool flag13 = this.error == 0;
			if (flag13)
			{
				base.writeD(1);
				base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
				base.writeD((this._slot >= 5 && this._slot < 11) ? 1 : 0);
				base.writeD((this._slot < 5) ? 1 : 0);
				base.writeD(0);
				base.writeD(this.player.getGP());
				base.writeD(this.player.getMoney());
				base.writeD(0);
				base.writeC((byte)this.item.getBuyType());
				base.writeD(this.item.getItemCount());
				base.writeD(this.player.getGP());
				base.writeD(this.player.getMoney());
				this.player.getInventory().addNewItem(this.item.getItemId(), this._slot, this.item.getItemEquip(), this.item.getItemCount());
			}
			else
			{
				base.writeD(this.error);
			}
		}
	}
}
