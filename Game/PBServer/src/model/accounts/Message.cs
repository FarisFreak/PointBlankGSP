using System;

namespace PBServer.src.model.accounts
{
	public class Message
	{
		public int object_id;

		public int owner_id;

		public string recipient_name;

		public string text;

		public int getObjId()
		{
			return this.object_id;
		}

		public int getOwnId()
		{
			return this.owner_id;
		}

		public string getRecName()
		{
			return this.recipient_name;
		}

		public string getTxT()
		{
			return this.text;
		}
	}
}
