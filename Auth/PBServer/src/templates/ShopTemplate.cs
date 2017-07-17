using PBServer.src.commons.utils;
using System;

namespace PBServer.src.templates
{
	public class ShopTemplate : ItemTemplate
	{
		public static int _dalnost;

		public static int _razbros;

		public static int _uron;

		public ShopTemplate(ParamSet set)
		{
			base.setParameters(set);
			this._id = set.getInt32("id");
			this._name = set.getString("name");
			this._price = set.getInt32("price");
			base._count = set.getInt32("count");
			this._type2 = set.getInt32("buy_type2");
			base._buy_type = set.getInt32("buy_type");
			this._price2 = set.getInt32("price2");
			this._noname = set.getInt32("noname");
			this._new = set.getInt32("new");
			ShopTemplate._uron = set.getInt32("uron", 30);
			ShopTemplate._dalnost = set.getInt32("dalnost", 100);
			ShopTemplate._razbros = set.getInt32("uron", 10);
		}
	}
}
