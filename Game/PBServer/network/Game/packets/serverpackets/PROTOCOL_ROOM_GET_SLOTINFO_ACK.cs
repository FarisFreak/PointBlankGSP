using Model;
using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_ROOM_GET_SLOTINFO_ACK : SendBaseGamePacket
	{
		private Room _room;

		public PROTOCOL_ROOM_GET_SLOTINFO_ACK(Room r)
		{
			this._room = r;
			base.makeme();
		}

		protected internal override void write()
		{
			try
			{
				bool flag = this._room != null;
				if (flag)
				{
					base.writeH(3861);
					CouponEffect couponEffect = (CouponEffect)2162686;
					bool flag2 = this._room.getLeader() == null;
					if (flag2)
					{
						this._room.setNewLeader(0);
					}
					bool flag3 = this._room.getLeader() != null;
					if (flag3)
					{
						base.writeD(this._room.getLeader().getSlot());
						for (int i = 0; i < 16; i++)
						{
							Account playerBySlot = this._room.getPlayerBySlot(i);
							bool flag4 = playerBySlot == null;
							if (flag4)
							{
								base.writeC((byte)this._room.getSlotState(i));
								base.writeC(0);
								base.writeD(0);
								base.writeD(0);
								base.writeC(0);
								base.writeD(-1);
								base.writeC(0);
								base.writeC(0);
								base.writeD(0);
								base.writeS("", 17);
								base.writeD(0);
								base.writeC(0);
							}
							else
							{
								Clan clan = new Clan();
								bool flag5 = ClanManager.getInstance().get(playerBySlot.clan_id) != null;
								if (flag5)
								{
									clan = ClanManager.getInstance().get(playerBySlot.clan_id);
								}
								base.writeC((byte)this._room.getSlotState(i));
								base.writeC((byte)playerBySlot.getRank());
								base.writeD(Convert.ToInt32((playerBySlot == null || clan == null) ? 0 : clan.getClanId()));
								base.writeD(0);
								base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 0 : clan.getClanRank()));
								base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo1()));
								base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo2()));
								base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo3()));
								base.writeC(Convert.ToByte((playerBySlot == null || clan == null) ? 255 : clan.getLogo4()));
								base.writeC((byte)playerBySlot.getPcCafe());
								base.writeC(0);
								base.writeD((int)((short)couponEffect));
								base.writeS(Convert.ToString((playerBySlot == null || clan == null) ? "" : clan.getClanName()), 17);
								base.writeD(0);
								base.writeC(0);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error(ex.ToString());
			}
		}
	}
}
