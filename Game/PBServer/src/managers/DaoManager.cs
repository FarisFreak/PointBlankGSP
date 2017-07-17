using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.model.accounts;
using PBServer.model.players;
using PBServer.src.model.accounts;
using System;
using System.Data;

namespace PBServer.src.managers
{
	public class DaoManager
	{
		private GameClient _gc;

		private MySqlCommand cmd;

		private MySqlConnection connection;

		public DaoManager(GameClient gc)
		{
			this._gc = gc;
			this.connection = SQLjec.getInstance().conn();
			this.cmd = this.connection.CreateCommand();
			this.connection.Open();
		}

		public int clearCookies()
		{
			this.cmd.CommandText = "delete from auth_cookies;";
			int result = this.cmd.ExecuteNonQuery();
			CLogger.getInstance().info("Cleaning old cookies: " + result.ToString());
			return result;
		}

		public PlayerInventory getInventory(int player_id)
		{
			this.cmd.CommandText = "SELECT * FROM items WHERE owner_id='" + player_id + "';";
			this.cmd.CommandType = CommandType.Text;
			PlayerInventory playerInventory = new PlayerInventory(player_id);
			MySqlDataReader mySqlDataReader = this.cmd.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				ItemsModel itemsModel = new ItemsModel
				{
					object_id = mySqlDataReader.GetInt32(0),
					id = mySqlDataReader.GetInt32(2),
					count = mySqlDataReader.GetInt32(5),
					slot = mySqlDataReader.GetInt32(6),
					equip_type = mySqlDataReader.GetInt32(7)
				};
				int @int = mySqlDataReader.GetInt32(4);
				playerInventory.getItemsAll().Add(itemsModel);
				bool flag = @int == 1;
				if (flag)
				{
					bool flag2 = itemsModel.slot == 1;
					if (flag2)
					{
						playerInventory.getEquipAll().PRIM = itemsModel.id;
					}
					else
					{
						bool flag3 = itemsModel.slot == 2;
						if (flag3)
						{
							playerInventory.getEquipAll().SUB = itemsModel.id;
						}
						else
						{
							bool flag4 = itemsModel.slot == 3;
							if (flag4)
							{
								playerInventory.getEquipAll().MELEE = itemsModel.id;
							}
							else
							{
								bool flag5 = itemsModel.slot == 4;
								if (flag5)
								{
									playerInventory.getEquipAll().ITEM = itemsModel.id;
								}
								else
								{
									bool flag6 = itemsModel.slot == 5;
									if (flag6)
									{
										playerInventory.getEquipAll().THROWING = itemsModel.id;
									}
									else
									{
										bool flag7 = itemsModel.slot == 6;
										if (flag7)
										{
											playerInventory.getEquipAll().CHAR_RED = itemsModel.id;
										}
										else
										{
											bool flag8 = itemsModel.slot == 7;
											if (flag8)
											{
												playerInventory.getEquipAll().CHAR_BLUE = itemsModel.id;
											}
											else
											{
												bool flag9 = itemsModel.slot == 8;
												if (flag9)
												{
													playerInventory.getEquipAll().CHAR_HEAD = itemsModel.id;
												}
												else
												{
													bool flag10 = itemsModel.slot == 9;
													if (flag10)
													{
														playerInventory.getEquipAll().CHAR_DINO = itemsModel.id;
													}
													else
													{
														bool flag11 = itemsModel.slot == 10;
														if (flag11)
														{
															playerInventory.getEquipAll().CHAR_ITEM = itemsModel.id;
														}
														else
														{
															bool flag12 = itemsModel.slot == 11;
															if (flag12)
															{
																playerInventory.getEquipAll().CUPON = itemsModel.id;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return playerInventory;
		}

		public Account getPlayerInfo(int player_id)
		{
			this.cmd.CommandText = "SELECT * FROM accounts WHERE player_id='" + player_id + "' LIMIT 1;";
			this.cmd.CommandType = CommandType.Text;
			Account account = new Account();
			MySqlDataReader mySqlDataReader = this.cmd.ExecuteReader();
			while (mySqlDataReader.Read())
			{
				account.setPlayerId(mySqlDataReader.GetInt32(1));
				account.setPlayerName(mySqlDataReader.GetString(2));
				account.setRank(mySqlDataReader.GetInt32(5));
				account.setGP(mySqlDataReader.GetInt32(6));
				account.setMoney(mySqlDataReader.GetInt32(32));
				account.setExp(mySqlDataReader.GetInt32(7));
			}
			mySqlDataReader.Close();
			this.connection.Close();
			return account;
		}

		public bool onCookie(string cookie)
		{
			this.cmd.CommandText = "SELECT cookie FROM auth_cookies WHERE cookie= '" + cookie + "';";
			this.cmd.CommandType = CommandType.Text;
			MySqlDataReader mySqlDataReader = this.cmd.ExecuteReader();
			bool result;
			while (mySqlDataReader.Read())
			{
				string @string = mySqlDataReader.GetString(0);
				bool flag = cookie == @string;
				if (flag)
				{
					mySqlDataReader.Close();
					result = true;
					return result;
				}
			}
			bool flag2 = !mySqlDataReader.IsClosed;
			if (flag2)
			{
				mySqlDataReader.Close();
			}
			result = false;
			return result;
		}

		public void removeCookie(string cookie)
		{
			this.cmd.CommandText = "delete from auth_cookies where cookie='" + cookie + "';";
			this.cmd.ExecuteNonQuery();
		}

		public void SetCookies(string cookies, string login)
		{
			this.cmd.CommandText = string.Concat(new string[]
			{
				"INSERT INTO auth_cookies (login, cookie) VALUES ('",
				login,
				"','",
				cookies,
				"');"
			});
			this.cmd.ExecuteNonQuery();
		}

		public bool WebAuth(string login, string password, AccessLevel accl)
		{
			bool flag = login != null && password != null;
			bool result;
			if (flag)
			{
				this.cmd.CommandText = "SELECT login, password, access_level FROM `accounts`;";
				MySqlDataReader mySqlDataReader = this.cmd.ExecuteReader();
				while (mySqlDataReader.Read())
				{
					int @int = mySqlDataReader.GetInt32(2);
					string @string = mySqlDataReader.GetString(0);
					string string2 = mySqlDataReader.GetString(1);
					bool flag2 = @string == login && string2 == password;
					if (flag2)
					{
						bool flag3 = accl == AccessLevel.Admin;
						if (flag3)
						{
							mySqlDataReader.Close();
							result = (@int == 5);
							return result;
						}
						mySqlDataReader.Close();
						result = true;
						return result;
					}
				}
				bool flag4 = !mySqlDataReader.IsClosed;
				if (flag4)
				{
					mySqlDataReader.Close();
				}
			}
			result = false;
			return result;
		}
	}
}
