using PBServer.network.web.function;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace PBServer.network.web
{
	public class webserver
	{
		private Client _client;

		private static webserver _instance;

		private TcpClient _tcpClient;

		private TcpListener _tcpListener;

		public webserver()
		{
			bool flag = !Directory.Exists("web");
			if (flag)
			{
				Directory.CreateDirectory("web");
			}
			bool flag2 = !File.Exists("web/index.html");
			if (flag2)
			{
				File.AppendAllText("web/index.html", "<legend><center>Welcome to Hell!<center></legend><br>=)");
			}
			bool flag3 = !File.Exists("web/ReadMe.txt");
			if (flag3)
			{
				File.AppendAllText("web/ReadMe.txt", "Здесь могут быть размещены дополнительные файлы, сервер не поддерживает php, может служить только для закачки файлов, плохо работает многопоточность. Вебадминку можете не искать она зашита в exe файл. Если вы удалите этот файл, то он будет создан после перезапуска сервера. Так же если хотите зайти в вебадминку то хост http://localhost:3321/, Логин: admin, Пароль: admin. С уважением PBDev Team & MMo-Network.");
			}
			new Thread(new ThreadStart(this.InitWebServer)).Start();
		}

		public static webserver getInstance()
		{
			bool flag = webserver._instance == null;
			if (flag)
			{
				webserver._instance = new webserver();
			}
			return webserver._instance;
		}

		public void InitWebServer()
		{
			IPAddress iPAddress = IPAddress.Parse(Config.WebServerHost.ToString());
			CLogger.getInstance().info("|[WEB]| Carregando...");
			this._tcpListener = new TcpListener(IPAddress.Any, 3321);
			this._tcpListener.Start();
			while (true)
			{
				this._tcpClient = this._tcpListener.AcceptTcpClient();
				this._client = new Client(this._tcpClient);
			}
		}
	}
}
