using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.db
{
	public class SQL_Block
	{
		private string _table;

		private MySqlCommand cmd;

		private MySqlConnection connection;

		private List<string[]> values = new List<string[]>();

		private List<string[]> values2 = new List<string[]>();

		public SQL_Block(string table)
		{
			this._table = table;
		}

		public void off()
		{
			this.connection.Close();
		}

		public void on()
		{
			this.connection = SQLjec.getInstance().conn();
			this.cmd = this.connection.CreateCommand();
			this.connection.Open();
		}

		public void param(string p, object v)
		{
			this.values.Add(new string[]
			{
				p,
				v.ToString()
			});
		}

		public void sql_delete(bool ex)
		{
			bool flag = !ex;
			if (flag)
			{
				this.connection = SQLjec.getInstance().conn();
				this.cmd = this.connection.CreateCommand();
				this.connection.Open();
			}
			string text = "";
			short num = 0;
			foreach (string[] current in this.values2)
			{
				text = string.Concat(new string[]
				{
					text,
					current[0],
					"='",
					current[1],
					"'"
				});
				num += 1;
				bool flag2 = (int)num < this.values2.Count;
				if (flag2)
				{
					text += " and ";
				}
			}
			this.cmd.CommandText = "delete from " + this._table + " where " + text;
			this.cmd.CommandType = CommandType.Text;
			this.cmd.ExecuteNonQuery();
			bool flag3 = !ex;
			if (flag3)
			{
				this.connection.Close();
			}
			else
			{
				this.values.Clear();
				this.values2.Clear();
			}
		}

		public void sql_insert(bool ex)
		{
			bool flag = !ex;
			if (flag)
			{
				this.connection = SQLjec.getInstance().conn();
				this.cmd = this.connection.CreateCommand();
				this.connection.Open();
			}
			string text = "";
			string text2 = "";
			short num = 0;
			foreach (string[] current in this.values)
			{
				text += current[0];
				text2 = text2 + "'" + current[1] + "'";
				num += 1;
				bool flag2 = (int)num < this.values.Count;
				if (flag2)
				{
					text += ",";
					text2 += ",";
				}
			}
			this.cmd.CommandText = string.Concat(new string[]
			{
				"insert into ",
				this._table,
				" (",
				text,
				") values (",
				text2,
				")"
			});
			this.cmd.CommandType = CommandType.Text;
			this.cmd.ExecuteNonQuery();
			bool flag3 = !ex;
			if (flag3)
			{
				this.connection.Close();
			}
			else
			{
				this.values.Clear();
				this.values2.Clear();
			}
		}

		public void sql_update(bool ex)
		{
			bool flag = !ex;
			if (flag)
			{
				this.connection = SQLjec.getInstance().conn();
				this.cmd = this.connection.CreateCommand();
				this.connection.Open();
			}
			string text = "";
			string text2 = "";
			byte b = 0;
			foreach (string[] current in this.values)
			{
				text = string.Concat(new string[]
				{
					text,
					current[0],
					"='",
					current[1],
					"'"
				});
				b += 1;
				bool flag2 = (int)b < this.values.Count;
				if (flag2)
				{
					text += ",";
				}
			}
			byte b2 = 0;
			foreach (string[] current2 in this.values2)
			{
				text2 = string.Concat(new string[]
				{
					text2,
					current2[0],
					"='",
					current2[1],
					"'"
				});
				b2 += 1;
				bool flag3 = (int)b2 < this.values2.Count;
				if (flag3)
				{
					text2 += " and ";
				}
			}
			this.cmd.CommandText = string.Concat(new string[]
			{
				"update ",
				this._table,
				" set ",
				text,
				" where ",
				text2
			});
			this.cmd.CommandType = CommandType.Text;
			this.cmd.ExecuteNonQuery();
			bool flag4 = !ex;
			if (flag4)
			{
				this.connection.Close();
			}
			else
			{
				this.values.Clear();
				this.values2.Clear();
			}
		}

		public void where(string p, object v)
		{
			this.values2.Add(new string[]
			{
				p,
				v.ToString()
			});
		}
	}
}
