using PBServer.src.data.xml.holders;
using PBServer.src.model;
using System;

namespace PBServer.network.serverpackets
{
	internal class PROTOCOL_BASE_SELECT_CHANNEL_ACK : SendBaseGamePacket
	{
		private Channel _channel;

		public PROTOCOL_BASE_SELECT_CHANNEL_ACK(int channelId)
		{
			base.makeme();
			this._channel = ChannelInfoHolder.getChannel(channelId);
		}

		protected internal override void write()
		{
			base.writeH(2574);
			base.writeD(1);
			base.writeH((short)this._channel.getAnnounceSize());
			base.writeS(this._channel.getAnnounce());
			base.writeD(0);
		}
	}
}
