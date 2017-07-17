using PBServer.data.model;
using PBServer.data.xml.holders;
using PBServer.src.managers;
using System;
using System.Collections.Generic;

namespace PBServer.model.players
{
	public class PlayerInventory
	{
		private PlayerEquep _equep = new PlayerEquep();

		private List<ItemsModel> _inventory = new List<ItemsModel>();

		public int player_id;

		public int equip_type = 2;

		public int count = 864000;

		public int id;

		public PlayerInventory(int id_do_jogador)
		{
			this.player_id = id_do_jogador;
		}

		public void AddItem(ItemsModel i)
		{
			this._inventory.Add(i);
		}

		public void addNewItem(int id, int slot, int equip, int count)
		{
			ItemsModel item = new ItemsModel
			{
				count = count,
				id = id,
				equip_type = equip,
				slot = slot
			};
			this._inventory.Add(item);
		}

		public void CheckCorrectInventory(int player_id)
		{
			bool flag = this.CheckEQInventory();
			if (flag)
			{
				List<PlayerTemplateInventory> playerInventoryStatic = StartedInventoryItemsHolder.getInstance().getPlayerInventoryStatic();
				for (int i = 0; i < playerInventoryStatic.Count; i++)
				{
					bool flag2 = !this.isItemInventoryExist(player_id, playerInventoryStatic[i].id);
					if (flag2)
					{
						ItemsModel item = new ItemsModel(playerInventoryStatic[i].id, playerInventoryStatic[i].slot, playerInventoryStatic[i].name, playerInventoryStatic[i].onEquip, playerInventoryStatic[i].count, playerInventoryStatic[i].equip_type, 1);
						this._inventory.Add(item);
						bool flag3 = playerInventoryStatic[i].onEquip == 1;
						if (flag3)
						{
							this.setEquipItemFromSlot(playerInventoryStatic[i].id, playerInventoryStatic[i].slot);
						}
						AccountManager.getInstance().AddInitialItems(player_id, item, playerInventoryStatic[i].name, playerInventoryStatic[i].onEquip);
					}
				}
			}
		}

		public bool CheckEQInventory()
		{
			bool result = false;
			bool flag = this._equep.CHAR_BLUE == 0 || this._equep.CHAR_DINO == 0 || this._equep.CHAR_HEAD == 0 || this._equep.CHAR_RED == 0;
			if (flag)
			{
				this._equep.CHAR_BLUE = AccountManager.getInstance().getAccountInObjectId(this.player_id).getCharBlue();
				this._equep.CHAR_DINO = AccountManager.getInstance().getAccountInObjectId(this.player_id).getCharDino();
				this._equep.CHAR_HEAD = AccountManager.getInstance().getAccountInObjectId(this.player_id).getCharHelmet();
				this._equep.CHAR_ITEM = AccountManager.getInstance().getAccountInObjectId(this.player_id).getCharBeret();
				this._equep.CHAR_RED = AccountManager.getInstance().getAccountInObjectId(this.player_id).getCharRed();
				result = true;
			}
			bool flag2 = this._equep.PRIM == 0 || this._equep.SUB == 0 || this._equep.MELEE == 0 || this._equep.ITEM == 0 || this._equep.THROWING == 0;
			if (flag2)
			{
				this._equep.PRIM = AccountManager.getInstance().getAccountInObjectId(this.player_id).getPrimaryWeapon();
				this._equep.SUB = AccountManager.getInstance().getAccountInObjectId(this.player_id).getSecondaryWeapon();
				this._equep.MELEE = AccountManager.getInstance().getAccountInObjectId(this.player_id).getMeleeWeapon();
				this._equep.ITEM = AccountManager.getInstance().getAccountInObjectId(this.player_id).getThrownNormalWeapon();
				this._equep.THROWING = AccountManager.getInstance().getAccountInObjectId(this.player_id).getThrownSpecialWeapon();
				result = true;
			}
			return result;
		}

		public List<ItemsModel> getAllItemsOnType(int type)
		{
			List<ItemsModel> list = new List<ItemsModel>();
			ItemsModel[] array = this._inventory.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				ItemsModel itemsModel = array[i];
				bool flag = itemsModel.slot >= 1 && itemsModel.slot < 6 && type == 1;
				if (flag)
				{
					list.Add(itemsModel);
				}
				bool flag2 = itemsModel.slot >= 6 && itemsModel.slot < 11 && type == 2;
				if (flag2)
				{
					list.Add(itemsModel);
				}
				bool flag3 = itemsModel.slot >= 11 && itemsModel.slot < 12 && type == 3;
				if (flag3)
				{
					list.Add(itemsModel);
				}
			}
			return list;
		}

		public List<ItemsModel> getAllItemsOnTypeEquip(int type)
		{
			List<ItemsModel> list = new List<ItemsModel>();
			ItemsModel[] array = this._inventory.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				ItemsModel itemsModel = array[i];
				bool flag = itemsModel.slot >= 1 && itemsModel.slot < 6 && type == 1 && itemsModel.equip == 1;
				if (flag)
				{
					list.Add(itemsModel);
				}
				bool flag2 = itemsModel.slot >= 6 && itemsModel.slot < 11 && type == 2 && itemsModel.equip == 2;
				if (flag2)
				{
					list.Add(itemsModel);
				}
				bool flag3 = itemsModel.slot >= 11 && itemsModel.slot < 12 && type == 3 && itemsModel.equip == 3;
				if (flag3)
				{
					list.Add(itemsModel);
				}
			}
			return list;
		}

		public List<ItemsModel> getAllNoEquipItems()
		{
			List<ItemsModel> list = new List<ItemsModel>();
			ItemsModel[] array = this._inventory.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				ItemsModel itemsModel = array[i];
				bool flag = itemsModel.equip == 0;
				if (flag)
				{
					list.Add(itemsModel);
				}
			}
			return list;
		}

		public PlayerEquep getEquipAll()
		{
			return this._equep;
		}

		public int getEquipItemFromSlot(int slot)
		{
			int result;
			switch (slot)
			{
			case 1:
				result = this._equep.PRIM;
				break;
			case 2:
				result = this._equep.SUB;
				break;
			case 3:
				result = this._equep.MELEE;
				break;
			case 4:
				result = this._equep.ITEM;
				break;
			case 5:
				result = this._equep.THROWING;
				break;
			case 6:
				result = this._equep.CHAR_RED;
				break;
			case 7:
				result = this._equep.CHAR_BLUE;
				break;
			case 8:
				result = this._equep.CHAR_HEAD;
				break;
			case 9:
				result = this._equep.CHAR_DINO;
				break;
			case 10:
				result = this._equep.CHAR_ITEM;
				break;
			default:
				result = 0;
				break;
			}
			return result;
		}

		public List<ItemsModel> getItemFromSlot(int slot)
		{
			List<ItemsModel> list = new List<ItemsModel>();
			for (int i = 0; i < this._inventory.Count; i++)
			{
				bool flag = this._inventory[i].slot == slot;
				if (flag)
				{
					list.Add(this._inventory[i]);
				}
			}
			return list;
		}

		public List<ItemsModel> getItemsAll()
		{
			return this._inventory;
		}

		public bool isItemInventoryExist(int player_id, int itemid)
		{
			ItemsModel[] array = this._inventory.ToArray();
			bool result;
			for (int i = 0; i < array.Length; i++)
			{
				ItemsModel itemsModel = array[i];
				bool flag = itemsModel.id == itemid;
				if (flag)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		public void setEquipItemFromSlot(int id, int slot)
		{
			switch (slot)
			{
			case 1:
				this._equep.PRIM = id;
				break;
			case 2:
				this._equep.SUB = id;
				break;
			case 3:
				this._equep.MELEE = id;
				break;
			case 4:
				this._equep.ITEM = id;
				break;
			case 5:
				this._equep.THROWING = id;
				break;
			case 6:
				this._equep.CHAR_RED = id;
				break;
			case 7:
				this._equep.CHAR_BLUE = id;
				break;
			case 8:
				this._equep.CHAR_HEAD = id;
				break;
			case 9:
				this._equep.CHAR_DINO = id;
				break;
			case 10:
				this._equep.CHAR_ITEM = id;
				break;
			}
		}
	}
}
