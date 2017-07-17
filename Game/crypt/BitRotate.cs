using System;

namespace crypt
{
	internal class BitRotate
	{
		public static void decrypt(byte[] a1)
		{
			byte b = (byte)a1.Length;
			byte b2 = 7;
			int i = a1.Length - 1;
			int num = 1;
			byte b3 = a1[a1.Length - 1];
			while (i >= 0)
			{
				byte b4 = (byte)((int)((i > 0) ? a1[i - 1] : b3) << num | a1[i--] >> (int)b2);
				a1[i + 1] = b4;
			}
		}

		public static void encrypt(byte[] a1)
		{
			int num = 7;
			byte b = a1[0];
			int num2 = 1;
			int num3 = 0;
			int num4 = 1;
			bool flag = a1.Length != 0;
			if (flag)
			{
				while (true)
				{
					int num5 = (int)((num3 >= a1.Length - 1) ? b : a1[num3 + 1]);
					int num6 = (int)a1[num3++] << num;
					a1[num3 - 1] = (byte)(num6 | num5 >> num2);
					bool flag2 = num3 >= a1.Length;
					if (flag2)
					{
						break;
					}
					int num7 = (int)((ushort)num2 & 255);
					int num8 = (ushort)num2 >> 8;
					num2 = ((num4 & 255) | (num8 & 255) << 8);
				}
			}
		}
	}
}
