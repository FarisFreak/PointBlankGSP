using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_UNREADY_4VS4_ACK : SendBaseGamePacket
	{
		private Room _room;

		public PROTOCOL_ROOM_UNREADY_4VS4_ACK(Room room)
		{
			base.makeme();
			this._room = room;
		}

		protected internal override void write()
		{
			base.writeH(3879);
			for (int i = 0; i < 16; i++)
			{
				Account playerBySlot = this._room.getPlayerBySlot(i);
				bool flag = playerBySlot != null;
				if (flag)
				{
					base.writeD(playerBySlot.getSlot());
					base.writeD(playerBySlot.getCharRed());
					base.writeD(playerBySlot.getCharBlue());
					base.writeD(playerBySlot.getCharHelmet());
					base.writeD(playerBySlot.getCharDino());
					base.writeD(playerBySlot.getCharBeret());
					base.writeD(playerBySlot.getPrimaryWeapon());
					base.writeD(playerBySlot.getSecondaryWeapon());
					base.writeD(playerBySlot.getMeleeWeapon());
					base.writeD(playerBySlot.getThrownNormalWeapon());
					base.writeD(playerBySlot.getThrownSpecialWeapon());
					base.writeD(0);
					base.writeB(new byte[]
					{
						100,
						100,
						100,
						100,
						100
					});
					base.writeC(1);
					base.writeD(0);
				}
				else
				{
					base.writeD(i);
					base.writeB(new byte[20]);
					base.writeB(new byte[24]);
					base.writeB(new byte[]
					{
						100,
						100,
						100,
						100,
						100
					});
					base.writeD(0);
				}
			}
		}
	}
}
