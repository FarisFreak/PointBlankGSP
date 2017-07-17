using PBServer.network.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using PBServer.src.model.rooms;
using System;

namespace PBServer.network.clientpacket
{
	internal class PROTOCOL_INVENTORY_LEAVE_REQ : ReceiveBaseGamePacket
	{
		private int[] _ids = new int[10];

		private int blue;

		private int dino;

		private int fifth;

		private int first;

		private int fourth;

		private int head;

		private int item;

		private int red;

		private int second;

		private int third;

		private int type;

		public PROTOCOL_INVENTORY_LEAVE_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			CLogger.getInstance().info("[Inventory] " + base.getClient().getPlayer().getPlayerName() + " out of inventory.");
			int num = (int)base.readH();
			this.type = base.readD();
			bool flag = this.type == 3;
			if (flag)
			{
				CLogger.getInstance().info("[Inventory] Saving weapons and characters");
				this.readEquipArmors();
				this.readEquipWeapons();
			}
			else
			{
				bool flag2 = this.type == 2;
				if (flag2)
				{
					CLogger.getInstance().info("[Inventory] Saving arms");
					this.readEquipWeapons();
				}
				else
				{
					bool flag3 = this.type == 1;
					if (flag3)
					{
						CLogger.getInstance().info("[Inventory] Saving characters");
						this.readEquipArmors();
					}
				}
			}
		}

		private void readEquipArmors()
		{
			this.red = base.readD();
			this.blue = base.readD();
			this.head = base.readD();
			this.dino = base.readD();
			this.item = base.readD();
			AccountManager.getInstance().UpdateCharItens(base.getClient().getPlayer().getPlayerId(), this.red, this.blue, this.head, this.dino, this.item);
			base.getClient().getPlayer().setCharRed(this.red);
			base.getClient().getPlayer().setCharBlue(this.blue);
			base.getClient().getPlayer().setCharHelmet(this.head);
			base.getClient().getPlayer().setCharDino(this.dino);
			base.getClient().getPlayer().setCharBeret(this.item);
			this._ids[5] = this.red;
			this._ids[6] = this.blue;
			this._ids[7] = this.head;
			this._ids[8] = this.dino;
			this._ids[9] = this.item;
		}

		private void readEquipWeapons()
		{
			this.first = base.readD();
			this.second = base.readD();
			this.third = base.readD();
			this.fourth = base.readD();
			this.fifth = base.readD();
			AccountManager.getInstance().UpdateWeaponItens(base.getClient().getPlayer().getPlayerId(), this.first, this.second, this.third, this.fourth, this.fifth);
			base.getClient().getPlayer().setPrimaryWeapon(this.first);
			base.getClient().getPlayer().setSecondaryWeapon(this.second);
			base.getClient().getPlayer().setMeleeWeapon(this.third);
			base.getClient().getPlayer().setThrownNormalWeapon(this.fourth);
			base.getClient().getPlayer().setThrownSpecialWeapon(this.fifth);
			this._ids[0] = this.first;
			this._ids[1] = this.second;
			this._ids[2] = this.third;
			this._ids[3] = this.fourth;
			this._ids[4] = this.fifth;
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				GameClient client = base.getClient();
				Account player = client.getPlayer();
				bool flag2 = this.type == 1;
				if (flag2)
				{
					for (int i = 0; i < 5; i++)
					{
						player.getInventory().setEquipItemFromSlot(this._ids[i], 6 + i);
					}
				}
				else
				{
					bool flag3 = this.type == 2;
					if (flag3)
					{
						for (int j = 0; j < 5; j++)
						{
							player.getInventory().setEquipItemFromSlot(this._ids[j], j);
						}
					}
					else
					{
						for (int j = 0; j < 10; j++)
						{
							player.getInventory().setEquipItemFromSlot(this._ids[j], j);
						}
					}
				}
				bool flag4 = client.getPlayer() != null && client.getPlayer().getRoom() != null;
				if (flag4)
				{
					player.getRoom().changeSlotState(player.getSlot(), SLOT_STATE.SLOT_STATE_NORMAL, true);
				}
				player.sendPacket(new PROTOCOL_INVENTORY_LEAVE_ACK(this.type));
			}
		}
	}
}
