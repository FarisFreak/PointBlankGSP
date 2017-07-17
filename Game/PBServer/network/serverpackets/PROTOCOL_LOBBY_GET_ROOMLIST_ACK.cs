using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_GET_ROOMLIST_ACK : SendBaseGamePacket
	{
		private Channel _client;

		public PROTOCOL_LOBBY_GET_ROOMLIST_ACK(Channel ch)
		{
			this._client = ch;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3074);
			base.writeD(this._client.getRooms().Count);
			base.writeD(0);
			base.writeD(this._client.getRooms().Count);
			for (int i = 0; i < this._client.getRooms().Count; i++)
			{
				Room room = this._client.getRooms()[i];
				base.writeD(room.getRoomId());
				base.writeS(room.name, 23);
				base.writeC((byte)room.map_id);
				base.writeC(0);
				base.writeC(0);
				base.writeC((byte)room.room_type);
				base.writeC((byte)room.isBattleInt());
				base.writeC((byte)room.getAllPlayers().Count);
				base.writeC((byte)room.getSlotCount());
				base.writeC(5);
				base.writeC((byte)room.allweapons);
				bool flag = room.password.Length == 0 && room.random_map == 0;
				if (flag)
				{
					base.writeC(0);
				}
				else
				{
					bool flag2 = room.password.Length > 0 && room.random_map == 0;
					if (flag2)
					{
						base.writeC(4);
					}
					else
					{
						bool flag3 = room.password.Length > 0 && room.random_map > 0;
						if (flag3)
						{
							base.writeC(255);
						}
						else
						{
							bool flag4 = room.password.Length == 0 && room.random_map > 0;
							if (flag4)
							{
								base.writeC(2);
							}
						}
					}
				}
				base.writeC((byte)room.special);
			}
			base.writeD(this._client.getAllPlayers().Count);
			base.writeD(0);
			base.writeD(this._client.getAllPlayers().Count);
			int num = 0;
			for (int i = 0; i < this._client.getWaitPlayers().Count; i++)
			{
				Account account = this._client.getWaitPlayers()[i];
				Clan clan = ClanManager.getInstance().get(account.getClanId());
				bool flag5 = account != null && account.getPlayerName() != "";
				if (flag5)
				{
					base.writeD(account.getPlayerId());
					base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo1()));
					base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo2()));
					base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo3()));
					base.writeC(Convert.ToByte((account == null || clan == null) ? 255 : clan.getLogo4()));
					base.writeS(Convert.ToString((account == null || clan == null) ? "" : clan.getClanName()), 17);
					base.writeH((short)account.getRank());
					base.writeS(account.getPlayerName(), 33);
					base.writeC((byte)account.getNameColor());
					base.writeC(0);
					num++;
				}
			}
		}
	}
}
