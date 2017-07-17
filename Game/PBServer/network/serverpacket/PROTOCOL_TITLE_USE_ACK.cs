using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpacket
{
	public class PROTOCOL_TITLE_USE_ACK : SendBaseGamePacket
	{
		private Account p;

		private int proceder = 1;

		private int slot;

		private int titleId;

		public PROTOCOL_TITLE_USE_ACK(int slot, int titleId, Account p)
		{
			base.makeme();
			this.p = p;
			this.slot = slot;
			this.titleId = titleId;
		}

		protected internal override void write()
		{
			base.writeH(2622);
			base.writeD(0);
			bool flag = this.p.title.getEquipedTitle1() == 0 && this.slot == 0 && this.proceder == 1;
			if (flag)
			{
				this.p.title.titleEquiped1 = this.titleId;
				this.proceder = 2;
			}
			else
			{
				bool flag2 = this.p.title.getEquipedTitle2() == 0 && this.slot == 1 && this.proceder == 1;
				if (flag2)
				{
					this.p.title.titleEquiped2 = this.titleId;
					this.proceder = 2;
				}
				else
				{
					bool flag3 = this.p.title.getEquipedTitle3() == 0 && this.slot == 2 && this.proceder == 1;
					if (flag3)
					{
						this.p.title.titleEquiped3 = this.titleId;
						this.proceder = 2;
					}
				}
			}
			TitleManager.getInstance().UpdateTitle(this.p.getPlayerId(), this.p.title.titleEquiped1, this.p.title.titleEquiped2, this.p.title.titleEquiped3);
		}
	}
}
