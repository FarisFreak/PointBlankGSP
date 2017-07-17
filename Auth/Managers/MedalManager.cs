using Model;
using MySql.Data.MySqlClient;
using PBServer;
using PBServer.db;
using System;
using System.Collections.Generic;
using System.Data;

namespace Managers
{
	internal class MedalManager
	{
		protected List<Medal> _accounts = new List<Medal>();

		private static MedalManager acm = new MedalManager();

		public int dbstatus = 0;

		private int id = 1;

		public MedalManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM player_medal";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Medal item = new Medal
						{
							player_id = mySqlDataReader.GetInt32("Player_Id"),
							brooch = mySqlDataReader.GetInt32("Brooch"),
							insignia = mySqlDataReader.GetInt32("Insignia"),
							medal = mySqlDataReader.GetInt32("Medal"),
							blue_order = mySqlDataReader.GetInt32("Blue_order")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Medal] Loaded: " + this._accounts.Count + " info(s).");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Medal] database not found");
				CLogger.getInstance().error("[Medal] " + ex.ToString());
			}
		}

		public List<Medal> getAccounts()
		{
			return this._accounts;
		}

		public Medal get(string username)
		{
			Medal result;
			foreach (Medal current in MedalManager.getInstance().getAccounts())
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

		public static MedalManager getInstance()
		{
			return MedalManager.acm;
		}
	}
}
