using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BATTLE_RESPAWN_REQ : ReceiveBaseGamePacket
	{
		private int _beret;

		private int _blue;

		private int _dino;

		private int _fifth;

		private int _first;

		private int _fourth;

		private int _head;

		private int _id;

		private int _red;

		private int _second;

		private int _third;

		public PROTOCOL_BATTLE_RESPAWN_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._first = base.readD();
			this._second = base.readD();
			this._third = base.readD();
			this._fourth = base.readD();
			this._fifth = base.readD();
			this._id = base.readD();
			this._red = base.readD();
			this._blue = base.readD();
			this._head = base.readD();
			this._beret = base.readD();
			this._dino = base.readD();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			bool flag = player != null;
			if (flag)
			{
				Room room = player.getRoom();
				bool flag2 = room != null;
				if (flag2)
				{
					foreach (Account current in room.getAllPlayers())
					{
						bool flag3 = current != null && room.getSlot(current.getSlot()).state == SLOT_STATE.SLOT_STATE_BATTLE;
						if (flag3)
						{
							CLogger.getInstance().info("[Send] PROTOCOL_BATTLE_RESPAWN_ACK | " + player.getPlayerName() + " asks the " + current.player_name);
							current.sendPacket(new PROTOCOL_BATTLE_RESPAWN_ACK(new ResInfo(this._first, this._second, this._third, this._fourth, this._fifth, this._id, this._red, this._blue, this._head, this._beret, this._dino), player, room));
						}
					}
				}
			}
		}
	}
}
