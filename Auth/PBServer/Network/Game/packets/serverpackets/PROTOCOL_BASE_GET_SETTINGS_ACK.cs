using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.serverpackets
{
	public class PROTOCOL_BASE_GET_SETTINGS_ACK : SendBaseLoginPacket
	{
		private LoginClient _lc;

		public PROTOCOL_BASE_GET_SETTINGS_ACK(LoginClient player)
		{
			base.makeme();
			this._lc = player;
		}

		protected internal override void write()
		{
			base.writeH(2568);
			Account account = AccountManager.getInstance().get(this._lc.getLogin());
			base.writeD(1);
			base.writeC(2);
			byte[] array = new byte[]
			{
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				0,
				31,
				0,
				0,
				0,
				0,
				57,
				248,
				16,
				0,
				0,
				10,
				0,
				0,
				0,
				0,
				13,
				0,
				0,
				0,
				0,
				32,
				0,
				0,
				0,
				0,
				28,
				0,
				0,
				0,
				0,
				44,
				0,
				0,
				0,
				0,
				40,
				0,
				0,
				0,
				0,
				38,
				0,
				0,
				0,
				0,
				15,
				0,
				0,
				0,
				1,
				1,
				0,
				0,
				0,
				1,
				2,
				0,
				0,
				0,
				0,
				27,
				0,
				0,
				0,
				0,
				29,
				0,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				0,
				2,
				0,
				0,
				0,
				0,
				3,
				0,
				0,
				0,
				0,
				4,
				0,
				0,
				0,
				0,
				5,
				0,
				0,
				0,
				0,
				6,
				0,
				0,
				0,
				0,
				26,
				0,
				0,
				0,
				1,
				0,
				0,
				0,
				16,
				1,
				0,
				0,
				0,
				32,
				0,
				16,
				0,
				0,
				0,
				0,
				55,
				0,
				0,
				0,
				0,
				22,
				0,
				0,
				0,
				0,
				92,
				0,
				0,
				0,
				0,
				91,
				0,
				0,
				0,
				0,
				37,
				0,
				0,
				0,
				0,
				64,
				0,
				0,
				0,
				0,
				65,
				0,
				0,
				0,
				0,
				21,
				0,
				0,
				0,
				0,
				31,
				0,
				0,
				0,
				0,
				35,
				0,
				0,
				0,
				0,
				33,
				0,
				0,
				0,
				0,
				12,
				0,
				0,
				0,
				0,
				14,
				0,
				0,
				0,
				0,
				49,
				0,
				0,
				0,
				0,
				50,
				0,
				0,
				0,
				0,
				70,
				0,
				0,
				0,
				0,
				66,
				0,
				0,
				0,
				0,
				11,
				0,
				0,
				0,
				0,
				58,
				0,
				0,
				0,
				0,
				255,
				255,
				255,
				255,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0,
				1,
				0
			};
			array[0] = Convert.ToByte(account.sangue);
			array[2] = Convert.ToByte(account.mira);
			array[3] = Convert.ToByte(account.mao);
			array[4] = Convert.ToByte(account.config);
			array[8] = Convert.ToByte(account.audio_enable);
			array[14] = Convert.ToByte(account.audio1);
			array[15] = Convert.ToByte(account.audio2);
			array[16] = Convert.ToByte(account.visao);
			base.writeB(array);
		}
	}
}
