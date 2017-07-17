using MySql.Data.MySqlClient;
using PBServer.db;
using PBServer.src.model.accounts;
using System;
using System.Collections.Generic;
using System.Data;

namespace PBServer.src.managers
{
	public class ShopInfoManager
	{
		protected List<ShopInfo> _accounts = new List<ShopInfo>();

		private static ShopInfoManager acm = new ShopInfoManager();

		public int dbstatus = 0;

		private int id = 1;

		public ShopInfoManager()
		{
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM shop";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						ShopInfo item = new ShopInfo
						{
							good_id = mySqlDataReader.GetInt32("good_id"),
							item_id = mySqlDataReader.GetInt32("item_id"),
							item_name = mySqlDataReader.GetString("item_name"),
							price_gold = mySqlDataReader.GetInt32("price_gold"),
							price_cash = mySqlDataReader.GetInt32("price_cash"),
							count = mySqlDataReader.GetInt32("count"),
							buy_type = mySqlDataReader.GetInt32("buy_type"),
							buy_type2 = mySqlDataReader.GetInt32("buy_type2"),
							equip = mySqlDataReader.GetInt32("equip"),
							tag = mySqlDataReader.GetInt32("tag"),
							title = mySqlDataReader.GetInt32("title")
						};
						this._accounts.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Shop] Loaded: " + this._accounts.Count + " items.");
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Shop] database not found");
				CLogger.getInstance().error("[Shop] " + ex.ToString());
			}
		}

		public ShopInfo getInfoItem(int item_id)
		{
			ShopInfo result;
			foreach (ShopInfo current in this._accounts)
			{
				bool flag = current.item_id == item_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public ShopInfo getInfoItem2(int good_id)
		{
			ShopInfo result;
			foreach (ShopInfo current in this._accounts)
			{
				bool flag = current.good_id == good_id;
				if (flag)
				{
					result = current;
					return result;
				}
			}
			result = null;
			return result;
		}

		public static ShopInfoManager getInstance()
		{
			return ShopInfoManager.acm;
		}

		public List<ShopInfo> getShopItens()
		{
			return this._accounts;
		}

		public List<ShopInfo> pegarItensAtual()
		{
			List<ShopInfo> list = new List<ShopInfo>();
			List<ShopInfo> result;
			try
			{
				using (MySqlConnection mySqlConnection = SQLjec.getInstance().conn())
				{
					MySqlCommand mySqlCommand = mySqlConnection.CreateCommand();
					mySqlConnection.Open();
					mySqlCommand.CommandText = "SELECT * FROM shop";
					mySqlCommand.CommandType = CommandType.Text;
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					while (mySqlDataReader.Read())
					{
						ShopInfo item = new ShopInfo
						{
							good_id = mySqlDataReader.GetInt32("good_id"),
							item_id = mySqlDataReader.GetInt32("item_id"),
							item_name = mySqlDataReader.GetString("item_name"),
							price_gold = mySqlDataReader.GetInt32("price_gold"),
							price_cash = mySqlDataReader.GetInt32("price_cash"),
							count = mySqlDataReader.GetInt32("count"),
							buy_type = mySqlDataReader.GetInt32("buy_type"),
							buy_type2 = mySqlDataReader.GetInt32("buy_type2"),
							equip = mySqlDataReader.GetInt32("equip"),
							tag = mySqlDataReader.GetInt32("tag"),
							title = mySqlDataReader.GetInt32("title")
						};
						list.Add(item);
						this.id++;
					}
					CLogger.getInstance().extra_info("[Shop] Loaded: " + this._accounts.Count + " items.");
					result = list;
				}
			}
			catch (Exception ex)
			{
				this.dbstatus = -100;
				CLogger.getInstance().error("[Shop] database not found");
				CLogger.getInstance().error("[Shop] " + ex.ToString());
				result = list;
			}
			return result;
		}
	}
}
