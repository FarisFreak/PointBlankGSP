using Model;
using MySql.Data.MySqlClient;
using PBServer.db;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class PlayerManager
	{
		protected List<Player> _accounts = new List<Player>();

		private static PlayerManager acm = new PlayerManager();

		public int dbstatus = 0;

		private int id = 1;

		public PlayerManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM player";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Player item = new Player
						{
							player_id = mySqlDataReader.GetInt32("Player_Id"),
							player_name = mySqlDataReader.GetString("Player_Name"),
							access_level = mySqlDataReader.GetInt32("Access_level"),
							name_color = mySqlDataReader.GetInt32("NickName_Color"),
							point = mySqlDataReader.GetInt32("Point"),
							_rank = mySqlDataReader.GetInt32("Rank"),
							cash = mySqlDataReader.GetInt32("Cash"),
							exp = mySqlDataReader.GetInt32("Exp"),
							clan_id = mySqlDataReader.GetInt32("Clan_Id"),
							pc_cafe = mySqlDataReader.GetInt32("Pc_Cafe"),
							_status = mySqlDataReader.GetInt32("Online"),
							title_slot_count = mySqlDataReader.GetInt32("Title_slot_count"),
							mission_id = mySqlDataReader.GetInt32("Mission_id"),
							card_id = mySqlDataReader.GetInt32("Card_id")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Player] Loaded: " + this._accounts.Count + " info(s).");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Player] database not found");
				CLogger.getInstance().error("[Player] " + ex.ToString());
			}
		}

		public List<Player> getAccounts()
		{
			return this._accounts;
		}

		public Player get(string username)
		{
			Player result;
			foreach (Player current in PlayerManager.getInstance().getAccounts())
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

		public static PlayerManager getInstance()
		{
			return PlayerManager.acm;
		}
	}
}
