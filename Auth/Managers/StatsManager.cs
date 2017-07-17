using Model;
using MySql.Data.MySqlClient;
using PBServer;
using PBServer.db;
using PBServer.model.players;
using System;
using System.Collections.Generic;
using System.Data;

namespace Managers
{
	public class StatsManager
	{
		protected List<Stats> _accounts = new List<Stats>();

		private static StatsManager acm = new StatsManager();

		public int dbstatus = 0;

		private int id = 1;

		public static Dictionary<int, PlayerStats> statistics;

		public StatsManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM player_stats";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Stats stats = new Stats
						{
							player_id = mySqlDataReader.GetInt32("Player_Id")
						};
						stats._statistic = new PlayerStats();
						stats._statistic.setFights(mySqlDataReader.GetInt32("Fights_s"));
						stats._statistic.setWinFights(mySqlDataReader.GetInt32("Fights_Win_s"));
						stats._statistic.setLostFights(mySqlDataReader.GetInt32("Fights_Lost_s"));
						stats._statistic.setKills(mySqlDataReader.GetInt32("Kills_Count_s"));
						stats._statistic.setDeaths(mySqlDataReader.GetInt32("Deaths_Count_s"));
						stats._statistic.setHeadShotKilled(mySqlDataReader.GetInt32("Headshots_Count_s"));
						stats._statistic.setEscapes(mySqlDataReader.GetInt32("Escapes_s"));
						this._accounts.Add(stats);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Stats] Loaded: " + this._accounts.Count + " info(s).");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Stats] database not found");
				CLogger.getInstance().error("[Stats] " + ex.ToString());
			}
		}

		public List<Stats> getAccounts()
		{
			return this._accounts;
		}

		public Stats get(string username)
		{
			Stats result;
			foreach (Stats current in StatsManager.getInstance().getAccounts())
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

		public static StatsManager getInstance()
		{
			return StatsManager.acm;
		}
	}
}
