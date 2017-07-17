using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_BATTLE_STARTING_REQ : ReceiveBaseGamePacket
	{
		private string _mapName;

		public PROTOCOL_BATTLE_STARTING_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._mapName = base.readS((int)base.readC());
			Account player = base.getClient().getPlayer();
			Room room = player.getRoom();
			room.changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_RENDEZVOUS, true);
			room.ChangeRoomState(ROOM_STATE.ROOM_STATE_RENDEZVOUS, player);
			CLogger.getInstance().info("[Battle] Map name: " + this._mapName);
		}

		protected internal override void run()
		{
		}
	}
}
