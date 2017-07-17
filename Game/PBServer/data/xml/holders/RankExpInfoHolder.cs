using PBServer.data.model;
using System;
using System.Collections.Generic;

namespace PBServer.data.xml.holders
{
	public class RankExpInfoHolder
	{
		private static RankExpInfoHolder _instance;

		private static List<RankExpModel> _ranks = new List<RankExpModel>();

		internal void addRankExpInfo(RankExpModel rem)
		{
			RankExpInfoHolder._ranks.Add(rem);
		}

		public void clear()
		{
			RankExpInfoHolder._ranks.Clear();
		}

		public List<RankExpModel> getAllRankExpInfos()
		{
			return RankExpInfoHolder._ranks;
		}

		public static RankExpInfoHolder getInstance()
		{
			bool flag = RankExpInfoHolder._instance == null;
			if (flag)
			{
				RankExpInfoHolder._instance = new RankExpInfoHolder();
			}
			return RankExpInfoHolder._instance;
		}

		public static RankExpModel getRankExpInfo(int remlId)
		{
			return RankExpInfoHolder._ranks[remlId];
		}

		internal void log()
		{
			CLogger.getInstance().info("[Rank] Loaded: " + RankExpInfoHolder._ranks.Count + " rank(s) info.");
		}
	}
}
