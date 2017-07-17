using PBServer;
using PBServer.src.managers;
using PointBlank_GSP.Data;
using System;
using System.Reflection;
using System.Diagnostics;
using System.Threading;

namespace PointBlank
{
	public class Program
	{
		public static void Main(string[] args)
		{
            Config.load();
			Console.Title = "PointBlank Server Auth";
			CLogger.getInstance().form();
			GlobalConsole.Load();
			GlobalTable.Load();
			GlobalDate.Load();
			GlobalNetwork.Load();
			while (true)
            {
                Thread.Sleep(200);
                Console.Write("> ");
                try
                {
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "stop":
                        case "close":
                        case "exit":
                            {
                                CLogger.getInstance().write(command);
                                CLogger.getInstance().red("END OF LOG");
                                Thread.Sleep(200);
                                Process.GetCurrentProcess().CloseMainWindow();
                                break;
                            }
                        case "reload shop":
                            {
                                CLogger.getInstance().write(command);
                                CLogger.getInstance().debug("[Reload] ShopManager");
                                ShopInfoManager.getInstance();
                                Console.ResetColor();
                                break;
                            }
                        case "clear":
                            {
                                Console.Clear();
                                break;
                            }
                        case "help":
                            {
                                CLogger.getInstance().write(command);
                                CLogger.getInstance().cyan("Help Command: ");
                                CLogger.getInstance().debug("* stop / close / exit - Close Server.");
                                CLogger.getInstance().debug("* reload shop         - Reload Shop.");
                                CLogger.getInstance().debug("* clear               - Clear Console");
                                CLogger.getInstance().debug("* restart             - Restart Server.");
                                Console.ResetColor();
                                break;
                            }
                        case "restart":
                            {
                                var location = Assembly.GetExecutingAssembly().Location;
                                Process.Start(location);
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                CLogger.getInstance().write(command);
                                CLogger.getInstance().warning("Invalid command!"); 
                                break;
                            }
                    }
                }
                catch
                {
                }
            }

			}
		}
	}
