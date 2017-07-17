using PBServer.src.managers;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_SETTINGS_SAVE_REQ : ReceiveBaseGamePacket
	{
		private int audio_enable;

		private int blood;

		private int config;

		private int mao;

		private int mira;

		private int music;

		private int sensibilidade;

		private int sound;

		private int visao;

		public PROTOCOL_SETTINGS_SAVE_REQ(GameClient gc, byte[] buff)
		{
			base.makeme(gc, buff);
		}

		protected internal override void read()
		{
			base.readB(6);
			this.blood = (int)base.readC();
			base.readC();
			this.mira = (int)base.readC();
			this.mao = (int)base.readC();
			this.config = (int)base.readC();
			base.readB(3);
			this.audio_enable = (int)base.readC();
			base.readB(5);
			this.sound = (int)base.readC();
			this.music = (int)base.readC();
			this.visao = (int)base.readC();
			base.readC();
			this.sensibilidade = (int)base.readC();
		}

		protected internal override void run()
		{
			CLogger.getInstance().info("[Sound]: " + this.sound);
			CLogger.getInstance().info("[Music]: " + this.music);
			CLogger.getInstance().info("[Audio]: " + this.audio_enable);
			CLogger.getInstance().info("[Config]: " + this.config);
			CLogger.getInstance().info("[Mao]: " + this.mao);
			CLogger.getInstance().info("[Blood]: " + this.blood);
			CLogger.getInstance().info("[Visibility]: " + this.mira);
			CLogger.getInstance().info("[MouseSensitivity]: " + this.sensibilidade);
			CLogger.getInstance().info("[Vision]: " + this.visao);
			CLogger.getInstance().info("[Sound]: " + this.sound);
			ConfigManager.getInstance().UpdateConfig(base.getClient().getPlayerId(), this.sound, this.music, this.mira, this.sensibilidade, this.visao, this.blood, this.mao, this.audio_enable, this.config);
			CLogger.getInstance().debug("[Config] " + base.getClient().getPlayer().getPlayerName() + " have been successfully saved.");
		}
	}
}
