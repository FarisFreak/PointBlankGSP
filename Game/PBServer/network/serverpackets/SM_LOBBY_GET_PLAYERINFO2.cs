using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.serverpackets
{
	internal class SM_LOBBY_GET_PLAYERINFO2 : SendBaseGamePacket
	{
		private int id;

		public SM_LOBBY_GET_PLAYERINFO2(int id)
		{
			base.makeme();
			this.id = id;
		}

		protected internal override void write()
		{
			Account accountInPlayerId = AccountManager.getInstance().getAccountInPlayerId(this.id);
			base.writeH(3100);
			bool flag = accountInPlayerId != null;
			if (flag)
			{
				base.writeD(accountInPlayerId.getPrimaryWeapon());
				base.writeD(accountInPlayerId.getSecondaryWeapon());
				base.writeD(accountInPlayerId.getMeleeWeapon());
				base.writeD(accountInPlayerId.getThrownNormalWeapon());
				base.writeD(accountInPlayerId.getThrownSpecialWeapon());
				base.writeD(accountInPlayerId.getCharRed());
				base.writeD(accountInPlayerId.getCharBlue());
				base.writeD(accountInPlayerId.getCharHelmet());
				base.writeD(accountInPlayerId.getCharBeret());
				base.writeD(accountInPlayerId.getCharDino());
			}
		}
	}
}
