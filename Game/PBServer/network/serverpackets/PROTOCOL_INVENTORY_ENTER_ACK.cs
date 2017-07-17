using PBServer.src.managers;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_INVENTORY_ENTER_ACK : SendBaseGamePacket
	{
		private GameClient gm;

		private int p_id;

		public PROTOCOL_INVENTORY_ENTER_ACK(int id, GameClient gm)
		{
			base.makeme();
			this.p_id = id;
			this.gm = gm;
		}

		protected internal override void write()
		{
			base.writeH(3586);
			base.writeD(Convert.ToInt32(DateTime.Now.ToString("yyMMddHHmm")));
			new DaoManager(this.gm).getInventory(this.p_id);
		}
	}
}
