using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class ConfigManager
	{
		protected List<ConfigP> _accounts = new List<ConfigP>();

		private static ConfigManager acm = new ConfigManager();

		public int dbstatus = 0;

		private int id = 1;

		public ConfigManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM configs";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						ConfigP item = new ConfigP
						{
							ownerid = mySqlDataReader.GetInt32("owner_id"),
							ownername = mySqlDataReader.GetString("owner_name"),
							config = mySqlDataReader.GetInt32("config"),
							mira = mySqlDataReader.GetInt32("mira"),
							mao = mySqlDataReader.GetInt32("mao"),
							sangue = mySqlDataReader.GetInt32("sangue"),
							audio1 = mySqlDataReader.GetInt32("audio1"),
							audio2 = mySqlDataReader.GetInt32("audio2"),
							sensibilidade = mySqlDataReader.GetInt32("sensibilidade"),
							visao = mySqlDataReader.GetInt32("visao"),
							audio_enable = mySqlDataReader.GetInt32("audio_enable")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Config] Loaded: " + this._accounts.Count + " configs.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Config] database not found");
				CLogger.getInstance().error("[Config] " + ex.ToString());
			}
		}

		public void AddConfig(ConfigP acc)
		{
			this._accounts.Add(acc);
		}

		public void AddConfigDb(int player_id, int audio1, int audio2, int sensibilidade, int visao, int sangue, int mira, string name, int mao, int audio_enable, int config)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"INSERT INTO configs (owner_id, sangue, mira, audio1, audio2, sensibilidade, visao, owner_name, mao, audio_enable, config) VALUES ('",
						player_id,
						"', '",
						sangue,
						"', '",
						mira,
						"', '",
						audio1,
						"', '",
						audio2,
						"', '",
						sensibilidade,
						"', '",
						visao,
						"', '",
						name,
						"', '",
						mao,
						"', '",
						audio_enable,
						"', '",
						config,
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

		public ConfigP getInfoItem(int item_id)
		{
			ConfigP result;
			foreach (ConfigP current in this._accounts)
			{
				bool flag = current.ownerid == item_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public ConfigP getInfoItem2(string name)
		{
			ConfigP result;
			foreach (ConfigP current in this._accounts)
			{
				bool flag = current.ownername == name;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public static ConfigManager getInstance()
		{
			return ConfigManager.acm;
		}

		public void UpdateConfig(int player_id, int audio1, int audio2, int mira, int sensibilidade, int visao, int sangue, int mao, int audio_enable, int config)
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
						"UPDATE configs SET mira='",
						mira,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET audio1='",
						audio1,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET audio2='",
						audio2,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET sensibilidade='",
						sensibilidade,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET visao='",
						visao,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET sangue='",
						sangue,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET mao='",
						mao,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET audio_enable='",
						audio_enable,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE configs SET config='",
						config,
						"' WHERE owner_id='",
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
