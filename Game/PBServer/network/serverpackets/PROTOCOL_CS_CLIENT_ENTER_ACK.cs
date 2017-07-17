using PBServer.managers;
using PBServer.model.clans;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PBServer.network.serverpackets
{
	public class PROTOCOL_CS_CLIENT_ENTER_ACK : SendBaseGamePacket
	{
		private int clan;

		private List<Clan> clanList;

		private Account player;

		public PROTOCOL_CS_CLIENT_ENTER_ACK(int c, Account p, List<Clan> clanList)
		{
			base.makeme();
			this.clan = c;
			this.clanList = clanList;
			this.player = p;
		}

		public static byte[] ConvertHexStringToByteArray(string hexString)
		{
			bool flag = hexString.Length % 2 != 0;
			if (flag)
			{
			}
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i < array.Length; i++)
			{
				string s = hexString.Substring(i * 2, 2);
				array[i] = byte.Parse(s, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
			}
			return array;
		}

		protected internal override void write()
		{
			base.writeH(1442);
			base.writeD(this.clan);
			bool flag = this.player.getClanId() == 0;
			if (flag)
			{
				base.writeD(0);
			}
			bool flag2 = this.player.getClanId() > 0;
			if (flag2)
			{
				Clan clan = ClanManager.getInstance().get(this.player.getClanId());
				base.writeD((clan != null) ? ((clan.getOwnerId() == this.player.getPlayerId()) ? 1 : 2) : 0);
			}
			base.writeD(this.clanList.Count);
			base.writeB(PROTOCOL_CS_CLIENT_ENTER_ACK.ConvertHexStringToByteArray("AA 01 00 80 6C 44 37"));
		}
	}
}
