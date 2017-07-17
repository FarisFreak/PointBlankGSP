using System;
using System.IO;
using System.Text;

namespace PBServer.Network
{
	internal class Utils
	{
		public static string HexDump(byte[] bytes)
		{
			int num = 16;
			bool flag = bytes == null;
			string result;
			if (flag)
			{
				result = "<null>";
			}
			else
			{
				int num2 = bytes.Length;
				char[] array = "0123456789ABCDEF".ToCharArray();
				int num3 = 11;
				int num4 = num3 + num * 3 + (num - 1) / 8 + 2;
				int num5 = num4 + num + Environment.NewLine.Length;
				char[] array2 = (new string(' ', num5 - 2) + Environment.NewLine).ToCharArray();
				int num6 = (num2 + num - 1) / num;
				StringBuilder stringBuilder = new StringBuilder(num6 * num5);
				for (int i = 0; i < num2; i += num)
				{
					array2[0] = array[i >> 28 & 15];
					array2[1] = array[i >> 24 & 15];
					array2[2] = array[i >> 20 & 15];
					array2[3] = array[i >> 16 & 15];
					array2[4] = array[i >> 12 & 15];
					array2[5] = array[i >> 8 & 15];
					array2[6] = array[i >> 4 & 15];
					array2[7] = array[i & 15];
					int num7 = num3;
					int num8 = num4;
					for (int j = 0; j < num; j++)
					{
						bool flag2 = j > 0 && (j & 7) == 0;
						if (flag2)
						{
							num7++;
						}
						bool flag3 = i + j >= num2;
						if (flag3)
						{
							array2[num7] = ' ';
							array2[num7 + 1] = ' ';
							array2[num8] = ' ';
						}
						else
						{
							byte b = bytes[i + j];
							array2[num7] = array[b >> 4 & 15];
							array2[num7 + 1] = array[(int)(b & 15)];
							array2[num8] = (char)((b < 32) ? 183 : b);
						}
						num7 += 3;
						num8++;
					}
					stringBuilder.Append(array2);
				}
				result = stringBuilder.ToString();
			}
			return result;
		}

		public static void LogText(string Texto, string Archive)
		{
			bool flag = !File.Exists(Archive);
			StreamWriter streamWriter;
			if (flag)
			{
				streamWriter = new StreamWriter(Archive);
			}
			else
			{
				streamWriter = File.AppendText(Archive);
			}
			streamWriter.WriteLine(Texto);
			streamWriter.Close();
		}

		public static string Function0x(byte[] Data)
		{
			string text = "";
			for (int i = 0; i < Data.Length; i++)
			{
				bool flag = i != Data.Length - 1;
				if (flag)
				{
					text = text + "0x" + Data[i].ToString("X2") + ",";
				}
				else
				{
					text = text + "0x" + Data[i].ToString("X2");
				}
			}
			return text;
		}
	}
}
