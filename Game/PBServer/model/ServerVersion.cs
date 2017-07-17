using System;
using System.Reflection;

namespace PBServer.model
{
	public static class ServerVersion
	{
		public static string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
	}
}
