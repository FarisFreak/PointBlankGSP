using PBServer.data.model;
using PBServer.data.xml.holders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PBServer.data.xml.parsers
{
	public class StartedInventoryItemsParser
	{
		private StartedInventoryItemsHolder _holder;

		private static StartedInventoryItemsParser _instance;

		public StartedInventoryItemsParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = StartedInventoryItemsHolder.getInstance();
			}
			string text = "Data//StartedInventoryItems.xml";
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				this.parse(text);
			}
			else
			{
				CLogger.getInstance().warning("|[SIP]| No Have File: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static StartedInventoryItemsParser getInstance()
		{
			bool flag = StartedInventoryItemsParser._instance == null;
			if (flag)
			{
				StartedInventoryItemsParser._instance = new StartedInventoryItemsParser();
			}
			return StartedInventoryItemsParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().warning("|[SIIP]| File is Empty: " + path);
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
								bool flag3 = "initial".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									List<PlayerTemplateInventory> list = new List<PlayerTemplateInventory>();
									int id = int.Parse(attributes.GetNamedItem("id").Value);
									string value = attributes.GetNamedItem("name").Value;
									int slot = int.Parse(attributes.GetNamedItem("slot").Value);
									int num = int.Parse(attributes.GetNamedItem("equip").Value);
									int count = int.Parse(attributes.GetNamedItem("count").Value);
									PlayerTemplateInventory playerTemplate = new PlayerTemplateInventory
									{
										id = id,
										name = value,
										slot = slot,
										onEquip = num,
										count = count,
										equip_type = num
									};
									this._holder.addInventoryStatic(playerTemplate);
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
