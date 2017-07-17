using PBServer.data.model;
using System;
using System.Collections.Generic;

namespace PBServer.data.xml.holders
{
	public class StartedInventoryItemsHolder
	{
		private static StartedInventoryItemsHolder _instance;

		private static List<PlayerTemplateInventory> _templates = new List<PlayerTemplateInventory>();

		public void addInventoryStatic(PlayerTemplateInventory playerTemplate)
		{
			StartedInventoryItemsHolder._templates.Add(playerTemplate);
		}

		public void clear()
		{
			StartedInventoryItemsHolder._templates.Clear();
		}

		public static StartedInventoryItemsHolder getInstance()
		{
			bool flag = StartedInventoryItemsHolder._instance == null;
			if (flag)
			{
				StartedInventoryItemsHolder._instance = new StartedInventoryItemsHolder();
			}
			return StartedInventoryItemsHolder._instance;
		}

		public List<PlayerTemplateInventory> getPlayerInventoryStatic()
		{
			return StartedInventoryItemsHolder._templates;
		}

		internal void log()
		{
			CLogger.getInstance().info("[Inventory] Loaded: " + StartedInventoryItemsHolder._templates.Count + " initial items.");
		}
	}
}
