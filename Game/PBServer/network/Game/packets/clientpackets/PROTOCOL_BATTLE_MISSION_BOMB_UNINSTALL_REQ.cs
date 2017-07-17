using Network.SendPackets;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;
using System.Threading;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_REQ : ReceiveBaseGamePacket
	{
		public int slot;

		public PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.slot = base.readD();
		}

		protected internal override void run()
		{
			Room room = base.getClient().getPlayer().getRoom();
			base.getClient().getPlayer().getRoom().setBombState(0);
			room.setRedKills(0);
			room.setBlueKills(0);
			room.setBlueWinRounds(room.getBlueWinRounds() + 1);
			bool flag = room.getBlueWinRounds() == room.getKillsByMask();
			if (flag)
			{
				foreach (Account current in base.getClient().getPlayer().getRoom().getAllPlayers())
				{
					SLOT roomSlotByPlayer = room.getRoomSlotByPlayer(current);
					roomSlotByPlayer.setKillMessage(0);
					roomSlotByPlayer.setLastKillMessage(0);
					roomSlotByPlayer.setOneTimeKills(0);
					roomSlotByPlayer.setAllKills(0);
					roomSlotByPlayer.setAllDeahts(0);
					current.getClient().sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current));
					room.setRedKills(0);
					room.setRedDeaths(0);
					room.setBlueKills(0);
					room.setBlueDeaths(0);
					room.setFigth(0);
					room.setBlueWinRounds(0);
					room.setRedWinRounds(0);
				}
			}
			else
			{
				foreach (Account current2 in base.getClient().getPlayer().getRoom().getAllPlayers())
				{
					SLOT roomSlotByPlayer2 = room.getRoomSlotByPlayer(current2);
					roomSlotByPlayer2.setKillMessage(0);
					roomSlotByPlayer2.setLastKillMessage(0);
					roomSlotByPlayer2.setOneTimeKills(0);
					current2.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_BOMB_UNINSTALL_ACK(this.slot));
					bool flag2 = room.room_type == 2;
					if (flag2)
					{
						current2.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(1, 3, base.getClient().getPlayer().getRoom()));
					}
				}
				bool flag3 = room.room_type == 2;
				if (flag3)
				{
					Thread.Sleep(10000);
					foreach (Account current3 in base.getClient().getPlayer().getRoom().getAllPlayers())
					{
						current3.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK());
						current3.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(current3.getRoom()));
					}
				}
			}
		}
	}
}
