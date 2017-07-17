using PBServer.src.commons.data.holders;
using PBServer.src.templates;
using System;
using System.Collections.Generic;

namespace PBServer.src.data.xml.holders
{
	internal class ItemTemplateHolder : IHolder
	{
		private static List<ArmorTemplate> _armors = new List<ArmorTemplate>();

		private static List<CuponsTemplate> _cupons = new List<CuponsTemplate>();

		private static ItemTemplateHolder _instance;

		private static List<WeaponTemplate> _weapons = new List<WeaponTemplate>();

		public void addArmorTemplate(ArmorTemplate item)
		{
			ItemTemplateHolder._armors.Add(item);
		}

		public void addCuponsTemplate(CuponsTemplate item)
		{
			ItemTemplateHolder._cupons.Add(item);
		}

		public void addWeaponTemplate(WeaponTemplate item)
		{
			ItemTemplateHolder._weapons.Add(item);
		}

		public void clear()
		{
			ItemTemplateHolder._weapons.Clear();
		}

		public List<ArmorTemplate> getAllArmors()
		{
			return ItemTemplateHolder._armors;
		}

		public List<CuponsTemplate> getAllCupons()
		{
			return ItemTemplateHolder._cupons;
		}

		public List<WeaponTemplate> getAllWeapons()
		{
			return ItemTemplateHolder._weapons;
		}

		public ArmorTemplate getArmorTemplate(int id)
		{
			return ItemTemplateHolder._armors[id];
		}

		public CuponsTemplate getCuponsTemplate(int id)
		{
			return ItemTemplateHolder._cupons[id];
		}

		public static ItemTemplateHolder getInstance()
		{
			bool flag = ItemTemplateHolder._instance == null;
			if (flag)
			{
				ItemTemplateHolder._instance = new ItemTemplateHolder();
			}
			return ItemTemplateHolder._instance;
		}

		public WeaponTemplate getWeaponTemplate(int id)
		{
			return ItemTemplateHolder._weapons[id];
		}

		public void log()
		{
			CLogger.getInstance().info("[Item] Loaded: " + ItemTemplateHolder._weapons.Count + " Weapons.");
			CLogger.getInstance().info("[Item] Loaded: " + ItemTemplateHolder._armors.Count + " Armors.");
			CLogger.getInstance().info("[Item] Loaded: " + ItemTemplateHolder._cupons.Count + " Cupons.");
		}
	}
}
