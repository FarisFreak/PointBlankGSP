using Model;
using MySql.Data.MySqlClient;
using PBServer;
using PBServer.db;
using System;
using System.Collections.Generic;
using System.Data;

namespace Managers
{
	public class EquipManager
	{
		protected List<Equip> _accounts = new List<Equip>();

		private static EquipManager acm = new EquipManager();

		public int dbstatus = 0;

		private int id = 1;

		public EquipManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM player_equip";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Equip item = new Equip
						{
							player_id = mySqlDataReader.GetInt32("Player_Id"),
							weapon_primary = mySqlDataReader.GetInt32("Weapon_Primary"),
							weapon_secondary = mySqlDataReader.GetInt32("Weapon_Secondary"),
							weapon_melee = mySqlDataReader.GetInt32("Weapon_Melee"),
							weapon_thrown_normal = mySqlDataReader.GetInt32("Weapon_Thrown_Normal"),
							weapon_thrown_special = mySqlDataReader.GetInt32("Weapon_Thrown_Special"),
							char_red = mySqlDataReader.GetInt32("Char_Red"),
							char_blue = mySqlDataReader.GetInt32("Char_Blue"),
							char_helmet = mySqlDataReader.GetInt32("Char_Helmet"),
							char_dino = mySqlDataReader.GetInt32("Char_Dino"),
							char_beret = mySqlDataReader.GetInt32("Char_Beret")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Equip] Loaded: " + this._accounts.Count + " info(s).");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Equip] database not found");
				CLogger.getInstance().error("[Equip] " + ex.ToString());
			}
		}

		public List<Equip> getAccounts()
		{
			return this._accounts;
		}

		public Equip get(string username)
		{
			Equip result;
			foreach (Equip current in EquipManager.getInstance().getAccounts())
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

		public static EquipManager getInstance()
		{
			return EquipManager.acm;
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
						"UPDATE player_equip SET Weapon_Primary='",
						primary,
						"' WHERE Player_Id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE player_equip SET Weapon_Secondary='",
						secondary,
						"' WHERE Player_Id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE player_equip SET Weapon_Melee='",
						melee,
						"' WHERE Player_Id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE player_equip SET Weapon_Thrown_Normal='",
						thrown_normal,
						"' WHERE Player_Id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE player_equip SET Weapon_Thrown_Special='",
						thrown_special,
						"' WHERE Player_Id='",
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
