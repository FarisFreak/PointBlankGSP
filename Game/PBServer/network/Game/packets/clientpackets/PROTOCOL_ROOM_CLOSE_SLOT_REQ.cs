using PBServer.network.serverpackets;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_ROOM_CLOSE_SLOT_REQ : ReceiveBaseGamePacket
	{
		private int _slot;

		public PROTOCOL_ROOM_CLOSE_SLOT_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._slot = (int)base.readC();
			int num2 = (int)base.readC();
			int num3 = (int)base.readC();
			int num4 = (int)base.readC();
		}

		protected internal override void run()
		{
			Account player = base.getClient().getPlayer();
			Room room = base.getClient().getPlayer().getRoom();
			Account playerBySlot = room.getPlayerBySlot(this._slot);
			bool flag = player != null && room != null;
			if (flag)
			{
				switch (room.getSlotState(this._slot))
				{
				case SLOT_STATE.SLOT_STATE_EMPTY:
					room.changeSlotState(this._slot, SLOT_STATE.SLOT_STATE_CLOSE, true);
					break;
				case SLOT_STATE.SLOT_STATE_CLOSE:
					room.changeSlotState(this._slot, SLOT_STATE.SLOT_STATE_EMPTY, true);
					break;
				case SLOT_STATE.SLOT_STATE_SHOP:
				case SLOT_STATE.SLOT_STATE_INFO:
				case SLOT_STATE.SLOT_STATE_CLAN:
				case SLOT_STATE.SLOT_STATE_INVENTORY:
				case SLOT_STATE.SLOT_STATE_OUTPOST:
				case SLOT_STATE.SLOT_STATE_NORMAL:
					playerBySlot.sendPacket(new PROTOCOL_SERVER_MESSAGE_KICK_PLAYER_ACK());
					playerBySlot.sendPacket(new PROTOCOL_LOBBY_ENTER_ACK());
					room.changeSlotState(this._slot, SLOT_STATE.SLOT_STATE_EMPTY, true);
					break;
				}
			}
		}
	}
}
