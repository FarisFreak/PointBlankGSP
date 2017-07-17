using PBServer.src.commons.utils;
using System;

namespace PBServer.src.templates
{
	public abstract class AbstractTemplate
	{
		private ParamSet _parameters;

		public ParamSet getParameters()
		{
			return this._parameters;
		}

		protected void setParameters(ParamSet set)
		{
			this._parameters = set;
		}
	}
}
