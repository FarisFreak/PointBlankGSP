using PBServer.data.model;
using PBServer.data.xml.holders;
using System;
using System.IO;
using System.Xml;

namespace PBServer.data.xml.parsers
{
	public class RankExpInfoParser
	{
		private RankExpInfoHolder _holder;

		private static RankExpInfoParser _instance;

		public RankExpInfoParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = RankExpInfoHolder.getInstance();
			}
			string text = "Data//RankInfoTemplate.xml";
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				this.parse(text);
			}
			else
			{
				CLogger.getInstance().warning("[RankExpInfoParser]: No Have File: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static RankExpInfoParser getInstance()
		{
			bool flag = RankExpInfoParser._instance == null;
			if (flag)
			{
				RankExpInfoParser._instance = new RankExpInfoParser();
			}
			return RankExpInfoParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().warning("[RankExpInfoParser]: File is Empty: " + path);
			}
			else
			{
				try
				{
					xmlDocument.Load(fileStream);
					for (XmlNode xmlNode = xmlDocument.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
					{
						bool flag2 = "list".Equals(xmlNode.Name);
						if (flag2)
						{
							for (XmlNode xmlNode2 = xmlNode.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
							{
								bool flag3 = "rank".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									this._holder.addRankExpInfo(new RankExpModel(attributes.GetNamedItem("name").Value, int.Parse(attributes.GetNamedItem("rank").Value), int.Parse(attributes.GetNamedItem("onNextLevel").Value), int.Parse(attributes.GetNamedItem("onGPUp").Value), int.Parse(attributes.GetNamedItem("onItemUp").Value), int.Parse(attributes.GetNamedItem("onAllExp").Value)));
								}
							}
						}
					}
				}
				catch (XmlException ex)
				{
					CLogger.getInstance().warning("[RankExpInfoParser]: Error in file: " + path);
					CLogger.getInstance().info(ex.Message);
				}
				fileStream.Close();
			}
		}
	}
}
