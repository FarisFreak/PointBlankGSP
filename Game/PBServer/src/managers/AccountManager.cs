using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.model.players;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class AccountManager
	{
		protected List<Account> _accounts = new List<Account>();

		public List<ItemsModel> _items = new List<ItemsModel>();

		private static AccountManager acm = new AccountManager();

		public static Dictionary<int, PlayerStats> statistics;

		public int dbstatus = 0;

		private int id = 1;

		public AccountManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM accounts";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Account account = new Account
						{
							id = this.id,
							name = mySqlDataReader.GetString("login"),
							player_name = mySqlDataReader.GetString("player_name")
						};
						account.setPlayerId(mySqlDataReader.GetInt32("player_id"));
						account.password = mySqlDataReader.GetString("password");
						account.access_level = mySqlDataReader.GetInt32("access_level");
						account.name_color = mySqlDataReader.GetInt32("name_color");
						account.gp = mySqlDataReader.GetInt32("gp");
						account.setRank(mySqlDataReader.GetInt32("rank"));
						account.money = mySqlDataReader.GetInt32("money");
						account.exp = mySqlDataReader.GetInt32("exp");
						account.clan_id = mySqlDataReader.GetInt32("clan_id");
						account._coupon = mySqlDataReader.GetInt32("cupon");
						account.pc_cafe = mySqlDataReader.GetInt32("pc_cafe");
						account._statistic = new PlayerStats();
						account._statistic.setFights(mySqlDataReader.GetInt32("fights_s"));
						account._statistic.setWinFights(mySqlDataReader.GetInt32("fights_win_s"));
						account._statistic.setLostFights(mySqlDataReader.GetInt32("fights_lost_s"));
						account._statistic.setKills(mySqlDataReader.GetInt32("kills_count_s"));
						account._statistic.setDeaths(mySqlDataReader.GetInt32("deaths_count_s"));
						account._statistic.setHeadShotKilled(mySqlDataReader.GetInt32("headshots_count_s"));
						account._statistic.setEscapes(mySqlDataReader.GetInt32("escapes_s"));
						account._status = mySqlDataReader.GetInt32("online");
						account.weapon_primary = mySqlDataReader.GetInt32("weapon_primary");
						account.weapon_secondary = mySqlDataReader.GetInt32("weapon_secondary");
						account.weapon_melee = mySqlDataReader.GetInt32("weapon_melee");
						account.weapon_thrown_normal = mySqlDataReader.GetInt32("weapon_thrown_normal");
						account.weapon_thrown_special = mySqlDataReader.GetInt32("weapon_thrown_special");
						account.char_red = mySqlDataReader.GetInt32("char_red");
						account.char_blue = mySqlDataReader.GetInt32("char_blue");
						account.char_helmet = mySqlDataReader.GetInt32("char_helmet");
						account.char_dino = mySqlDataReader.GetInt32("char_dino");
						account.char_beret = mySqlDataReader.GetInt32("char_beret");
						account.brooch = mySqlDataReader.GetInt32("brooch");
						account.insignia = mySqlDataReader.GetInt32("insignia");
						account.medal = mySqlDataReader.GetInt32("medal");
						account.blue_order = mySqlDataReader.GetInt32("blue_order");
						account.title_slot_count = mySqlDataReader.GetInt32("title_slot_count");
						account.mission_id = mySqlDataReader.GetInt32("mission_id");
						account.card_id = mySqlDataReader.GetInt32("card_id");
						this._accounts.Add(account);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Account] Loaded: " + this._accounts.Count + " accounts.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Account] database not found");
				CLogger.getInstance().error("[Account] " + ex.ToString());
			}
		}

		public bool accountExists(string user)
		{
			return AccountManager.getInstance().get(user) != null;
		}

		public void AddAccount(Account acc)
		{
			this._accounts.Add(acc);
		}

		public void AddInitialItems(int player_id, ItemsModel item, string name, int equip)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"INSERT INTO items (owner_id, item_id, item_name, item_type, count, loc_slot, equip) VALUES ('",
						player_id,
						"', '",
						item.id.ToString(),
						"', '",
						name,
						"', '",
						equip,
						"', '",
						item.count,
						"', '",
						item.slot,
						"', '",
						item.equip,
						"');"
					});
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch
			{
			}
		}

		public ItemsModel get(int object_id)
		{
			ItemsModel result;
			foreach (ItemsModel current in this._items)
			{
				bool flag = current.id == object_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public void AddItem(Account p, int itemid, int slot)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET player_name='",
						p.getPlayerName(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void DeleteItem(Account p, int itemid)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = "DELETE FROM items WHERE item_id='" + itemid + "';";
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public bool CreateAccount(string login, string password)
		{
			bool result;
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT COUNT(*) FROM accounts WHERE login='" + login + "';";
					mySqlCommand.ExecuteScalar();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"INSERT INTO accounts (login, password) VALUES ('",
						login,
						"', '",
						password,
						"');"
					});
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = "SELECT * FROM accounts WHERE login='" + login + "';";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					Account account = new Account();
					while (mySqlDataReader.Read())
					{
						account.player_id = mySqlDataReader.GetInt32("player_id");
					}
					account.name = login;
					account.password = password;
					account.setInventory(new PlayerInventory(account.player_id));
					this.AddAccount(account);
					result = true;
				}
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error("[Account] Create an account[" + login + "]");
				CLogger.getInstance().error("[Account] " + ex.ToString());
				result = false;
			}
			return result;
		}

		public int CreatePlayer(string account, Account p)
		{
			int result;
			int num;
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = "SELECT COUNT(*) FROM accounts WHERE player_name='" + p.getPlayerName() + "'";
					bool flag = Convert.ToInt32(mySqlCommand.ExecuteScalar()) != 0;
					if (flag)
					{
						result = -1;
						return result;
					}
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET player_name='",
						p.getPlayerName(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET rank='",
						p.getRank().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET exp='",
						p.getExp().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET gp='",
						p.getGP().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET kills_count_s='",
						p._statistic.getKills_s().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET deaths_count_s='",
						p._statistic.getDeaths_s().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					num = 0;
				}
			}
			catch (MySqlException)
			{
				num = -1;
			}
			result = num;
			return result;
		}

		public void deleteCookie(string cookie)
		{
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.cookie == cookie;
				if (flag)
				{
					current.cookie = "";
				}
			}
		}

		public void DescontItem(int weaponId, int ownerId, int weaponCount)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE items SET count='",
						weaponCount,
						"' WHERE owner_id='",
						ownerId,
						"' AND item_id='",
						weaponId,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public Account get(string username)
		{
			Account result;
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.name.ToLower() == username.ToLower();
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public Account getAccountInName(string player_name)
		{
			Account result;
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.player_name == player_name;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public Account getAccountInObjectId(int player_id)
		{
			Account result;
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.player_id == player_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public Account getAccountInPlayerId(int object_id)
		{
			Account result;
			foreach (Account current in this._accounts)
			{
				bool flag = current.player_id == object_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Account> getAccounts()
		{
			return this._accounts;
		}

		public int getCountForItemId(int item_id, int owner_id)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new object[]
				{
					"SELECT count FROM items WHERE item_id='",
					item_id,
					"' AND owner_id='",
					owner_id,
					"';"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("count");
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getObjectForItemId(int item_id, int owner_id)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new object[]
				{
					"SELECT object_id FROM items WHERE item_id='",
					item_id,
					"' AND owner_id='",
					owner_id,
					"';"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("item_id");
					return result;
				}
			}
			result = 0;
			return result;
		}

		public static AccountManager getInstance()
		{
			return AccountManager.acm;
		}

		public int getAddCoupon(int item_id, int player_id)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new object[]
				{
					"UPDATE accounts SET cupon='",
					item_id,
					"' WHERE player_id='",
					player_id,
					"';"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("cupon");
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getCoupon(int coupon, int player_id)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new object[]
				{
					"SELECT * FROM accounts WHERE cupon='",
					coupon,
					"' AND player_id='",
					player_id,
					"';"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("cupon");
					return result;
				}
			}
			result = 0;
			return result;
		}

		public int getItemIdForOBID(int obj_id)
		{
			MySqlConnection mySqlConnection = SQLjec.getInstance().conn();
			int num;
			int result;
			try
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = "SELECT item_id FROM items WHERE object_id='" + obj_id + "';";
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					int @int = mySqlDataReader.GetInt32(2);
					mySqlConnection.Close();
					num = @int;
					result = num;
					return result;
				}
			}
			finally
			{
				bool flag2 = mySqlConnection != null;
				if (flag2)
				{
					((IDisposable)mySqlConnection).Dispose();
				}
			}
			num = 0;
			result = num;
			return result;
		}

		public PlayerInventory getInventory(int item_id)
		{
			PlayerInventory result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new object[]
				{
					"SELECT equip FROM items WHERE item_id='",
					item_id,
					"'AND equip=",
					2,
					";"
				});
				mySqlCommand.CommandType = CommandType.Text;
				PlayerInventory playerInventory = new PlayerInventory(item_id);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
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
				result = playerInventory;
			}
			return result;
		}

		public ItemsModel getItem(int obj_id)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = "SELECT count FROM items WHERE item_id='" + obj_id + "';";
				mySqlCommand.CommandType = CommandType.Text;
			}
			return null;
		}

		public List<Account> getOnlineAccounts()
		{
			List<Account> list = new List<Account>();
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.getClient() != null;
				if (flag)
				{
					list.Add(current);
				}
			}
			return list;
		}

		public int getPlayerId(string name)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = "SELECT player_id FROM accounts WHERE player_name='" + name + "' LIMIT 1;";
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("player_id");
					return result;
				}
			}
			result = -1;
			return result;
		}

		public bool isCookie(string cookie)
		{
			bool result;
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.cookie == cookie;
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public bool isPlayerNameExist(string name)
		{
			bool result;
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = "SELECT COUNT(*) FROM accounts WHERE player_name='" + name + "'";
					result = (Convert.ToInt32(mySqlCommand.ExecuteScalar()) != 0);
				}
			}
			catch
			{
				result = true;
			}
			return result;
		}

		public Account SearchAccountInDB(string login, string password)
		{
			Account result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				Account account = new Account();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new string[]
				{
					"SELECT * FROM accounts WHERE login='",
					login,
					"' AND password='",
					password,
					"' LIMIT 1;"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = !mySqlDataReader.Read();
				if (flag)
				{
					result = null;
				}
				else
				{
					account.id = this._accounts.Count + 1;
					account.name = mySqlDataReader.GetString("login");
					account.player_name = mySqlDataReader.GetString("player_name");
					account.name_color = mySqlDataReader.GetInt32("name_color");
					account.setPlayerId(mySqlDataReader.GetInt32("player_id"));
					account.password = mySqlDataReader.GetString("password");
					account.access_level = mySqlDataReader.GetInt32("access_level");
					account.gp = mySqlDataReader.GetInt32("gp");
					account.setRank(mySqlDataReader.GetInt32("rank"));
					account.money = mySqlDataReader.GetInt32("money");
					account.exp = mySqlDataReader.GetInt32("exp");
					account.clan_id = mySqlDataReader.GetInt32("clan_id");
					account.pc_cafe = mySqlDataReader.GetInt32("pc_cafe");
					account._statistic = new PlayerStats();
					account._statistic.setFights(mySqlDataReader.GetInt32("fights_s"));
					account._statistic.setWinFights(mySqlDataReader.GetInt32("fights_win_s"));
					account._statistic.setLostFights(mySqlDataReader.GetInt32("fights_lost_s"));
					account._statistic.setKills(mySqlDataReader.GetInt32("kills_count_s"));
					account._statistic.setDeaths(mySqlDataReader.GetInt32("deaths_count_s"));
					account._statistic.setEscapes(mySqlDataReader.GetInt32("escapes_s"));
					account._status = mySqlDataReader.GetInt32("online");
					account.weapon_primary = mySqlDataReader.GetInt32("weapon_primary");
					account.weapon_secondary = mySqlDataReader.GetInt32("weapon_secondary");
					account.weapon_melee = mySqlDataReader.GetInt32("weapon_melee");
					account.weapon_thrown_normal = mySqlDataReader.GetInt32("weapon_thrown_normal");
					account.weapon_thrown_special = mySqlDataReader.GetInt32("weapon_thrown_special");
					account.char_red = mySqlDataReader.GetInt32("char_red");
					account.char_blue = mySqlDataReader.GetInt32("char_blue");
					account.char_helmet = mySqlDataReader.GetInt32("char_helmet");
					account.char_dino = mySqlDataReader.GetInt32("char_dino");
					account.char_beret = mySqlDataReader.GetInt32("char_beret");
					account.brooch = mySqlDataReader.GetInt32("brooch");
					account.insignia = mySqlDataReader.GetInt32("insignia");
					account.medal = mySqlDataReader.GetInt32("medal");
					account.blue_order = mySqlDataReader.GetInt32("blue_order");
					account.title_slot_count = mySqlDataReader.GetInt32("title_slot_count");
					this._accounts.Add(account);
					CLogger.getInstance().extra_info("[Account] Search accounts[" + login + "]");
					result = account;
				}
			}
			return result;
		}

		public void setCookie(string cookie, string login)
		{
			foreach (Account current in AccountManager.getInstance().getAccounts())
			{
				bool flag = current.name == login;
				if (flag)
				{
					current.cookie = cookie;
				}
			}
		}

		public void UpdateCharItens(int player_id, int char_red, int char_blue, int char_helmet, int char_beret, int char_dino)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET char_red='",
						char_red,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET char_blue='",
						char_blue,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET char_helmet='",
						char_helmet,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET char_beret='",
						char_beret,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET char_dino='",
						char_dino,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void UpdateClan(int player_id, int clan_id)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET clan_id='",
						clan_id,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void updateEscapes(Account player)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET escapes_s='",
						player._statistic.getEscapes_s(),
						"' WHERE player_id='",
						player.getPlayerId(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void updateStatusItem(int obj_id)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE items SET equip='",
						2,
						"' WHERE item_id='",
						obj_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void updateFights(int partidas, int partidas_ganhas, int partidas_perdidas, int id_do_jogador)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET fights_s='",
						partidas,
						"' WHERE player_id='",
						id_do_jogador,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET fights_win_s='",
						partidas_ganhas,
						"' WHERE player_id='",
						id_do_jogador,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET fights_lost_s='",
						partidas_perdidas,
						"' WHERE player_id='",
						id_do_jogador,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void UpdateMGP(int player_id, int gold, int cash)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET gp='",
						gold,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET money='",
						cash,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void UpdateMission(int player_id, int mission_id, int card_id)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET mission_id='",
						mission_id,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET card_id='",
						card_id,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void updatePlayer(Account p)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					CLogger.getInstance().warning("[Server] Updating information Player " + p.getPlayerName());
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET rank='",
						p.getRank(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET exp='",
						p.getExp(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET gp='",
						p.getGP(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET money='",
						p.getMoney(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET kills_count_s='",
						p._statistic.getKills_s().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET deaths_count_s='",
						p._statistic.getDeaths_s().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new string[]
					{
						"UPDATE accounts SET headshots_count_s='",
						p._statistic.getHeadShotKills().ToString(),
						"' WHERE player_id='",
						p.player_id.ToString(),
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
				this.get(p.name).setRank(p.getRank());
				this.get(p.name).setExp(p.getExp());
				this.get(p.name).setGP(p.getGP());
				this.get(p.name).setMoney(p.getMoney());
			}
			catch (Exception ex)
			{
				CLogger.getInstance().warning("[Account] Error Update player: " + ex.ToString());
			}
		}

		public void UpdateStatus(int player_id, int status)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET online='",
						status,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void UpdateTitleSlotCount(int player_id, int title_slot_count)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET title_slot_count='",
						title_slot_count,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}

		public void UpdateWeaponItens(int player_id, int primary, int secondary, int melee, int thrown_normal, int thrown_special)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET weapon_primary='",
						primary,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET weapon_secondary='",
						secondary,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET weapon_melee='",
						melee,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET weapon_thrown_normal='",
						thrown_normal,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE accounts SET weapon_thrown_special='",
						thrown_special,
						"' WHERE player_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				throw ex;
			}
		}
	}
}
