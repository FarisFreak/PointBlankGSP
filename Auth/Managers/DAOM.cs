using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.model.players;
using System;
using System.Data;

namespace Managers
{
	internal class DAOM
	{
		private static DAOM acm = new DAOM();

		public PlayerInventory getItem(long obj_id)
		{
			MySqlConnection mySqlConnection = SQLjec.getInstance().conn();
			try
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = string.Concat(new string[]
				{
					"SELECT object_id FROM items WHERE item_id='" + obj_id + "'"
				});
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
			}
			finally
			{
				bool flag = mySqlConnection != null;
				if (flag)
				{
					((IDisposable)mySqlConnection).Dispose();
				}
			}
			return null;
		}

		public static DAOM getInstance()
		{
			return DAOM.acm;
		}
	}
}
