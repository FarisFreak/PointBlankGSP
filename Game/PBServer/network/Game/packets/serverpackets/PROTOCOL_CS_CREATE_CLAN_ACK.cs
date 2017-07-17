using PBServer.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_CS_CREATE_CLAN_ACK : SendBaseGamePacket
	{
		private string _clan_info;

		private string _clan_name;

		private Account p;

		public PROTOCOL_CS_CREATE_CLAN_ACK(string clan_name, Account player, string clan_info)
		{
			base.makeme();
			this._clan_name = clan_name;
			this.p = player;
			this._clan_info = clan_info;
		}

		protected internal override void write()
		{
			ClanManager.getInstance().createClanInDb(this._clan_name, this.p.getPlayerId());
			base.writeH(1311);
			base.writeD(0);
			base.writeC(96);
			base.writeC(65);
			base.writeH(0);
			base.writeS(this._clan_name, 17);
			base.writeH(0);
			base.writeC(1);
			base.writeB(new byte[]
			{
				50,
				75,
				5,
				51
			});
			base.writeB(new byte[14]);
			base.writeC(2);
			base.writeC(23);
			base.writeC(6);
			base.writeB(new byte[5]);
			base.writeS(this.p.getPlayerName(), 33);
			base.writeC((byte)this.p.getRank());
			base.writeS(this._clan_info, 120);
			base.writeB(new byte[12]);
			base.writeD(4859);
			base.writeD(4860);
		}
	}
}
