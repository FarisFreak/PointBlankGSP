using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_TITLE_DETACH_ACK : SendBaseGamePacket
	{
		private int _slot;

		private Account p;

		public PROTOCOL_TITLE_DETACH_ACK(int slot, Account p)
		{
			base.makeme();
			this._slot = slot;
			this.p = p;
		}

		protected internal override void write()
		{
			base.writeH(2624);
			base.writeD(0);
			bool flag = this._slot == 0;
			if (flag)
			{
				this.p.title.titleEquiped1 = 0;
			}
			else
			{
				bool flag2 = this._slot == 1;
				if (flag2)
				{
					this.p.title.titleEquiped2 = 0;
				}
				else
				{
					bool flag3 = this._slot == 2;
					if (flag3)
					{
						this.p.title.titleEquiped3 = 0;
					}
				}
			}
			TitleManager.getInstance().UpdateTitle(this.p.getPlayerId(), this.p.title.titleEquiped1, this.p.title.titleEquiped2, this.p.title.titleEquiped3);
		}
	}
}
