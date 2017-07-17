using PBServer.data.model;
using System;
using System.Collections.Generic;

namespace PBServer.data.xml.holders
{
	public class PlayerTemplateHolder
	{
		private static PlayerTemplateHolder _instance;

		private static List<PlayerTemplate> _templates = new List<PlayerTemplate>();

		internal void addPlayerTemplateInfo(PlayerTemplate gsi)
		{
			PlayerTemplateHolder._templates.Add(gsi);
		}

		public void clear()
		{
			PlayerTemplateHolder._templates.Clear();
		}

		public List<PlayerTemplate> getAllPlayerTemplateInfos()
		{
			return PlayerTemplateHolder._templates;
		}

		public static PlayerTemplateHolder getInstance()
		{
			bool flag = PlayerTemplateHolder._instance == null;
			if (flag)
			{
				PlayerTemplateHolder._instance = new PlayerTemplateHolder();
			}
			return PlayerTemplateHolder._instance;
		}

		public static PlayerTemplate getPlayerTemplate(int templateId)
		{
			bool flag = templateId > -1;
			PlayerTemplate result;
			if (flag)
			{
				result = PlayerTemplateHolder._templates[templateId - 1];
			}
			else
			{
				result = null;
			}
			return result;
		}

		internal void log()
		{
			CLogger.getInstance().info("[Template] Loaded: " + PlayerTemplateHolder._templates.Count + " player template(s) info");
		}
	}
}
