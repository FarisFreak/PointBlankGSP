using PBServer.src.data.xml.holders;
using PBServer.src.model;
using System;
using System.IO;
using System.Xml;

namespace PBServer.src.data.xml.parsers
{
	public class ChannelInfoParser
	{
		private ChannelInfoHolder _holder;

		private static ChannelInfoParser _instance;

		public ChannelInfoParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = ChannelInfoHolder.getInstance();
			}
			string text = "Data//ChannelTemplate.xml";
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				this.parse(text);
			}
			else
			{
				CLogger.getInstance().info("[ChannelInfoParser]: No Have File: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static ChannelInfoParser getInstance()
		{
			bool flag = ChannelInfoParser._instance == null;
			if (flag)
			{
				ChannelInfoParser._instance = new ChannelInfoParser();
			}
			return ChannelInfoParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().info("[ChannelInfoParser]: File is Empty: " + path);
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
								bool flag3 = "channel".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									int id = int.Parse(attributes.GetNamedItem("id").Value);
									int type = int.Parse(attributes.GetNamedItem("type").Value);
									string value = attributes.GetNamedItem("name").Value;
									string value2 = attributes.GetNamedItem("announce").Value;
									int max_players = int.Parse(attributes.GetNamedItem("max_players").Value);
									string value3 = attributes.GetNamedItem("ip").Value;
									int port = int.Parse(attributes.GetNamedItem("port").Value);
									this._holder.addChannelInfo(new Channel(id, type, value2, max_players, value, value3, port));
								}
							}
						}
					}
				}
				catch (XmlException ex)
				{
					CLogger.getInstance().info("[ChannelInfoParser]: Error in file: " + path);
					CLogger.getInstance().info(ex.Message);
				}
				fileStream.Close();
			}
		}
	}
}
