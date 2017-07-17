using PBServer.model.players;
using System;

namespace PBServer.src.model.accounts
{
	public class ShopInfo
	{
		public int buy_type;

		public int buy_type2;

		public int count;

		public int equip;

		public int good_id;

		public ItemsModel item;

		public int item_id;

		public string item_name;

		public int price_cash;

		public int price_gold;

		public int tag;

		public int title;

		public int getBuyType()
		{
			return this.buy_type;
		}

		public int getBuyType2()
		{
			return this.buy_type2;
		}

		public int getGoodId()
		{
			return this.good_id;
		}

		public int getItemCash()
		{
			return this.price_cash;
		}

		public int getItemCount()
		{
			return this.count;
		}

		public ItemsModel getItem()
		{
			return this.item;
		}

		public int getItemEquip()
		{
			return this.equip;
		}

		public int getItemGold()
		{
			return this.price_gold;
		}

		public int getItemId()
		{
			return this.item_id;
		}

		public string getItemName()
		{
			return this.item_name;
		}

		public int getTag()
		{
			return this.tag;
		}

		public int getTitleId()
		{
			return this.title;
		}
	}
}
