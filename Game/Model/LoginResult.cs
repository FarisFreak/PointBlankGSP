using System;

namespace Model
{
	internal enum LoginResult
	{
		LOGIN_OK,
		INVALID_ACCOUNT = -2147483390,
		INVALID_ID = -2147483369,
		INVALID_PASSWORD,
		LOGOUTING = -2147483388,
		DB_BUFFER_FULL = -2147483372,
		DELETE_ACCOUNT = -2147483367,
		EMAIL_AUTH_ERROR = -2147483360,
		BLOCK_IP,
		BLOCK_COUNTRY = -2147483357,
		ALREADY_LOGIN_WEB_E = -2147483391,
		TIME_OUT_1 = -2147483387,
		TIME_OUT_2,
		BLOCK_ACCOUNT
	}
}
