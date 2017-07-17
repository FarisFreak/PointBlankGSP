using System;

namespace Model
{
	public class Equip
	{
		public int weapon_melee;

		public int weapon_primary;

		public int weapon_secondary;

		public int weapon_thrown_normal;

		public int weapon_thrown_special;

		public int char_beret;

		public int char_blue;

		public int char_dino;

		public int char_helmet;

		public int char_red;

		public int player_id = 0;

		public string name;

		public int getCharBeret()
		{
			return this.char_beret;
		}

		public int getCharBlue()
		{
			return this.char_blue;
		}

		public int getCharDino()
		{
			return this.char_dino;
		}

		public int getCharHelmet()
		{
			return this.char_helmet;
		}

		public int getCharRed()
		{
			return this.char_red;
		}

		public void setCharBeret(int beret)
		{
			this.char_beret = beret;
		}

		public void setCharBlue(int character_blue)
		{
			this.char_blue = character_blue;
		}

		public void setCharDino(int character_dino)
		{
			this.char_dino = character_dino;
		}

		public void setCharHelmet(int helmet)
		{
			this.char_helmet = helmet;
		}

		public void setCharRed(int character_red)
		{
			this.char_red = character_red;
		}

		public int getPrimaryWeapon()
		{
			return this.weapon_primary;
		}

		public int getSecondaryWeapon()
		{
			return this.weapon_secondary;
		}

		public int getMeleeWeapon()
		{
			return this.weapon_melee;
		}

		public int getThrownNormalWeapon()
		{
			return this.weapon_thrown_normal;
		}

		public int getThrownSpecialWeapon()
		{
			return this.weapon_thrown_special;
		}

		public void setMeleeWeapon(int melee)
		{
			this.weapon_melee = melee;
		}

		public void setPrimaryWeapon(int primary)
		{
			this.weapon_primary = primary;
		}

		public void setSecondaryWeapon(int secondary)
		{
			this.weapon_secondary = secondary;
		}

		public void setThrownNormalWeapon(int thrown_normal)
		{
			this.weapon_thrown_normal = thrown_normal;
		}

		public void setThrownSpecialWeapon(int thrown_special)
		{
			this.weapon_thrown_special = thrown_special;
		}
	}
}
