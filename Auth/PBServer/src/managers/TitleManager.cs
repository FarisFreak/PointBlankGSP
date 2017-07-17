using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class TitleManager
	{
		protected List<Title> _accounts = new List<Title>();

		private static TitleManager acm = new TitleManager();

		public int dbstatus = 0;

		private int id = 1;

		public TitleManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM titles";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Title item = new Title
						{
							owner_id = mySqlDataReader.GetInt32("owner_id"),
							titleEquiped1 = mySqlDataReader.GetInt32("TitleEquiped1"),
							titleEquiped2 = mySqlDataReader.GetInt32("TitleEquiped2"),
							titleEquiped3 = mySqlDataReader.GetInt32("TitleEquiped3"),
							titlePos1 = mySqlDataReader.GetInt32("titlePos1"),
							titlePos2 = mySqlDataReader.GetInt32("titlePos2"),
							titlePos3 = mySqlDataReader.GetInt32("titlePos3"),
							titlePos4 = mySqlDataReader.GetInt32("titlePos4"),
							titlePos5 = mySqlDataReader.GetInt32("titlePos5"),
							titlePos6 = mySqlDataReader.GetInt32("titlePos6"),
							title1 = mySqlDataReader.GetInt32("title1"),
							title2 = mySqlDataReader.GetInt32("title2"),
							title3 = mySqlDataReader.GetInt32("title3"),
							title4 = mySqlDataReader.GetInt32("title4"),
							title5 = mySqlDataReader.GetInt32("title5"),
							title6 = mySqlDataReader.GetInt32("title6"),
							title7 = mySqlDataReader.GetInt32("title7"),
							title8 = mySqlDataReader.GetInt32("title8"),
							title9 = mySqlDataReader.GetInt32("title9"),
							title10 = mySqlDataReader.GetInt32("title10"),
							title11 = mySqlDataReader.GetInt32("title11"),
							title12 = mySqlDataReader.GetInt32("title12"),
							title13 = mySqlDataReader.GetInt32("title13"),
							title14 = mySqlDataReader.GetInt32("title14"),
							title15 = mySqlDataReader.GetInt32("title15"),
							title16 = mySqlDataReader.GetInt32("title16"),
							title17 = mySqlDataReader.GetInt32("title17"),
							title18 = mySqlDataReader.GetInt32("title18"),
							title19 = mySqlDataReader.GetInt32("title19"),
							title20 = mySqlDataReader.GetInt32("title20"),
							title21 = mySqlDataReader.GetInt32("title21"),
							title22 = mySqlDataReader.GetInt32("title22"),
							title23 = mySqlDataReader.GetInt32("title23"),
							title24 = mySqlDataReader.GetInt32("title24"),
							title25 = mySqlDataReader.GetInt32("title25"),
							title26 = mySqlDataReader.GetInt32("title26"),
							title27 = mySqlDataReader.GetInt32("title27"),
							title28 = mySqlDataReader.GetInt32("title28"),
							title29 = mySqlDataReader.GetInt32("title29"),
							title30 = mySqlDataReader.GetInt32("title30"),
							title31 = mySqlDataReader.GetInt32("title31"),
							title32 = mySqlDataReader.GetInt32("title32"),
							title33 = mySqlDataReader.GetInt32("title33"),
							title34 = mySqlDataReader.GetInt32("title34"),
							title35 = mySqlDataReader.GetInt32("title35"),
							title36 = mySqlDataReader.GetInt32("title36"),
							title37 = mySqlDataReader.GetInt32("title37"),
							title38 = mySqlDataReader.GetInt32("title38"),
							title39 = mySqlDataReader.GetInt32("title39"),
							title40 = mySqlDataReader.GetInt32("title40"),
							title41 = mySqlDataReader.GetInt32("title41"),
							title42 = mySqlDataReader.GetInt32("title42"),
							title43 = mySqlDataReader.GetInt32("title43"),
							title44 = mySqlDataReader.GetInt32("title44")
						};
						this._accounts.Add(item);
						this.id++;
					}
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Title] database not found");
				CLogger.getInstance().error("[Title] " + ex.ToString());
			}
		}

		public void AddTitle(Title acc)
		{
			this._accounts.Add(acc);
		}

		public void AddTitleDb(int player_id)
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "INSERT INTO titles (owner_id) VALUES ('" + player_id + "');";
					mySqlCommand.CommandType = CommandType.Text;
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch
			{
			}
		}

		public static TitleManager getInstance()
		{
			return TitleManager.acm;
		}

		public Title getTitle(int id)
		{
			Title result;
			foreach (Title current in this._accounts)
			{
				bool flag = current.owner_id == id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public void UpdatePosTitles(int player_id, int P1)
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
						"UPDATE titles SET titlePos1='",
						P1,
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

		public void UpdatePosTitles2(int player_id, int P2)
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
						"UPDATE titles SET titlePos2='",
						P2,
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

		public void UpdatePosTitles3(int player_id, int P3)
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
						"UPDATE titles SET titlePos3='",
						P3,
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

		public void UpdatePosTitles4(int player_id, int P4)
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
						"UPDATE titles SET titlePos4='",
						P4,
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

		public void UpdatePosTitles5(int player_id, int P5)
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
						"UPDATE titles SET titlePos5='",
						P5,
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

		public void UpdatePosTitles6(int player_id, int P6)
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
						"UPDATE titles SET titlePos6='",
						P6,
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

		public void UpdateTitle(int player_id, int slot1, int slot2, int slot3)
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
						"UPDATE titles SET TitleEquiped1='",
						slot1,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET TitleEquiped2='",
						slot2,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET TitleEquiped3='",
						slot3,
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

		public void UpdateTitles(int player_id, int T1, int T2, int T3, int T4, int T5, int T6, int T7)
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
						"UPDATE titles SET title1='",
						T1,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title2='",
						T2,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title3='",
						T3,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title4='",
						T4,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title5='",
						T5,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title6='",
						T6,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title7='",
						T7,
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

		public void UpdateTitles2(int player_id, int T8, int T9, int T10, int T11, int T12, int T13, int T14, int T15)
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
						"UPDATE titles SET title8='",
						T8,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title9='",
						T9,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title10='",
						T10,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title11='",
						T11,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title12='",
						T12,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title13='",
						T13,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title14='",
						T14,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title15='",
						T15,
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

		public void UpdateTitles3(int player_id, int T16, int T17, int T18, int T19, int T20, int T21, int T22, int T23)
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
						"UPDATE titles SET title16='",
						T16,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title17='",
						T17,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title18='",
						T18,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title19='",
						T19,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title20='",
						T20,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title21='",
						T21,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title22='",
						T22,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title23='",
						T23,
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

		public void UpdateTitles4(int player_id, int T24, int T25, int T26, int T27, int T28, int T29, int T30, int T31)
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
						"UPDATE titles SET title24='",
						T24,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title25='",
						T25,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title26='",
						T26,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title27='",
						T27,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title28='",
						T28,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title29='",
						T29,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title30='",
						T30,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title31='",
						T31,
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

		public void UpdateTitles5(int player_id, int T32, int T33, int T34, int T35, int T36, int T37, int T38, int T39)
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
						"UPDATE titles SET title32='",
						T32,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title33='",
						T33,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title34='",
						T34,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title35='",
						T35,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title36='",
						T36,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title37='",
						T37,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title38='",
						T38,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title39='",
						T39,
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

		public void UpdateTitles6(int player_id, int T40, int T41, int T42, int T43, int T44)
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
						"UPDATE titles SET title40='",
						T40,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title41='",
						T41,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title42='",
						T42,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title43='",
						T43,
						"' WHERE owner_id='",
						player_id,
						"';"
					});
					mySqlCommand.ExecuteNonQuery();
					mySqlCommand.CommandText = string.Concat(new object[]
					{
						"UPDATE titles SET title44='",
						T44,
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
