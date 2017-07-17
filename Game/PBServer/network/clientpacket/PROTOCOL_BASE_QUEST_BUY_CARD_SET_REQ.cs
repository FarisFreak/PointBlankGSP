using PBServer.network.serverpacket;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.clientpacket
{
	public class PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ : ReceiveBaseGamePacket
	{
		private int missionId;

		public PROTOCOL_BASE_QUEST_BUY_CARD_SET_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.missionId = (int)base.readC();
			CLogger.getInstance().info("[Quest] " + this.missionId);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				player.mission_id = this.missionId;
				AccountManager.getInstance().UpdateMission(player.getPlayerId(), player.getMissionId(), 0);
				switch (this.missionId)
				{
				case 0:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão tutorial.");
					break;
				case 1:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão tutorial.");
					break;
				case 2:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão tutorial dos dinossauros.");
					break;
				case 3:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão tutorial dos sobreviventes.");
					break;
				case 5:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de assalto.");
					player.setGP(player.getGP() - 5000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 6:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de apoio.");
					player.setGP(player.getGP() - 5000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 7:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de invasão.");
					player.setGP(player.getGP() - 5000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 8:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de defesa.");
					player.setGP(player.getGP() - 5400);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 9:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de explosão.");
					player.setGP(player.getGP() - 5800);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 10:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de supressão.");
					player.setGP(player.getGP() - 8300);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 11:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão de forças especiais.");
					player.setGP(player.getGP() - 11000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 12:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão total.");
					break;
				case 14:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão dinossauro.");
					player.setGP(player.getGP() - 5500);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 15:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão sobreviventes.");
					player.setGP(player.getGP() - 5000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 16:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão dinossauro nível 2.");
					player.setGP(player.getGP() - 9500);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				case 17:
					CLogger.getInstance().info("O jogador " + player.getPlayerName() + " comprou o cartão de missão sobrevivente nível 2.");
					player.setGP(player.getGP() - 9000);
					AccountManager.getInstance().UpdateMGP(player.getPlayerId(), player.getGP(), player.getMoney());
					break;
				}
				player.sendPacket(new PROTOCOL_BASE_QUEST_BUY_CARD_SET_ACK(this.missionId, player));
			}
		}
	}
}
