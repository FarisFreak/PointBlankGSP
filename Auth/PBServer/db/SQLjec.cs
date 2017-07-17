using MySql.Data.MySqlClient;
using System;
using System.Runtime.Remoting.Contexts;

namespace PBServer.db
{
	[Synchronization]
	public class SQLjec
	{
		protected MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();

		private static SQLjec sql = new SQLjec();

		public SQLjec()
		{
			this.connBuilder.Database = Config.DB_NAME;
			this.connBuilder.Server = Config.DB_HOST;
			this.connBuilder.UserID = Config.DB_USER;
			this.connBuilder.Password = Config.DB_PASS;
			this.connBuilder.Port = 3306u;
			CLogger.getInstance().info("[SQL] IP: " + Config.DB_HOST + ":3306");
			CLogger.getInstance().info("[SQL] MySQL: establishing connected...");
		}

		public MySqlConnection conn()
		{
			return new MySqlConnection(this.connBuilder.ConnectionString);
		}

		public static SQLjec getInstance()
		{
			return SQLjec.sql;
		}
	}
}
