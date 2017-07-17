using System;

namespace PBServer.network.clientpacket
{
	internal class PacketReceive : Attribute
	{
		public ushort Id
		{
			get;
			set;
		}
	}
}
