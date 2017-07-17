using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_AUTH_SHOP_ITEMLIST_ACK : SendBaseGamePacket
	{
		public PROTOCOL_AUTH_SHOP_ITEMLIST_ACK()
		{
			base.makeme();
		}

		protected internal override void write()
		{
			base.writeH(525);
			List<ShopInfo> shopItens = ShopInfoManager.getInstance().getShopItens();
			base.writeD(shopItens.Count);
			base.writeD(shopItens.Count);
			base.writeD(0);
			foreach (ShopInfo current in shopItens)
			{
				base.writeD(current.getItemId());
				base.writeB(new byte[]
				{
					Convert.ToByte(current.getBuyType2()),
					Convert.ToByte(current.getBuyType()),
					Convert.ToByte(current.getBuyType()),
					Convert.ToByte(current.getTitleId())
				});
			}
			base.writeD(356);
		}
	}
}
