using PBServer.network.Game.packets.serverpackets;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;

namespace PBServer.network.Game.packets.clientpackets
{
	public class PROTOCOL_MESSENGER_NOTE_SEND_REQ : ReceiveBaseGamePacket
	{
		private string name;

		private int name_lenght;

		private string text;

		private int text_lenght;

		public PROTOCOL_MESSENGER_NOTE_SEND_REQ(GameClient Client, byte[] data)
		{
			base.makeme(Client, data);
		}

		protected internal override void read()
		{
			base.readH();
			this.name_lenght = (int)base.readC();
			this.text_lenght = (int)base.readC();
			this.name = base.readS(this.name_lenght);
			this.text = base.readS(this.text_lenght);
			CLogger.getInstance().info("[Addressee] " + this.name);
			CLogger.getInstance().info("[Message] " + this.text);
		}

		protected internal override void run()
		{
			bool flag = base.getClient() != null;
			if (flag)
			{
				Account player = base.getClient().getPlayer();
				bool flag2 = AccountManager.getInstance().getAccountInName(this.name) != null;
				if (flag2)
				{
					Random random = new Random();
					Message message = new Message
					{
						object_id = MessageManager.getInstance().getMessages().Count + 1,
						owner_id = AccountManager.getInstance().getAccountInName(this.name).getPlayerId(),
						recipient_name = player.getPlayerName(),
						text = this.text
					};
					MessageManager.getInstance().AddMessage(message);
					MessageManager.getInstance().createMessageInDb(player.getPlayerName(), AccountManager.getInstance().getAccountInName(this.name).getPlayerId(), message.getObjId(), this.text);
					base.getClient().sendPacket(new PROTOCOL_MESSENGER_NOTE_SEND_ACK(0));
					AccountManager.getInstance().getAccountInName(this.name).sendPacket(new PROTOCOL_MESSENGER_NOTE_RECEIVE_ACK(player.getPlayerName(), this.text));
				}
				else
				{
					base.getClient().sendPacket(new PROTOCOL_MESSENGER_NOTE_SEND_ACK(2147483647));
				}
			}
		}
	}
}
