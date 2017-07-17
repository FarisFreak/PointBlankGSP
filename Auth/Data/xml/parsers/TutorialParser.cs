using PBServer;
using PBServer.src.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Data.xml.parsers
{
	public class TutorialParser
	{
		public static Dictionary<int, Mission> tutorial = new Dictionary<int, Mission>();

		public static void Load()
		{
			string path = "Data//Missions//Tutorial.xml";
			XmlDocument xmlDocument = new XmlDocument();
			FileStream fileStream = new FileStream(path, FileMode.Open);
			bool flag = fileStream.Length != 0L;
			if (flag)
			{
				try
				{
					xmlDocument.Load(fileStream);
					for (XmlNode xmlNode = xmlDocument.FirstChild; xmlNode != null; xmlNode = xmlNode.NextSibling)
					{
						bool flag2 = "List".Equals(xmlNode.Name);
						if (flag2)
						{
							for (XmlNode xmlNode2 = xmlNode.FirstChild; xmlNode2 != null; xmlNode2 = xmlNode2.NextSibling)
							{
								bool flag3 = "Card".Equals(xmlNode2.Name);
								if (flag3)
								{
									XmlNamedNodeMap attributes = xmlNode2.Attributes;
									Mission mission = new Mission
									{
										Id = int.Parse(attributes.GetNamedItem("Id").Value),
										Mission1 = int.Parse(attributes.GetNamedItem("Mission1").Value),
										Type1 = int.Parse(attributes.GetNamedItem("Type1").Value),
										Mission2 = int.Parse(attributes.GetNamedItem("Mission2").Value),
										Type2 = int.Parse(attributes.GetNamedItem("Type2").Value),
										Mission3 = int.Parse(attributes.GetNamedItem("Mission3").Value),
										Type3 = int.Parse(attributes.GetNamedItem("Type3").Value),
										Mission4 = int.Parse(attributes.GetNamedItem("Mission4").Value),
										Type4 = int.Parse(attributes.GetNamedItem("Type4").Value),
										EXP = int.Parse(attributes.GetNamedItem("EXP").Value),
										Points = int.Parse(attributes.GetNamedItem("Points").Value),
										Item = int.Parse(attributes.GetNamedItem("Item").Value)
									};
									TutorialParser.tutorial.Add(mission.Id, mission);
								}
							}
						}
					}
					CLogger.getInstance().info("[Card] Loaded: " + TutorialParser.tutorial.Count + " cards.");
				}
				catch (XmlException arg)
				{
					CLogger.getInstance().error("Error " + arg);
				}
				fileStream.Close();
			}
		}
	}
}
