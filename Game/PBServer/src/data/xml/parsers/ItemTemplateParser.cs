using PBServer.src.commons.utils;
using PBServer.src.data.xml.holders;
using PBServer.src.templates;
using System;
using System.IO;
using System.Xml;

namespace PBServer.src.data.xml.parsers
{
	public class ItemTemplateParser
	{
		private ItemTemplateHolder _holder;

		private static ItemTemplateParser _instance;

		public ItemTemplateParser()
		{
			bool flag = this._holder == null;
			if (flag)
			{
				this._holder = ItemTemplateHolder.getInstance();
			}
			string text = "Data//Items";
			bool flag2 = Directory.Exists(text);
			if (flag2)
			{
				string[] files = Directory.GetFiles(text, "*.xml", SearchOption.AllDirectories);
				for (int i = 0; i < files.Length; i++)
				{
					this.parse(files[i]);
				}
			}
			else
			{
				CLogger.getInstance().info("[ItemTemplateParser]: No Have Dir: " + text);
			}
			bool flag3 = this._holder != null;
			if (flag3)
			{
				this._holder.log();
			}
		}

		public static ItemTemplateParser getInstance()
		{
			bool flag = ItemTemplateParser._instance == null;
			if (flag)
			{
				ItemTemplateParser._instance = new ItemTemplateParser();
			}
			return ItemTemplateParser._instance;
		}

		private void parse(string path)
		{
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length == 0L;
			if (flag)
			{
				CLogger.getInstance().info("[ItemTemplateParser]: File is Empty: " + path);
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
								bool flag3 = "weapon".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									string value = attributes.GetNamedItem("name").Value;
									int num = int.Parse(attributes.GetNamedItem("id").Value);
									ParamSet paramSet = new ParamSet();
									paramSet.set("id", num);
									paramSet.set("name", value);
									WeaponTemplate item = new WeaponTemplate(paramSet);
									this._holder.addWeaponTemplate(item);
								}
								else
								{
									bool flag4 = "armor".Equals(xmlNode2.Name);
									if (flag4)
									{
										XmlNamedNodeMap attributes = xmlNode2.Attributes;
										string value = attributes.GetNamedItem("name").Value;
										int num = int.Parse(attributes.GetNamedItem("id").Value);
										ParamSet paramSet = new ParamSet();
										paramSet.set("id", num);
										paramSet.set("name", value);
										ArmorTemplate item2 = new ArmorTemplate(paramSet);
										this._holder.addArmorTemplate(item2);
									}
									else
									{
										bool flag5 = "cupon".Equals(xmlNode2.Name);
										if (flag5)
										{
											XmlNamedNodeMap attributes = xmlNode2.Attributes;
											string value = attributes.GetNamedItem("name").Value;
											int num = int.Parse(attributes.GetNamedItem("id").Value);
											ParamSet paramSet = new ParamSet();
											paramSet.set("id", num);
											paramSet.set("name", value);
											CuponsTemplate item3 = new CuponsTemplate(paramSet);
											this._holder.addCuponsTemplate(item3);
										}
									}
								}
							}
						}
					}
				}
				catch (XmlException ex)
				{
					CLogger.getInstance().info("[ITP]: Error in file: " + path);
					CLogger.getInstance().info("[ITP]: " + ex.Message);
				}
				fileStream.Close();
			}
		}
	}
}
