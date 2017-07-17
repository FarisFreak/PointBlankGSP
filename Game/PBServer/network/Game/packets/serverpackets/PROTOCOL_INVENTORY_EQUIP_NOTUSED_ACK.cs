using Managers.Active;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_INVENTORY_EQUIP_NOTUSED_ACK : SendBaseGamePacket
	{
		private int _objId;

		private Account _p;

		private int _type;

		private int item_id;

		public PROTOCOL_INVENTORY_EQUIP_NOTUSED_ACK(int id, int type, Account player)
		{
			base.makeme();
			this._objId = id;
			this._type = type;
			this._p = player;
		}

		protected internal override void write()
		{
			base.writeH(535);
			bool flag = this._type == 2;
			if (flag)
			{
				this.item_id = 0;
				bool flag2 = DAOM.getInstance().getItem(this._objId) != null;
				if (flag2)
				{
					this.item_id = DAOM.getInstance().getItem(this._objId).id;
				}
				base.writeD(1);
				base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
				base.writeQ((long)this._objId);
				bool flag3 = this._objId < 32768 && this._objId > 16384 && this._objId > 32 && this._objId > 8;
				if (flag3)
				{
					base.writeD(this._objId);
					base.writeC(1);
					base.writeD(1);
				}
				else
				{
					base.writeD(this._objId);
					base.writeC(2);
					int num = AccountManager.getInstance().getCountForItemId(this.item_id, this._p.getPlayerId());
					bool flag4 = DAOM.getInstance().getItem(this._objId) != null;
					if (flag4)
					{
						num = DAOM.getInstance().getItem(this._objId).count;
					}
					DateTime now = DateTime.Now;
					base.writeD(Convert.ToInt32(DateTime.Now.AddSeconds((double)num).ToString("yyMMddHHmm")));
				}
			}
			else
			{
				base.writeD(1);
				base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
				base.writeD(1);
				base.writeD(0);
				base.writeD(0);
				base.writeC(1);
				base.writeD(0);
			}
		}
	}
}
