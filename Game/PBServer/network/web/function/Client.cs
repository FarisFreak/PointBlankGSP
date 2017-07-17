using PBServer.Properties;
using PBServer.src.managers;
using PBServer.src.model.accounts;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace PBServer.network.web.function
{
	public class Client
	{
		private string _footerS;

		private NetworkStream _networkStream;

		private TcpClient _tcpClient;

        public Client(TcpClient tcpClient)
        {
            this._footerS = "";
            this._tcpClient = tcpClient;
            this._networkStream = tcpClient.GetStream();
            string[] request = this.getRequest();
            this._footerS = Resources._footer;
            this._footerS = this._footerS.Replace("$version$", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            string text = request[0];
            switch (text)
            {
                case "/":
                    this.Send(tcpClient, "", File.ReadAllText(Directory.GetCurrentDirectory() + "//web//index.html"), "text/html");
                    break;
                case "/index.html":
                    this.Send(tcpClient, "", File.ReadAllText(Directory.GetCurrentDirectory() + "//web//index.html"), "text/html");
                    break;
                case "/admin":
                    {
                        bool flag = false;
                        if (request[3] != null)
                        {
                            flag = this.LoginCheck(request[3]);
                        }
                        if (flag)
                        {
                            string text2 = Resources._mainpage.Replace("$serverinfo$", "");
                            this.Send(tcpClient, "", Resources._head + Resources._body + text2 + this._footerS, "text/html");
                        }
                        else
                        {
                            this.Send(tcpClient, "", Resources._head + "<meta http-equiv='refresh' content='0; url=/admin/login'>", "text/html");
                        }
                        break;
                    }
                case "/admin/login":
                    this.Send(tcpClient, "", Resources._head + Resources._loginpage + this._footerS, "text/html");
                    break;
                case "/admin/auth":
                    {
                        Account account = AccountManager.getInstance().get(request[1]);
                        if (AccountManager.getInstance().dbstatus < 0)
                        {
                            string text2 = Resources._Message.Replace("$message$", "<center><b>Cannot Read DB.</b></center>");
                            this.Send(tcpClient, "", Resources._head + text2 + this._footerS, "text/html");
                        }
                        else if (account == null)
                        {
                            string text2 = Resources._Message.Replace("$message$", "<center><b>Fault Autorize.</b></center>");
                            this.Send(tcpClient, "", Resources._head + text2 + this._footerS, "text/html");
                        }
                        else if (!(account.password == request[2]))
                        {
                            this.Send(tcpClient, "", Resources._head + Resources._Message.Replace("$message$", "<center><b>Fault Autorize.</b></center>") + this._footerS, "text/html");
                        }
                        else
                        {
                            string text3 = Utilits.tokenGenerator();
                            AccountManager.getInstance().setCookie(text3, request[1]);
                            this.Send(tcpClient, "auth=" + text3, Resources._head + Resources._Message.Replace("$message$", "<b><center><center>Please Wait..</center>") + this._footerS, "text/html");
                        }
                        break;
                    }
                case "/admin/clients":
                    {
                        string clientpage = Resources._clientpage;
                        int num = AccountManager.getInstance().getOnlineAccounts().Count;
                        string str = num.ToString();
                        string text4 = "No Channel.";
                        string text5 = "No room.";
                        string text6 = "";
                        string text7 = "<tr><td>Player</td><td>Rank</td><td>EXP</td><td>GamePoint</td><td>Money</td><td>Channel</td><td>Room</td><td>State</td></tr>";
                        foreach (Account current in AccountManager.getInstance().getAccounts())
                        {
                            if (current.getClient() != null)
                            {
                                if (current.getClient().getChannelId() != -1)
                                {
                                    num = current.getClient().getChannelId();
                                    text4 = num.ToString();
                                }
                                if (current.getRoom() != null)
                                {
                                    num = current.getRoom().getRoomId();
                                    text5 = num.ToString();
                                    text6 = current.getRoom().getSlotState(current.getSlot()).ToString();
                                }
                                string text8 = text7;
                                string[] array = new string[18];
                                array[0] = text8;
                                array[1] = "<tr><td>";
                                array[2] = current.getPlayerName();
                                array[3] = "</td><td>";
                                string[] array2 = array;
                                int num2 = 4;
                                string[] arg_518_0 = array2;
                                int arg_518_1 = num2;
                                num = current.getRank();
                                arg_518_0[arg_518_1] = num.ToString();
                                array[5] = "</td><td>";
                                string[] array3 = array;
                                int num3 = 6;
                                string[] arg_53D_0 = array3;
                                int arg_53D_1 = num3;
                                num = current.getExp();
                                arg_53D_0[arg_53D_1] = num.ToString();
                                array[7] = "</td><td>";
                                string[] array4 = array;
                                int num4 = 8;
                                string[] arg_562_0 = array4;
                                int arg_562_1 = num4;
                                num = current.getGP();
                                arg_562_0[arg_562_1] = num.ToString();
                                array[9] = "</td><td>";
                                string[] array5 = array;
                                int num5 = 10;
                                string[] arg_589_0 = array5;
                                int arg_589_1 = num5;
                                num = current.getMoney();
                                arg_589_0[arg_589_1] = num.ToString();
                                array[11] = "</td><td>";
                                array[12] = text4;
                                array[13] = "</td><td>";
                                array[14] = text5;
                                array[15] = "</td><td>";
                                array[16] = text6;
                                array[17] = "</td></tr>";
                                text7 = string.Concat(array);
                            }
                        }
                        this.Send(tcpClient, "", Resources._head + Resources._body + clientpage.Replace("$table$", text7).Replace("$clients$", "Count Players online: " + str) + this._footerS, "text/html");
                        break;
                    }
                case "/admin/logout":
                    if (this.LoginCheck(request[3]))
                    {
                        this.ClearCookie(request[3]);
                    }
                    this.Send(tcpClient, "", Resources._head + Resources._Message.Replace("$message$", "Please Wait...") + this._footerS, "text/html");
                    break;
                case "/api/register":
                    this.Send(tcpClient, "", "<api><function>register</function><result>" + AccountManager.getInstance().CreateAccount(request[1], request[2]).ToString() + "</result></api>", "text/xml");
                    break;
                case "/Resources/bootstrap.js":
                    this.Send(tcpClient, "", Resources.bootstrap, "text/html");
                    break;
                case "/Resources/css/bootstrap_style.css":
                    this.Send(tcpClient, "", Resources.bootstrap_style, "text/html");
                    break;
                case "/Resources/jquery-latest.js":
                    this.Send(tcpClient, "", Resources.jquery_latest, "text/html");
                    break;
                case "/Resources/css/login_style.css":
                    this.Send(tcpClient, "", Resources.login_style, "text/html");
                    break;
                case "/Resources/css/head_style.css":
                    this.Send(tcpClient, "", Resources._head, "text/html");
                    break;
            }
        }


        public void ClearCookie(string value)
		{
			AccountManager.getInstance().deleteCookie(value);
		}

		~Client()
		{
		}

		public TcpClient getClient()
		{
			return this._tcpClient;
		}

		public string[] getRequest()
		{
			string text = "";
			byte[] array = new byte[4096];
			string[] array2 = new string[4096];
			int count;
			while ((count = this._networkStream.Read(array, 0, array.Length)) > 0)
			{
				text += Encoding.ASCII.GetString(array, 0, count);
				bool flag = text.IndexOf("\r\n\r\n") >= 0 || text.Length > 4096;
				if (flag)
				{
					break;
				}
			}
			Match match = Regex.Match(text, "^\\w+\\s+([^\\s\\?]+)[^\\s]*\\s+HTTP/.*|");
			bool flag2 = match == Match.Empty;
			string[] result;
			if (flag2)
			{
				array2[0] = "";
				result = array2;
			}
			else
			{
				array2[0] = match.Groups[1].Value;
				array2[0] = Uri.UnescapeDataString(array2[0]);
				string[] accInfo = Utilits.getAccInfo(text);
				string cookieAuth = Utilits.getCookieAuth(text);
				string loginWeb = Utilits.getLoginWeb(text);
				array2[1] = accInfo[0];
				array2[2] = accInfo[1];
				array2[3] = cookieAuth;
				array2[4] = loginWeb;
				string[] array3 = text.Split(new string[]
				{
					"players="
				}, StringSplitOptions.None);
				bool flag3 = array3.Length > 1;
				if (flag3)
				{
					string[] array4 = array3[1].Split(new string[]
					{
						"\r\n"
					}, StringSplitOptions.None)[0].Split(new string[]
					{
						"%0D%0A"
					}, StringSplitOptions.None);
					for (int i = 0; i < array4.Length; i++)
					{
						array2[6 + i] = array4[i];
					}
					array2[5] = array4.Length.ToString();
				}
				bool flag4 = array2[0].IndexOf("..") < 0;
				if (flag4)
				{
					CLogger.getInstance().info("GET " + array2[0]);
				}
				result = array2;
			}
			return result;
		}

		public bool LoginCheck(string cookes)
		{
			return AccountManager.getInstance().isCookie(cookes);
		}

		public void Send(TcpClient Client, string Cookes, string data, string type)
		{
			string text = "<html><body><meta charset='utf-8'>" + data + "</body></html>";
			byte[] bytes = Encoding.Default.GetBytes(string.Concat(new object[]
			{
				"HTTP/1.1 200 OK\nContent-type: ",
				type,
				"\nSet-Cookie: Cookies=INIT\nSet-Cookie:",
				Cookes,
				"\nContent-Length:",
				"\n\n",
				data
			}));
			Client.GetStream().Write(bytes, 0, bytes.Length);
			Client.Close();
		}

		private void SendError(TcpClient Client, int Code)
		{
			bool connected = this._tcpClient.Client.Connected;
			if (connected)
			{
				string arg_35_0 = Code.ToString();
				string arg_35_1 = " ";
				HttpStatusCode httpStatusCode = (HttpStatusCode)Code;
				string text = arg_35_0 + arg_35_1 + httpStatusCode.ToString();
				string text2 = "<html><body><h1>" + text + "</h1></body></html>";
				byte[] bytes = Encoding.ASCII.GetBytes(string.Concat(new string[]
				{
					"HTTP/1.1 ",
					text,
					"\nContent-type: text/html\nContent-Length:",
					text2.Length.ToString(),
					"\n\n",
					text2
				}));
				Client.GetStream().Write(bytes, 0, bytes.Length);
				Client.Close();
			}
		}
	}
}
