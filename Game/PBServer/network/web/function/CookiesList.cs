using System;

namespace PBServer.network.web.function
{
	public class CookiesList
	{
		private string _login = "";

		private string _value = "";

		public string getName()
		{
			return this._login;
		}

		public string getValue()
		{
			return this._value;
		}

		public void setLogin(string login)
		{
			this._login = login;
		}

		public void setValue(string value)
		{
			this._value = value;
		}
	}
}
