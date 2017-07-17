using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_ROOM_CHANGE_TEAM_REQ : ReceiveBaseGamePacket
	{
		private int _oldSlot;

		private int _team;

		public PROTOCOL_ROOM_CHANGE_TEAM_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._team = base.readD();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			bool flag = player.changeSlot == 1;
			if (flag)
			{
				player.changeSlot = 2;
				bool flag2 = this._team >= 0 && this._team != player.getSlot() % 2 && player != null;
				if (flag2)
				{
					this._oldSlot = player.getSlot();
					player.getRoom().setNewSlot(player, this._team);
					foreach (Account current in player.getRoom().getAllPlayers())
					{
						current.sendPacket(new PROTOCOL_ROOM_CHANGE_TEAM_ACK(this._oldSlot, player));
					}
					player.getRoom().updateInfo();
				}
			}
			else
			{
				player.changeSlot = 1;
			}
		}
	}
}
