using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_BASE_LOGIN_REQ : ReceiveBaseLoginPacket
	{
		private int _GAME_VER;

		private string _login;

		private string _passwd;

		private int _UNK_C2;

		private int _UNK_C3;

		private int _UNK_C4;

		public byte[] _MAC
		{
			get;
			set;
		}

		public short _UNKH
		{
			get;
			set;
		}

		public PROTOCOL_BASE_LOGIN_REQ(LoginClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			int num = (int)base.readH();
			this._GAME_VER = (int)base.readC();
			base.readB(5);
			this._UNK_C2 = (int)base.readC();
			this._UNK_C3 = (int)base.readC();
			this._login = base.readS(this._UNK_C2);
			this._passwd = base.readS(this._UNK_C3);
			this._MAC = base.readB(6);
			this._UNKH = base.readH();
			this._UNK_C4 = (int)base.readC();
		}

		protected internal override void run()
		{
			CLogger.getInstance().extra_info("[Login] " + this._login + " connecting to the server.");
			AccountManager instance = AccountManager.getInstance();
			bool flag = !instance.accountExists(this._login) && Config.AUTO_ACCOUNTS && this._login.Length > 4 && this._passwd.Length > 4 && !instance.CreateAccount(this._login, this._passwd);
			if (flag)
			{
                base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483390L));
				base.getClient().close();
			}
			else
			{
				Account account = instance.get(this._login) ?? instance.SearchAccountInDB(this._login, this._passwd);
				bool flag2 = account == null || !account.validatePassword(this._passwd);
				if (flag2)
				{
					base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483390L));
				}
				else
				{
					bool onlyGM = Config.onlyGM;
					if (onlyGM)
					{
						bool flag3 = account.access_level > 0;
						if (flag3)
						{
							bool flag4 = !instance.get(this._login).getOnline();
							if (flag4)
							{
								base.getClient().setLogin(this._login);
								base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(1L));
								instance.get(this._login).setOnlineStatus(true);
							}
							else
							{
								instance.get(this._login).setConnected(false);
								instance.get(this._login).setOnlineStatus(false);
								base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483391L));
							}
						}
						else
						{
							base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483378L));
							base.getClient().close();
						}
					}
					else
					{
						bool flag5 = account.access_level >= 0;
						if (flag5)
						{
							bool flag6 = !instance.get(this._login).getOnline();
							if (flag6)
							{
								base.getClient().setLogin(this._login);
								base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(1L));
								instance.get(this._login).setOnlineStatus(true);
							}
							else
							{
								instance.get(this._login).setConnected(false);
								instance.get(this._login).setOnlineStatus(false);
								base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483391L));
							}
						}
						else
						{
							bool flag7 = account.access_level < 0;
							if (flag7)
							{
								base.getClient().sendPacket(new PROTOCOL_BASE_LOGIN_ACK(2147483385L));
								base.getClient().close();
							}
						}
					}
				}
			}
		}
	}
}
