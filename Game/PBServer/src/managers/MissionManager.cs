using Model;
using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class MissionManager
	{
		protected List<Mission> _accounts = new List<Mission>();

		public static Dictionary<int, QuestCardSet> quests;

		private static MissionManager acm = new MissionManager();

		public int dbstatus = 0;

		private int id = 1;

		public Mission get(int object_id)
		{
			Mission result;
			foreach (Mission current in this._accounts)
			{
				bool flag = current.Id == object_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public MissionManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM missions";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Mission mission = new Mission
						{
							owner_id = mySqlDataReader.GetInt32("owner_id")
						};
						mission.cards_tutorial[1] = mySqlDataReader.GetInt32("mission_1");
						mission.cards_tutorial[2] = mySqlDataReader.GetInt32("mission_2");
						mission.cards_tutorial[3] = mySqlDataReader.GetInt32("mission_3");
						mission.cards_tutorial[4] = mySqlDataReader.GetInt32("mission_4");
						mission.cards_tutorial[5] = mySqlDataReader.GetInt32("mission_5");
						mission.cards_tutorial[6] = mySqlDataReader.GetInt32("mission_6");
						mission.cards_tutorial[7] = mySqlDataReader.GetInt32("mission_7");
						mission.cards_tutorial[8] = mySqlDataReader.GetInt32("mission_8");
						mission.cards_tutorial[9] = mySqlDataReader.GetInt32("mission_9");
						mission.cards_tutorial[10] = mySqlDataReader.GetInt32("mission_10");
						mission.cards_tutorial[11] = mySqlDataReader.GetInt32("mission_11");
						mission.cards_tutorial[12] = mySqlDataReader.GetInt32("mission_12");
						mission.cards_tutorial[13] = mySqlDataReader.GetInt32("mission_13");
						mission.cards_tutorial[14] = mySqlDataReader.GetInt32("mission_14");
						mission.cards_tutorial[15] = mySqlDataReader.GetInt32("mission_15");
						mission.cards_tutorial[16] = mySqlDataReader.GetInt32("mission_16");
						this._accounts.Add(mission);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Mission] Loaded: " + this._accounts.Count + " missions.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Mission] database not found");
				CLogger.getInstance().error("[Mission] " + ex.ToString());
			}
		}

		public void AddAccount(Mission acc)
		{
			this._accounts.Add(acc);
		}

		public Mission getAccountInName(int player_id)
		{
			Mission result;
			foreach (Mission current in MissionManager.getInstance().getAccounts())
			{
				bool flag = current.owner_id == player_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Mission> getAccounts()
		{
			return this._accounts;
		}

		public static MissionManager getInstance()
		{
			return MissionManager.acm;
		}
	}
}
