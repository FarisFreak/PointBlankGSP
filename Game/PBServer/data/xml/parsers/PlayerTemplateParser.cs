using PBServer.data.model;
using PBServer.data.xml.holders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace PBServer.data.xml.parsers
{
	public class PlayerTemplateParser
	{
		private PlayerTemplateHolder _holder;

		private static PlayerTemplateParser _instance;

		public PlayerTemplateParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = PlayerTemplateHolder.getInstance();
			}
			string text = "Data//PlayerTemplate.xml";
			bool flag2 = File.Exists(text);
			if (flag2)
			{
				this.parse(text);
			}
			else
			{
				CLogger.getInstance().info("[PlayerTemplateParser]: No Have File: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static PlayerTemplateParser getInstance()
		{
			bool flag = PlayerTemplateParser._instance == null;
			if (flag)
			{
				PlayerTemplateParser._instance = new PlayerTemplateParser();
			}
			return PlayerTemplateParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().info("[PlayerTemplateParser]: File is Empty: " + path);
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
								bool flag3 = "template".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									List<PlayerTemplateInventory> list = new List<PlayerTemplateInventory>();
									int id = int.Parse(attributes.GetNamedItem("id").Value);
									int rank = int.Parse(attributes.GetNamedItem("rank").Value);
									int gp = int.Parse(attributes.GetNamedItem("gp").Value);
									int exp = int.Parse(attributes.GetNamedItem("exp").Value);
									string[] array = attributes.GetNamedItem("itemid").Value.Split(new char[]
									{
										';'
									});
									for (int i = 0; i < array.Length - 1; i++)
									{
										string[] array2 = array[i].Split(new char[]
										{
											','
										});
										PlayerTemplateInventory item = new PlayerTemplateInventory
										{
											id = int.Parse(array2[0]),
											slot = int.Parse(array2[1]),
											onEquip = int.Parse(array2[2])
										};
										list.Add(item);
									}
									PlayerTemplate gsi = new PlayerTemplate(id, rank, exp, gp, list);
									this._holder.addPlayerTemplateInfo(gsi);
								}
							}
						}
					}
				}
				catch (XmlException ex)
				{
					CLogger.getInstance().info("[PlayerTemplateParser]: Error in file: " + path);
					throw ex;
				}
				fileStream.Close();
			}
		}
	}
}
