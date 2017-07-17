using System;
using System.Collections.Generic;
using System.IO;

namespace PBServer.data
{
	internal class NetworkBlock
	{
		protected List<NB_interface> blocks = new List<NB_interface>();

		private static NetworkBlock nb = new NetworkBlock();

		public NetworkBlock()
		{
			StreamReader streamReader = new StreamReader(new FileInfo("Data//NetworkBlock.xml").FullName);
			while (!streamReader.EndOfStream)
			{
				string text = streamReader.ReadLine();
				bool flag = text.Length != 0 && !text.StartsWith("//");
				if (flag)
				{
					bool flag2 = text.StartsWith("Ban-Ip");
					if (flag2)
					{
						NB_interface item = new NB_interface
						{
							directIp = text.Split(new char[]
							{
								' '
							})[1],
							forever = text.Split(new char[]
							{
								' '
							})[2].Equals("Yes")
						};
						this.blocks.Add(item);
					}
					else
					{
						bool flag3 = text.StartsWith("Ban");
						if (flag3)
						{
							NB_interface item2 = new NB_interface
							{
								mask = text.Split(new char[]
								{
									' '
								})[1],
								forever = text.Split(new char[]
								{
									' '
								})[2].Equals("Yes")
							};
							this.blocks.Add(item2);
						}
					}
				}
			}
			CLogger.getInstance().info("[Network] Block: " + this.blocks.Count + " blocks.");
		}

		public bool allowed(string ip)
		{
			bool flag = this.blocks.Count != 0;
			bool result;
			if (flag)
			{
				foreach (NB_interface current in this.blocks)
				{
					bool flag2 = current.directIp != null && current.directIp.Equals(ip) && (current.forever || current.timeEnd.CompareTo(DateTime.Now) == 1);
					if (flag2)
					{
						result = false;
						return result;
					}
					bool flag3 = current.mask != null;
					if (flag3)
					{
						string[] array = ip.Split(new char[]
						{
							'.'
						});
						string[] array2 = current.mask.Split(new char[]
						{
							'.'
						});
						bool[] array3 = new bool[4];
						for (byte b = 0; b < 4; b += 1)
						{
							array3[(int)b] = false;
							bool flag4 = array2[(int)b] == "*";
							if (flag4)
							{
								array3[(int)b] = true;
							}
							else
							{
								bool flag5 = array2[(int)b] == array[(int)b];
								if (flag5)
								{
									array3[(int)b] = true;
								}
								else
								{
									bool flag6 = array2[(int)b].Contains("/");
									if (flag6)
									{
										byte b2 = byte.Parse(array2[(int)b].Split(new char[]
										{
											'/'
										})[0]);
										byte b3 = byte.Parse(array2[(int)b].Split(new char[]
										{
											'/'
										})[1]);
										byte b4 = byte.Parse(array[(int)b]);
										array3[(int)b] = (b4 >= b2 && b4 <= b3);
									}
								}
							}
						}
						byte b5 = 0;
						bool[] array4 = array3;
						for (int i = 0; i < array4.Length; i++)
						{
							bool flag7 = array4[i];
							if (flag7)
							{
								b5 += 1;
							}
						}
						bool flag8 = b5 >= 4;
						if (flag8)
						{
							result = false;
							return result;
						}
					}
				}
			}
			result = true;
			return result;
		}

		public static NetworkBlock getInstance()
		{
			return NetworkBlock.nb;
		}
	}
}
