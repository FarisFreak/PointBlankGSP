using System;

namespace PBServer.network.web.function
{
	public static class Utilits
	{
		public static string[] getAccInfo(string data)
		{
			string[] array = new string[2];
			try
			{
				string[] array2 = data.Split(new string[]
				{
					"login="
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"&"
				}, StringSplitOptions.None)[0].Split(new char[]
				{
					' '
				});
				array[0] = array2[0];
				string[] array3 = data.Split(new string[]
				{
					"password="
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"&"
				}, StringSplitOptions.None)[0].Split(new string[]
				{
					" "
				}, StringSplitOptions.None);
				array[1] = array3[0];
			}
			catch
			{
			}
			return array;
		}

		public static string getCookieAuth(string data)
		{
			string result = "";
			try
			{
				result = data.Split(new string[]
				{
					"auth="
				}, StringSplitOptions.None)[1].Split(new string[]
				{
					"\r\n\r\n"
				}, StringSplitOptions.None)[0].Split(new string[]
				{
					";"
				}, StringSplitOptions.RemoveEmptyEntries)[0];
			}
			catch
			{
			}
			return result;
		}

		public static string getLoginWeb(string data)
		{
			string[] array = data.Split(new string[]
			{
				"login="
			}, StringSplitOptions.None);
			bool flag = array.Length <= 1;
			string result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = array[1].Split(new char[]
				{
					' ',
					'&'
				})[0];
			}
			return result;
		}

		public static string tokenGenerator()
		{
			string text = "";
			Random random = new Random();
			char[] array = new char[]
			{
				'a',
				'b',
				'c',
				'd',
				'e',
				'f',
				'g',
				'h',
				'i',
				'j',
				'k',
				'l',
				'm',
				'n',
				'o',
				'p',
				'q',
				'r',
				's',
				't',
				'u',
				'v',
				'w',
				'x',
				'y',
				'z',
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'0'
			};
			for (int i = 0; i < 45; i++)
			{
				text += Convert.ToString(array[random.Next(0, 36)]);
			}
			return text;
		}
	}
}
