using System;

namespace Model
{
	public enum UpdState
	{
		SERVER_UDP_STATE_NONE,
		SERVER_UDP_STATE_RENDEZVOUS,
		SERVER_UDP_STATE_CLIENT,
		SERVER_UDP_STATE_RELAY,
		SERVER_UDP_STATE_RELAYCLIENT = 1
	}
}
