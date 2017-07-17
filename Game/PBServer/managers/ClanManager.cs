using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.model.clans;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.managers
{
	public class ClanManager
	{
		public List<Clan> _clans = new List<Clan>();

		private static ClanManager clm = new ClanManager();

		public int dbstatus = 0;

		private int id = 1;

		public ClanManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM clan_data";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Clan item = new Clan
						{
							clan_id = mySqlDataReader.GetInt32("clan_id"),
							clan_name = mySqlDataReader.GetString("clan_name"),
							clan_rank = mySqlDataReader.GetInt32("clan_rank"),
							owner_id = mySqlDataReader.GetInt32("owner_id"),
							clan_news = mySqlDataReader.GetString("clan_news"),
							clan_info = mySqlDataReader.GetString("clan_info"),
							dateCreated = mySqlDataReader.GetInt32("create_date"),
							_logo1 = mySqlDataReader.GetInt32("logo1"),
							_logo2 = mySqlDataReader.GetInt32("logo2"),
							_logo3 = mySqlDataReader.GetInt32("logo3"),
							_logo4 = mySqlDataReader.GetInt32("logo4"),
							_color = mySqlDataReader.GetInt32("color")
						};
						this._clans.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Clan] Loaded: " + this._clans.Count + " clans.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Clan] database not found.");
				CLogger.getInstance().error("[Clan] " + ex.ToString());
			}
		}

		public void AddClan(Clan clan)
		{
			this._clans.Add(clan);
		}

		public void createClanInDb(string name, int ownerId)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					string.Concat(new object[]
					{
						"INSERT INTO clan_data(clan_id,clan_name,owner_id,create_date)VALUES('",
						ownerId,
						"','",
						name,
						"','",
						ownerId,
						"','",
						DateTime.Now.ToString("yyyyMMdd"),
						"')"
					})
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public void excludeClanInDb(int id)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					"DELETE FROM clan_data WHERE clan_id='" + id + "'"
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public Clan get(int object_id)
		{
			Clan result;
			foreach (Clan current in this._clans)
			{
				bool flag = current.clan_id == object_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public Clan getClanForName(string name)
		{
			Clan result;
			foreach (Clan current in this._clans)
			{
				bool flag = current.clan_name == name;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Account> getClanPlayers(int clan_id)
		{
			List<Account> list = new List<Account>();
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM accounts WHERE clan_id='" + clan_id + "'";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Account item = new Account
						{
							name = mySqlDataReader.GetString("login"),
							password = mySqlDataReader.GetString("password"),
							clan_id = mySqlDataReader.GetInt32("clan_id"),
							player_name = mySqlDataReader.GetString("player_name"),
							name_color = mySqlDataReader.GetInt32("name_color"),
							exp = mySqlDataReader.GetInt32("exp"),
							money = mySqlDataReader.GetInt32("money"),
							gp = mySqlDataReader.GetInt32("gp"),
							player_id = mySqlDataReader.GetInt32("player_id"),
							_rank = mySqlDataReader.GetInt32("rank"),
							_connection = ((AccountManager.getInstance().getAccountInPlayerId(mySqlDataReader.GetInt32("player_id")) == null) ? null : AccountManager.getInstance().getAccountInPlayerId(mySqlDataReader.GetInt32("player_id"))._connection)
						};
						list.Add(item);
						this.id++;
					}
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Clan] clan not found.");
				CLogger.getInstance().error("[Clan] " + ex.ToString());
			}
			return list;
		}

		public List<Clan> getClans()
		{
			return this._clans;
		}

		public static ClanManager getInstance()
		{
			return ClanManager.clm;
		}

		public void UpdateClanInfo(int clan_id, string clan_info)
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
						"UPDATE clan_data SET clan_info='",
						clan_info,
						"' WHERE clan_id='",
						clan_id,
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

		public void UpdateClanNews(int clan_id, string clan_info)
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
						"UPDATE clan_data SET clan_news='",
						clan_info,
						"' WHERE clan_id='",
						clan_id,
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
