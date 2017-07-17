using System;

namespace PBServer.src.model.accounts
{
	public class ConfigP
	{
		public int audio_enable = 7;

		public int audio1 = 100;

		public int audio2 = 100;

		public int config = 55;

		public int mao = 0;

		public int mira = 1;

		public int ownerid = 0;

		public string ownername = "";

		public int sangue = 1;

		public int sensibilidade = 50;

		public int visao = 70;

		public int getAudio1()
		{
			return this.audio1;
		}

		public int getAudio2()
		{
			return this.audio2;
		}

		public int getAudioEnable()
		{
			return this.audio_enable;
		}

		public int getConfig()
		{
			return this.config;
		}

		public int getMao()
		{
			return this.mao;
		}

		public int getMira()
		{
			return this.mira;
		}

		public int getOwnerId()
		{
			return this.ownerid;
		}

		public string getOwnerName()
		{
			return this.ownername;
		}

		public int getSangue()
		{
			return this.sangue;
		}

		public int getSensibilidade()
		{
			return this.sensibilidade;
		}

		public int getVisao()
		{
			return this.visao;
		}

		public void setAudio1(int primary)
		{
			this.audio1 = primary;
		}

		public void setAudio2(int primary)
		{
			this.audio2 = primary;
		}

		public void setAudioEnable(int primary)
		{
			this.audio_enable = primary;
		}

		public void setMao(int primary)
		{
			this.mao = primary;
		}

		public void setMira(int primary)
		{
			this.mira = primary;
		}

		public void setOwnerId(int primary)
		{
			this.ownerid = primary;
		}

		public void setOwnerName(string primary)
		{
			this.ownername = primary;
		}

		public void setSangue(int primary)
		{
			this.sangue = primary;
		}

		public void setSensibilidade(int primary)
		{
			this.sensibilidade = primary;
		}

		public void setVisao(int primary)
		{
			this.visao = primary;
		}
	}
}
