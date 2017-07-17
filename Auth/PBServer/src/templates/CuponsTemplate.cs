using PBServer.src.commons.utils;
using System;

namespace PBServer.src.templates
{
	public class CuponsTemplate : ItemTemplate
	{
		public static int _dalnost;

		public static int _razbros;

		public static int _uron;

		public CuponsTemplate(ParamSet set)
		{
			base.setParameters(set);
			this._id = set.getInt32("id");
			this._name = set.getString("name");
			CuponsTemplate._uron = set.getInt32("uron", 30);
			CuponsTemplate._dalnost = set.getInt32("dalnost", 100);
			CuponsTemplate._razbros = set.getInt32("uron", 10);
		}
	}
}
