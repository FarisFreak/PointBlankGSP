using System;

namespace PBServer.model.clans
{
	public class Clan
	{
		public int _color = 0;

		public int _logo1 = 255;

		public int _logo2 = 255;

		public string clan_news = "";

		public int _logo3 = 255;

		public int _logo4 = 255;

		public int clan_id = 0;

		public string clan_info = "";

		public string clan_name = "";

		public int clan_rank = 0;

		public int dateCreated = 0;

		public int role = 3;

		public int owner_id = 0;

		public int getClanId()
		{
			return this.clan_id;
		}

		public int getMemberRole()
		{
			return this.role;
		}

		public string getClanInfo()
		{
			return this.clan_info;
		}

		public string getClanNews()
		{
			return this.clan_news;
		}

		public string getClanName()
		{
			return this.clan_name;
		}

		public int getClanRank()
		{
			return this.clan_rank;
		}

		public int getDateCreated()
		{
			return this.dateCreated;
		}

		public int getLogo1()
		{
			return this._logo1;
		}

		public int getLogo2()
		{
			return this._logo2;
		}

		public int getLogo3()
		{
			return this._logo3;
		}

		public int getLogo4()
		{
			return this._logo4;
		}

		public int getLogoColor()
		{
			return this._color;
		}

		public int getOwnerId()
		{
			return this.owner_id;
		}

		public void setClanId(int id)
		{
			this.clan_id = id;
		}

		public void setClanName(string name)
		{
			this.clan_name = name;
		}

		public void setClanRank(int rank)
		{
			this.clan_rank = rank;
		}

		public void setDateCreated(int date)
		{
			this.dateCreated = date;
		}

		public void setLogo1(int logo)
		{
			this._logo1 = logo;
		}

		public void setLogo2(int logo)
		{
			this._logo2 = logo;
		}

		public void setLogo3(int logo)
		{
			this._logo3 = logo;
		}

		public void setLogo4(int logo)
		{
			this._logo4 = logo;
		}

		public void setLogoColor(int color)
		{
			this._color = color;
		}

		public void setOwnerId(int id)
		{
			this.owner_id = id;
		}

		public object[] toObject()
		{
			return new object[]
			{
				this.getClanName(),
				this.getClanRank(),
				this.getOwnerId(),
				this.getLogoColor(),
				this.getLogo1(),
				this.getLogo2(),
				this.getLogo3(),
				this.getLogo4()
			};
		}

		public string toString()
		{
			return string.Concat(new object[]
			{
				"Clan{id=",
				this.clan_id,
				", name='",
				this.clan_name,
				'\'',
				", rank=",
				this.clan_rank,
				", ownerId=",
				this.owner_id,
				", dateCreated=",
				this.dateCreated,
				", color=",
				this._color,
				", logo1=",
				this._logo1,
				", logo2=",
				this._logo2,
				", logo3=",
				this._logo3,
				", logo4=",
				this._logo4,
				'}'
			});
		}
	}
}
