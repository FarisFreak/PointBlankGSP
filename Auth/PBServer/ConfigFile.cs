using System;
using System.Collections.Generic;
using System.IO;

namespace PBServer
{
	internal class ConfigFile
	{
		public SortedList<string, string> _topics;

		private FileInfo File;

		public ConfigFile(string Path)
		{
			this.File = new FileInfo(Path);
			this._topics = new SortedList<string, string>();
			this.reload();
		}

		public string getProperty(string value, string defaultprop)
		{
			string text;
			string result;
			try
			{
				text = this._topics[value];
			}
			catch
			{
				CLogger.getInstance().warning("|[CF]| Não foi encontrado o parametro: " + value);
				result = defaultprop;
				return result;
			}
			result = ((text == null) ? defaultprop : text);
			return result;
		}

		public void reload()
		{
			StreamReader streamReader = new StreamReader(this.File.FullName);
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				bool flag = text.Length != 0 && !text.StartsWith(";");
				if (flag)
				{
					this._topics.Add(text.Split(new char[]
					{
						'='
					})[0], text.Split(new char[]
					{
						'='
					})[1]);
				}
			}
		}
	}
}
