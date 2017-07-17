using Network.SendPackets;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using PBServer.src.network.gsPacket.serverpackets;
using System;
using System.Threading;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_REQ : ReceiveBaseGamePacket
	{
		public int zone;

		public int slot;

		public int x;

		public int y;

		public int z;

		public int RedRounds;

		public int BlueRounds;

		public PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			this.slot = base.readD();
			this.zone = (int)base.readC();
			this.x = base.readD();
			this.y = base.readD();
			this.z = base.readD();
		}

		protected internal override void run()
		{
			Room room = base.getClient().getPlayer().getRoom();
			base.getClient().getPlayer().getRoom().setBombState(1);
			foreach (Account current in base.getClient().getPlayer().getRoom().getAllPlayers())
			{
				current.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_BOMB_INSTALL_ACK(this.zone, this.slot, this.x, this.y, this.z));
			}
			bool flag = room.room_type == 2;
			if (flag)
			{
				this.RedRounds = base.getClient().getPlayer().getRoom().getRedWinRounds();
				this.BlueRounds = base.getClient().getPlayer().getRoom().getBlueWinRounds();
				Thread.Sleep(42500);
				bool flag2 = this.RedRounds == base.getClient().getPlayer().getRoom().getRedWinRounds() & this.BlueRounds == base.getClient().getPlayer().getRoom().getBlueWinRounds();
				if (flag2)
				{
					bool flag3 = base.getClient().getPlayer().getRoom().getBombState() == 1;
					if (flag3)
					{
						room.setRedWinRounds(room.getRedWinRounds() + 1);
						room.setBombState(0);
						room.setRedKills(0);
						room.setBlueKills(0);
						bool flag4 = room.getRedWinRounds() == room.getKillsByMask();
						if (flag4)
						{
							foreach (Account current2 in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								SLOT roomSlotByPlayer = room.getRoomSlotByPlayer(current2);
								roomSlotByPlayer.setKillMessage(0);
								roomSlotByPlayer.setLastKillMessage(0);
								roomSlotByPlayer.setOneTimeKills(0);
								roomSlotByPlayer.setAllKills(0);
								roomSlotByPlayer.setAllDeahts(0);
								current2.getClient().sendPacket(new PROTOCOL_BATTLE_ENDBATTLE_ACK(current2));
							}
							room.setRedKills(0);
							room.setRedDeaths(0);
							room.setBlueKills(0);
							room.setBlueDeaths(0);
							room.setFigth(0);
							room.setBlueWinRounds(0);
							room.setRedWinRounds(0);
						}
						else
						{
							foreach (Account current3 in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								SLOT roomSlotByPlayer2 = room.getRoomSlotByPlayer(current3);
								roomSlotByPlayer2.setKillMessage(0);
								roomSlotByPlayer2.setLastKillMessage(0);
								roomSlotByPlayer2.setOneTimeKills(0);
								current3.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_END_ACK(0, 2, base.getClient().getPlayer().getRoom()));
							}
							Thread.Sleep(10000);
							foreach (Account current4 in base.getClient().getPlayer().getRoom().getAllPlayers())
							{
								current4.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_PRE_START_ACK());
								current4.getClient().sendPacket(new PROTOCOL_BATTLE_MISSION_ROUND_START_ACK(current4.getRoom()));
							}
						}
					}
				}
			}
		}
	}
}
