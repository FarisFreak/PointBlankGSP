using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class MessageManager
	{
		protected List<Message> _accounts = new List<Message>();

		private static MessageManager acm = new MessageManager();

		public int dbstatus = 0;

		private int id = 1;

		public MessageManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM message";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						Message item = new Message
						{
							owner_id = mySqlDataReader.GetInt32("owner_id"),
							recipient_name = mySqlDataReader.GetString("recipient_name"),
							object_id = mySqlDataReader.GetInt32("object_id"),
							text = mySqlDataReader.GetString("text")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Message] Loaded: " + this._accounts.Count + " messages.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Message] database not found");
				CLogger.getInstance().error("[Message] " + ex.ToString());
			}
		}

		public void AddMessage(Message acc)
		{
			this._accounts.Add(acc);
		}

		public void createMessageInDb(string destinatario, int ownerId, int object_id, string texto)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					string.Concat(new object[]
					{
						"INSERT INTO message(object_id, owner_id, recipient_name, text)VALUES('",
						object_id,
						"','",
						ownerId,
						"','",
						destinatario,
						"','",
						texto,
						"')"
					})
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public void excludeMessageInDb(int id)
		{
			using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
			{
				mySqlConnection.Open();
				new MySqlCommand(string.Concat(new object[]
				{
					"DELETE FROM message WHERE object_id='" + id + "'"
				}), mySqlConnection).ExecuteNonQuery();
			}
		}

		public static MessageManager getInstance()
		{
			return MessageManager.acm;
		}

		public Message getMessage(int id)
		{
			Message result;
			foreach (Message current in this._accounts)
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

		public Message getMessageForObjId(int obj_id)
		{
			Message result;
			foreach (Message current in this._accounts)
			{
				bool flag = current.object_id == obj_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public List<Message> getMessages()
		{
			return this._accounts;
		}
	}
}
