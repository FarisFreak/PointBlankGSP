using PBServer;
using System;
using System.Net;
using System.Net.Sockets;

namespace BattleServer
{
	public class GSHandler
	{
		private UdpClient _client;

		public GSHandler(UdpClient client)
		{
			this._client = client;
			this._client.BeginReceive(new AsyncCallback(this.BeginStaticReceive), null);
		}

		public void BeginStaticReceive(IAsyncResult result)
		{
			IPEndPoint iPEndPoint = null;
			byte[] array = this._client.EndReceive(result, ref iPEndPoint);
			short num = BitConverter.ToInt16(array, 0);
			short num2 = num;
			if (num2 != 1)
			{
				if (num2 != 255)
				{
					CLogger.getInstance().extra_info("Opcode: " + num.ToString());
				}
			}
			else
			{
				byte b = array[2];
				CLogger.getInstance().info("[System] Creating a room");
				CLogger.getInstance().info("[System] Add Player");
				Room room = new Room
				{
					id = Program.getRoomManager().getRooms().Count
				};
				for (int i = 0; i < (int)b; i++)
				{
					Player player = new Player();
					byte b2 = array[3];
					byte[] address = new byte[4];
					address = new byte[]
					{
						array[4 + i * 6],
						array[5 + i * 6],
						array[6 + i * 6],
						array[7 + i * 6]
					};
					player.slot = (int)array[4 + i * 5];
					IPAddress address2 = new IPAddress(address);
					player._address = address2;
					room.getPlayers().Add(player);
				}
				room.type = (int)array[(int)(3 + b * 6)];
				Program.getRoomManager().getRooms().Add(room);
				CLogger.getInstance().info("Room type = " + room.type.ToString());
				CLogger.getInstance().extra_info("[System] Create Room <<<");
			}
		}
	}
}
