using PBServer.managers;
using PBServer.model.clans;
using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_CS_CREATE_CLAN_REQ : ReceiveBaseGamePacket
	{
		private Clan clan;

		private string clan_info;

		private string clan_name;

		private string info;

		private int length_c_info;

		private int length_c_name;

		private int length_info;

		private int unk;

		public PROTOCOL_CS_CREATE_CLAN_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			this.clan = new Clan();
			base.readH();
			this.length_c_name = (int)base.readC();
			this.length_c_info = (int)base.readC();
			this.length_info = (int)base.readC();
			this.clan_name = base.readS(this.length_c_name);
			this.clan_info = base.readS(this.length_c_info);
			this.info = base.readS(this.length_info);
			this.unk = base.readD();
			this.clan.setClanId(base.getClient().getPlayerId());
			this.clan.setClanName(this.clan_name);
			this.clan.setClanRank(0);
			this.clan.setLogo1(0);
			this.clan.setLogo2(0);
			this.clan.setLogo3(0);
			this.clan.setLogo4(0);
			this.clan.setOwnerId(base.getClient().getPlayerId());
			this.clan.setLogoColor(0);
			this.clan.clan_info = this.clan_info;
			CLogger.getInstance().info("[Clan] name: " + this.clan_name);
			CLogger.getInstance().info("[Clan] information: " + this.clan_info);
			ClanManager.getInstance().AddClan(this.clan);
			base.getClient().getPlayer().setClanId(base.getClient().getPlayerId());
			AccountManager.getInstance().UpdateClan(base.getClient().getPlayerId(), base.getClient().getPlayerId());
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				base.getClient().getPlayer().sendPacket(new PROTOCOL_CS_CREATE_CLAN_ACK(this.clan_name, base.getClient().getPlayer(), this.clan_info));
			}
		}
	}
}
