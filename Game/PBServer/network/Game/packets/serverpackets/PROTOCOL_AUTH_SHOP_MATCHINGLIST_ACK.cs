using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_SHOP_MATCHINGLIST_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(527);
			List<ShopInfo> shopItens = ShopInfoManager.getInstance().getShopItens();
			base.writeD(shopItens.Count);
			base.writeD(shopItens.Count);
			base.writeD(0);
			foreach (ShopInfo current in shopItens)
			{
				base.writeD(current.getGoodId());
				base.writeD(current.getItemId());
				base.writeD(current.getItemCount());
			}
			base.writeD(356);
		}
	}
}
