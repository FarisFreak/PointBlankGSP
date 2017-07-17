using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model.friends;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class FriendManager
	{
		public List<Friends> _clans = new List<Friends>();

		private static FriendManager clm = new FriendManager();

		public int dbstatus = 0;

		private int id = 1;

		public FriendManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM friends";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Friends item = new Friends
						{
							FriendNumered = mySqlDataReader.GetInt32("object_id"),
							friend_id = mySqlDataReader.GetInt32("friend_id"),
							owner_id = mySqlDataReader.GetInt32("owner_id")
						};
						this._clans.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Friend] Loaded: " + this._clans.Count + " friends.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Friend] database not found");
				CLogger.getInstance().error("[Friend] " + ex.ToString());
			}
		}

		public void AddFriend(int friend_id, int owner_id)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					string.Concat(new object[]
					{
						"INSERT INTO friends(friend_id,owner_id)VALUES('",
						friend_id,
						"','",
						owner_id,
						"')"
					})
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public void excludeFriendInDb(int object_id)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					"DELETE FROM friends WHERE object_id='" + object_id + "'"
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public Friends get(int object_id)
		{
			Friends result;
			foreach (Friends current in this._clans)
			{
				bool flag = current.owner_id == object_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Friends> getAccounts()
		{
			return this._clans;
		}

		public Friends getFriend2(int number_id)
		{
			Friends result;
			foreach (Friends current in this._clans)
			{
				bool flag = current.FriendNumered == number_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public int getFriendForOwnerId(int owner_id)
		{
			int result;
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
				mySqlConnection.Open();
				mySqlCommand.CommandText = "SELECT friend_id FROM friends WHERE owner_id='" + owner_id + "'';";
				mySqlCommand.CommandType = CommandType.Text;
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				bool flag = mySqlDataReader.Read();
				if (flag)
				{
					result = mySqlDataReader.GetInt32("friend_id");
					return result;
				}
			}
			result = 0;
			return result;
		}

		public List<Friends> getFriends(int owner_id)
		{
			List<Friends> list = new List<Friends>();
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM friends WHERE owner_id='" + owner_id + "'";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Friends item = new Friends
						{
							FriendNumered = mySqlDataReader.GetInt32("object_id"),
							friend_id = mySqlDataReader.GetInt32("friend_id"),
							owner_id = mySqlDataReader.GetInt32("owner_id")
						};
						list.Add(item);
						this.id++;
					}
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Friend] database not found");
				CLogger.getInstance().error("[Friend] " + ex.ToString());
			}
			return list;
		}

		public static FriendManager getInstance()
		{
			return FriendManager.clm;
		}
	}
}
