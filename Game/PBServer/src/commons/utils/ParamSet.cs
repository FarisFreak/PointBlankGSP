using System;
using System.Collections.Generic;

namespace PBServer.src.commons.utils
{
	public class ParamSet
	{
		private Dictionary<string, object> _params = new Dictionary<string, object>();

		public int getInt32(string name)
		{
			return this.getInt32(name, false);
		}

		public int getInt32(string name, bool remove)
		{
			object @object = this.getObject(name, remove);
			bool flag = @object == null;
			if (flag)
			{
				throw new ArgumentException("Int32 value required, but not specified: " + name);
			}
			return (int)@object;
		}

		public int getInt32(string name, int deflt)
		{
			return this.getInt32(name, deflt, false);
		}

		public int getInt32(string name, int deflt, bool remove)
		{
			object @object = this.getObject(name, remove);
			bool flag = @object == null;
			int result;
			if (flag)
			{
				result = deflt;
			}
			else
			{
				bool flag2 = @object.GetType() == typeof(int);
				if (flag2)
				{
					result = (int)@object;
				}
				else
				{
					int num;
					try
					{
						num = int.Parse((string)@object);
					}
					catch (Exception)
					{
						throw new ArgumentException("Int32 value required, but found: " + @object);
					}
					result = num;
				}
			}
			return result;
		}

		public object getObject(string name)
		{
			return this.getObject(name, false);
		}

		public object getObject(string name, bool remove)
		{
			bool flag = !this._params.ContainsKey(name);
			object result;
			if (flag)
			{
				result = null;
			}
			else if (remove)
			{
				result = (this._params.Remove(name) ? 1 : 0);
			}
			else
			{
				result = this._params[name];
			}
			return result;
		}

		public string getString(string name)
		{
			return this.getString(name, false);
		}

		public string getString(string name, bool remove)
		{
			object @object = this.getObject(name, remove);
			bool flag = @object == null;
			if (flag)
			{
				throw new ArgumentException("String value required, but not specified: " + name);
			}
			return @object.ToString();
		}

		public string getString(string name, string deflt)
		{
			return this.getString(name, deflt, false);
		}

		public string getString(string name, string deflt, bool remove)
		{
			object @object = this.getObject(name, remove);
			bool flag = @object == null;
			string result;
			if (flag)
			{
				result = deflt;
			}
			else
			{
				result = @object.ToString();
			}
			return result;
		}

		public void set(string paramName, object value)
		{
			this._params.Add(paramName, value);
		}
	}
}
