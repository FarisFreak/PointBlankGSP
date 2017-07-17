using Model;
using System;

namespace PBServer.network.serverpackets
{
	internal class PacketSendAttribute : Attribute
	{
		public short Id
		{
			get;
			set;
		}

		public PacketSendAttribute()
		{
			PacketOpcode packetOpcode;
			bool flag = Enum.TryParse<PacketOpcode>(base.GetType().Name, out packetOpcode);
			if (flag)
			{
				BitConverter.GetBytes(this.Id);
			}
		}
	}
}
