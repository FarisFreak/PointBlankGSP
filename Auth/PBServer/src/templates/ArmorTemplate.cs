using PBServer.src.commons.utils;
using System;

namespace PBServer.src.templates
{
	public class ArmorTemplate : ItemTemplate
	{
		public static int _dalnost;

		public static int _razbros;

		public static int _uron;

		public ArmorTemplate(ParamSet set)
		{
			base.setParameters(set);
			this._id = set.getInt32("id");
			this._name = set.getString("name");
		}
	}
}
