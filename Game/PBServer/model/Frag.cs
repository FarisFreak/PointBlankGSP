using System;

namespace PBServer.model
{
	public class Frag
	{
		public byte[] bytes131;

		public int hitspotNum;

		public int unk_c_1;

		public int unk_c_3;

		public int unk_c_4;

		public int getDeatSlot()
		{
			return this.hitspotNum & 15;
		}
	}
}
