using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.model.players;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_INVENTORY_ADD_ITEM_ACK : SendBaseGamePacket
	{
		public int _count;

		public int _equip;

		public int _item_id;

		public string _item_id_name;

		public int _item_id_type;

		public int _weapon;

		public int _type;

		public int _chara;

		public int _coupon;

		private Account p;

		public int p_id;

		public PROTOCOL_INVENTORY_ADD_ITEM_ACK(int item, int type, int p_id, string item_name, int count, int equip, Account p)
		{
			this._item_id = item;
			this._type = type;
			this.p_id = p_id;
			this._item_id_name = item_name;
			this._count = count;
			this._equip = equip;
			base.makeme();
			this.p = p;
		}

		public void get(int item_id, int player_id)
		{
			bool flag = AccountManager.getInstance().getCountForItemId(item_id, player_id) == 0;
			if (flag)
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					mySqlConnection.Open();
					new MySqlCommand(string.Concat(new object[]
					{
						string.Concat(new object[]
						{
							"INSERT INTO items(owner_id,item_id,item_name,count,equip,loc_slot)VALUES('",
							this.p_id,
							"','",
							this._item_id,
							"','",
							this._item_id_name,
							"','",
							this._count,
							"','",
							this._equip,
							"','",
							this._type,
							"');"
						})
					}), mySqlConnection).ExecuteNonQuery();
				}
				base.writeC((byte)this._equip);
				base.writeD(this._count);
			}
			else
			{
				int num = AccountManager.getInstance().getCountForItemId(item_id, player_id) + this._count;
				base.writeC((byte)this._equip);
				base.writeD(num);
				AccountManager.getInstance().DescontItem(item_id, player_id, num);
				foreach (ItemsModel current in this.p.getInventory().getItemsAll())
				{
					bool flag2 = current.id == this._item_id;
					if (flag2)
					{
						current.count = num;
					}
				}
			}
		}

		protected internal override void write()
		{
			bool flag = this._item_id < 1105004000 && this._item_id > 1001001000;
			if (flag)
			{
				this._weapon = 1;
				this._chara = 1;
				this._coupon = 0;
			}
			bool flag2 = this._item_id < 1001001000;
			if (flag2)
			{
				this._weapon = 0;
				this._chara = 1;
				this._coupon = 0;
			}
			bool flag3 = this._item_id > 1105004000;
			if (flag3)
			{
				this._weapon = 0;
				this._chara = 0;
				this._coupon = 1;
			}
			base.writeH(3588);
			base.writeC(1);
			base.writeD(this._weapon);
			base.writeD(this._chara);
			base.writeD(this._coupon);
			base.writeD(this._item_id);
			base.writeD(this._item_id);
			base.writeD(this._item_id);
			bool flag4 = this._item_id < 600000000;
			if (flag4)
			{
				this._type = 1;
			}
			bool flag5 = this._item_id < 700000000 && this._item_id > 600000000;
			if (flag5)
			{
				this._type = 2;
			}
			bool flag6 = this._item_id < 800000000 && this._item_id > 700000000;
			if (flag6)
			{
				this._type = 3;
			}
			bool flag7 = this._item_id < 900000000 && this._item_id > 800000000;
			if (flag7)
			{
				this._type = 4;
			}
			bool flag8 = this._item_id < 1000000000 && this._item_id > 900000000;
			if (flag8)
			{
				this._type = 5;
			}
			bool flag9 = this._item_id < 1001002000 && this._item_id > 1001001000;
			if (flag9)
			{
				this._type = 6;
			}
			bool flag10 = this._item_id < 1001003000 && this._item_id > 1001002000;
			if (flag10)
			{
				this._type = 7;
			}
			bool flag11 = this._item_id < 1104004000 && this._item_id > 1104003000;
			if (flag11)
			{
				this._type = 8;
			}
			bool flag12 = this._item_id < 1105004000 && this._item_id > 1105003000;
			if (flag12)
			{
				this._type = 8;
			}
			bool flag13 = this._item_id < 1102004000 && this._item_id > 1102003000;
			if (flag13)
			{
				this._type = 8;
			}
			bool flag14 = this._item_id < 1103004000 && this._item_id > 1103003000;
			if (flag14)
			{
				this._type = 10;
			}
			bool flag15 = this._item_id < 1006004000 && this._item_id > 1006001000;
			if (flag15)
			{
				this._type = 9;
			}
			bool flag16 = this._item_id < 1301510000 && this._item_id > 1300002000;
			if (flag16)
			{
				this._type = 11;
			}
			bool flag17 = this._item_id < 700000000 && this._item_id > 600000000;
			if (flag17)
			{
				this._item_id_type = 1;
			}
			bool flag18 = this._item_id < 800000000 && this._item_id > 700000000;
			if (flag18)
			{
				this._item_id_type = 1;
			}
			bool flag19 = this._item_id < 900000000 && this._item_id > 800000000;
			if (flag19)
			{
				this._item_id_type = 1;
			}
			bool flag20 = this._item_id < 1000000000 && this._item_id > 900000000;
			if (flag20)
			{
				this._item_id_type = 1;
			}
			bool flag21 = this._item_id < 1001002000 && this._item_id > 1001001000;
			if (flag21)
			{
				this._item_id_type = 2;
			}
			bool flag22 = this._item_id < 1001003000 && this._item_id > 1001002000;
			if (flag22)
			{
				this._item_id_type = 2;
			}
			bool flag23 = this._item_id < 1104004000 && this._item_id > 1104003000;
			if (flag23)
			{
				this._item_id_type = 2;
			}
			bool flag24 = this._item_id < 1105004000 && this._item_id > 1105003000;
			if (flag24)
			{
				this._item_id_type = 2;
			}
			bool flag25 = this._item_id < 1102004000 && this._item_id > 1102003000;
			if (flag25)
			{
				this._item_id_type = 2;
			}
			bool flag26 = this._item_id < 1103004000 && this._item_id > 1103003000;
			if (flag26)
			{
				this._item_id_type = 2;
			}
			bool flag27 = this._item_id < 1006004000 && this._item_id > 1006001000;
			if (flag27)
			{
				this._item_id_type = 2;
			}
			bool flag28 = this._item_id < 1301510000 && this._item_id > 1300002000;
			if (flag28)
			{
				this._item_id_type = 3;
			}
			this.get(this._item_id, this.p.getPlayerId());
		}
	}
}
