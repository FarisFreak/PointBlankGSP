using System;
using System.Collections.Generic;

namespace PBServer.model
{
	public class FragInfos
	{
		public byte[] bytes13;

		public List<Frag> frags = new List<Frag>();

		public int killerIdx;

		public int killsCount;

		public short Message;

		public byte[] remBytes;

		public int victimIdx;

		public int weapon;
	}
}
