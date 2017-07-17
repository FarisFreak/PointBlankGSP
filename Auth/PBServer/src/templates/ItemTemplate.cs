using System;

namespace PBServer.src.templates
{
	public class ItemTemplate : AbstractTemplate
	{
		protected int _id;

		protected string _name;

		protected int _new;

		protected int _noname;

		protected int _price;

		protected int _price2;

		protected int _type;

		protected int _type2;

		public int _buy_type
		{
			get;
			set;
		}

		public int _count
		{
			get;
			set;
		}

		public int getBuyType()
		{
			return this._buy_type;
		}

		public int getBuyType2()
		{
			return this._type2;
		}

		public int getItemCount()
		{
			return this._count;
		}

		public int getItemId()
		{
			return this._id;
		}

		public string getItemName()
		{
			return this._name;
		}

		public int getItemNew()
		{
			return this._new;
		}

		public int getItemPrice()
		{
			return this._price;
		}

		public int getItemPrice2()
		{
			return this._price2;
		}

		public int getItemType()
		{
			return this._type;
		}

		public int getNoName()
		{
			return this._noname;
		}
	}
}
