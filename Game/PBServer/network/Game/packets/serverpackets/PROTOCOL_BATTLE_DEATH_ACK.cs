using PBServer.model;
using PBServer.model.ENUMS;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BATTLE_DEATH_ACK : SendBaseGamePacket
	{
		private FragInfos _kills;

		private Account _player;

		private Room _room;

		public PROTOCOL_BATTLE_DEATH_ACK(Account p, FragInfos kills)
		{
			this._room = p.getRoom();
			this._kills = kills;
			this._player = p;
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(3355);
			base.writeC((byte)this._kills.victimIdx);
			base.writeC((byte)this._kills.killsCount);
			base.writeC((byte)this._kills.killerIdx);
			base.writeD(this._kills.weapon);
			base.writeB(this._kills.bytes13);
			int num = this._kills.killsCount - 1;
			for (int i = 0; i <= num; i++)
			{
				Frag frag = this._kills.frags[i];
				base.writeC((byte)frag.unk_c_1);
				base.writeC((byte)frag.hitspotNum);
				switch (this._player.getRoom().getSlot(this._player.getSlot()).killMessage)
				{
				case 0:
					base.writeH(0);
					break;
				case 1:
					base.writeH(1);
					break;
				case 2:
					base.writeH(2);
					break;
				case 3:
					base.writeH(4);
					break;
				case 4:
					base.writeH(8);
					break;
				case 5:
					base.writeH(16);
					break;
				case 6:
					base.writeH(32);
					break;
				case 7:
					base.writeH(64);
					break;
				case 8:
					base.writeH(128);
					break;
				default:
					base.writeH(0);
					break;
				}
				base.writeB(frag.bytes131);
			}
			base.writeH((short)this._room.getKills(TeamEnum.CHARACTER_TEAM_RED));
			base.writeH((short)this._room.getDeaths(TeamEnum.CHARACTER_TEAM_RED));
			base.writeH((short)this._room.getKills(TeamEnum.CHARACTER_TEAM_BLUE));
			base.writeH((short)this._room.getDeaths(TeamEnum.CHARACTER_TEAM_BLUE));
			SLOT[] slots = this._room.getSlots();
			for (int j = 0; j < slots.Length; j++)
			{
				SLOT sLOT = slots[j];
				base.writeH((short)((byte)sLOT.allKills));
				base.writeH((short)((byte)sLOT.allDeaths));
			}
			bool flag = this._player.getRoom().getSlot(this._player.getSlot()).killsOnLife == 1;
			if (flag)
			{
				base.writeC(0);
			}
			bool flag2 = this._player.getRoom().getSlot(this._player.getSlot()).killsOnLife == 2;
			if (flag2)
			{
				base.writeC(1);
			}
			bool flag3 = this._player.getRoom().getSlot(this._player.getSlot()).killsOnLife == 3;
			if (flag3)
			{
				base.writeC(2);
			}
			bool flag4 = this._player.getRoom().getSlot(this._player.getSlot()).killsOnLife > 3;
			if (flag4)
			{
				base.writeC(3);
			}
			base.writeH((short)this._room.getSlot(this._kills.killerIdx).botScore);
		}
	}
}
