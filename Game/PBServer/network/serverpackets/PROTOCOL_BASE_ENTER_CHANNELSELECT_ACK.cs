using PBServer.src.data.xml.holders;
using System;
using System.Net;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_BASE_ENTER_CHANNELSELECT_ACK : SendBaseGamePacket
	{
		private GameClient _gc;

		public PROTOCOL_BASE_ENTER_CHANNELSELECT_ACK(GameClient gc)
		{
			base.makeme();
			this._gc = gc;
		}

		protected internal override void write()
		{
			base.writeH(2049);
			base.writeD(5404);
			base.writeB(IPAddress.Parse(Config.GAME_HOST).GetAddressBytes());
			base.writeH((short)this._gc.getCryptKey());
			base.writeH(32759);
			for (int i = 0; i < 10; i++)
			{
				base.writeC((byte)ChannelInfoHolder.getChannel(i).getTypeChannel());
			}
			base.writeC(1);
			base.writeD(2);
			for (int i = 0; i < 2; i++)
			{
				base.writeD(1);
				base.writeB(IPAddress.Parse(Config.GAME_HOST).GetAddressBytes());
				base.writeH((short)Config.GAME_PORT);
				base.writeC(1);
				base.writeH((short)ChannelInfoHolder.getChannel(i).getMaxPlayers());
				base.writeD(ChannelInfoHolder.getChannel(i).getAllPlayers().Count);
			}
		}
	}
}
