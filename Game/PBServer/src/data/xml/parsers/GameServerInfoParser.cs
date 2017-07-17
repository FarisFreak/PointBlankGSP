using PBServer.src.data.model;
using PBServer.src.data.xml.holders;
using System;
using System.IO;
using System.Xml;

namespace PBServer.src.data.xml.parsers
{
	public class GameServerInfoParser
	{
		private GameServerInfoHolder _holder;

		private static GameServerInfoParser _instance;

		public GameServerInfoParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = GameServerInfoHolder.getInstance();
			}
			string text = "Data//GameServers.xml";
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				this.parse(text);
			}
			else
			{
				CLogger.getInstance().info("[GameServerInfoParser]: No Have File: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static GameServerInfoParser getInstance()
		{
			bool flag = GameServerInfoParser._instance == null;
			if (flag)
			{
				GameServerInfoParser._instance = new GameServerInfoParser();
			}
			return GameServerInfoParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().info("[GameServerInfoParser]: File is Empty: " + path);
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
								bool flag3 = "gameserver".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									this._holder.addGameServerInfo(new GameServerInfo(attributes.GetNamedItem("name").Value, int.Parse(attributes.GetNamedItem("id").Value), attributes.GetNamedItem("password").Value, int.Parse(attributes.GetNamedItem("type").Value), int.Parse(attributes.GetNamedItem("max_players").Value), attributes.GetNamedItem("ip").Value, int.Parse(attributes.GetNamedItem("port").Value)));
								}
							}
						}
					}
				}
				catch (XmlException ex)
				{
					CLogger.getInstance().info("[GameServerInfoParser]: Error in file: " + path);
					CLogger.getInstance().info("[GameServerInfoParser]: " + ex.Message);
				}
				fileStream.Close();
			}
		}
	}
}
