using PBServer.src.commons.utils;
using System;

namespace PBServer.src.templates
{
	public class WeaponTemplate : ItemTemplate
	{
		public static int _dalnost;

		public static int _razbros;

		public static int _uron;

		public WeaponTemplate(ParamSet set)
		{
			base.setParameters(set);
			this._id = set.getInt32("id");
			this._name = set.getString("name");
			WeaponTemplate._uron = set.getInt32("uron", 30);
			WeaponTemplate._dalnost = set.getInt32("dalnost", 100);
			WeaponTemplate._razbros = set.getInt32("uron", 10);
		}
	}
}
