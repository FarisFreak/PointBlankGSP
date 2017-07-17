using PBServer.src.data.model;
using PBServer.src.data.xml.holders;
using PBServer.src.model;
using System;
using System.Net;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_SERVER_MESSAGE_CONNECTIONSUCCESS_ACK : SendBaseLoginPacket
	{
		private LoginClient _lc;

		private int players;

		public PROTOCOL_SERVER_MESSAGE_CONNECTIONSUCCESS_ACK(LoginClient lc)
		{
			base.makeme();
			this._lc = lc;
		}

		protected internal override void write()
		{
			base.writeH(2049);
			base.writeD(5404);
			base.writeB(IPAddress.Parse(Config.GAME_HOST).GetAddressBytes());
			base.writeH(29890);
			base.writeH(32759);
			for (int i = 0; i < 10; i++)
			{
				base.writeC(1);
			}
			base.writeC(1);
			base.writeD(GameServerInfoHolder.getInstance().getAllGameserverInfos().Count);
			foreach (GameServerInfo current in GameServerInfoHolder.getInstance().getAllGameserverInfos())
			{
				base.writeD(1);
				base.writeB(IPAddress.Parse(current.getIP()).GetAddressBytes());
				base.writeH((short)Config.GAME_PORT);
				base.writeC((byte)current.getTypeGameServer());
				base.writeH((short)current.getMaxPlayers());
				foreach (Channel current2 in ChannelInfoHolder.getAllChannels())
				{
					bool flag = current2.getServerName() == current.getServerName();
					if (flag)
					{
						this.players += current2.getAllPlayers().Count;
					}
				}
				base.writeD(this.players);
			}
			base.writeC(0);
			base.writeD(0);
			base.writeD(0);
			base.writeD(0);
		}
	}
}
