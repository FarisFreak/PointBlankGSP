using PBServer.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_LOBBY_JOIN_ROOM_ACK : SendBaseGamePacket
	{
		public long _id;

		private Account _player;

		private Room _room;

		public PROTOCOL_LOBBY_JOIN_ROOM_ACK(long id, Account player)
		{
			base.makeme();
			this._id = id;
			this._player = player;
			bool flag = this._player != null;
			if (flag)
			{
				this._room = this._player.getRoom();
			}
		}

		protected internal override void write()
		{
			base.writeH(3082);
			bool flag = this._player != null;
			if (flag)
			{
				base.writeD(12);
				base.writeD(this._player.getSlot());
				base.writeD(this._room.getRoomId());
				base.writeS(this._room.name, 23);
				base.writeC((byte)this._room.map_id);
				base.writeC(0);
				base.writeC(0);
				base.writeC((byte)this._room.room_type);
				base.writeC(5);
				base.writeC((byte)this._room.getAllPlayers().Count);
				base.writeC((byte)this._room.getSlotCount());
				base.writeC(5);
				base.writeC((byte)this._room.allweapons);
				base.writeC((byte)this._room.random_map);
				base.writeC((byte)this._room.special);
				base.writeS(this._room.getLeader().getPlayerName(), 33);
				base.writeC((byte)this._room.killtime);
				base.writeC(0);
				base.writeC(0);
				base.writeC(0);
				base.writeC((byte)this._room.limit);
				base.writeC((byte)this._room.seeConf);
				base.writeH((short)this._room.autobalans);
				base.writeS(this._room.password, 4);
				base.writeC(0);
				base.writeD(this._room.getLeader().getSlot());
				for (int i = 0; i < 16; i++)
				{
					Account playerBySlot = this._room.getPlayerBySlot(i);
					bool flag2 = playerBySlot != null;
					if (flag2)
					{
						base.writeC((byte)this._room.getSlotState(playerBySlot.getSlot()));
						base.writeH((short)playerBySlot.getRank());
						base.writeB(new byte[5]);
						base.writeH((short)playerBySlot.getPcCafe());
						base.writeC((byte)playerBySlot.getNameColor());
						base.writeC(Convert.ToByte((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? 255 : ClanManager.getInstance().get(playerBySlot.getClanId()).getLogo1()));
						base.writeC(Convert.ToByte((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? 255 : ClanManager.getInstance().get(playerBySlot.getClanId()).getLogo2()));
						base.writeC(Convert.ToByte((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? 255 : ClanManager.getInstance().get(playerBySlot.getClanId()).getLogo3()));
						base.writeC(Convert.ToByte((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? 255 : ClanManager.getInstance().get(playerBySlot.getClanId()).getLogo4()));
						base.writeC(Convert.ToByte((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? 0 : ClanManager.getInstance().get(playerBySlot.getClanId()).getLogoColor()));
						base.writeB(new byte[6]);
						base.writeS(Convert.ToString((playerBySlot == null || ClanManager.getInstance().get(playerBySlot.getClanId()) == null) ? "" : ClanManager.getInstance().get(playerBySlot.getClanId()).getClanName()), 17);
						base.writeD(0);
					}
					else
					{
						base.writeC((byte)this._room.getSlotState(i));
						base.writeH(0);
						base.writeB(new byte[8]);
						base.writeC(255);
						base.writeC(255);
						base.writeC(255);
						base.writeC(255);
						base.writeC(0);
						base.writeB(new byte[6]);
						base.writeS("", 17);
						base.writeD(0);
					}
				}
				base.writeC((byte)this._room.getAllPlayers().Count);
				foreach (Account current in this._room.getAllPlayers())
				{
					base.writeC((byte)current.getSlot());
					base.writeC(33);
					base.writeS(current.getPlayerName(), 33);
					base.writeC((byte)current.getNameColor());
				}
				base.writeC((byte)this._room._aiCount);
				base.writeC((byte)this._room._aiLevel);
			}
			else
			{
				base.writeQ(2147479548L);
			}
		}
	}
}
