using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace PBServer.Properties
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		private static CultureInfo resourceCulture;

		private static ResourceManager resourceMan;

		internal static string _body
		{
			get
			{
				return Resources.ResourceManager.GetString("_body", Resources.resourceCulture);
			}
		}

		internal static string _clientpage
		{
			get
			{
				return Resources.ResourceManager.GetString("_clientpage", Resources.resourceCulture);
			}
		}

		internal static string _configpage
		{
			get
			{
				return Resources.ResourceManager.GetString("_configpage", Resources.resourceCulture);
			}
		}

		internal static string _footer
		{
			get
			{
				return Resources.ResourceManager.GetString("_footer", Resources.resourceCulture);
			}
		}

		internal static string _head
		{
			get
			{
				return Resources.ResourceManager.GetString("_head", Resources.resourceCulture);
			}
		}

		internal static string _loginpage
		{
			get
			{
				return Resources.ResourceManager.GetString("_loginpage", Resources.resourceCulture);
			}
		}

		internal static string _mainpage
		{
			get
			{
				return Resources.ResourceManager.GetString("_mainpage", Resources.resourceCulture);
			}
		}

		internal static string _Message
		{
			get
			{
				return Resources.ResourceManager.GetString("_Message", Resources.resourceCulture);
			}
		}

		internal static string _uploadpage
		{
			get
			{
				return Resources.ResourceManager.GetString("_uploadpage", Resources.resourceCulture);
			}
		}

		internal static string blocklist
		{
			get
			{
				return Resources.ResourceManager.GetString("blocklist", Resources.resourceCulture);
			}
		}

		internal static string blockplayers
		{
			get
			{
				return Resources.ResourceManager.GetString("blockplayers", Resources.resourceCulture);
			}
		}

		internal static string bootstrap
		{
			get
			{
				return Resources.ResourceManager.GetString("bootstrap", Resources.resourceCulture);
			}
		}

		internal static string bootstrap_style
		{
			get
			{
				return Resources.ResourceManager.GetString("bootstrap_style", Resources.resourceCulture);
			}
		}

		internal static string cooklist
		{
			get
			{
				return Resources.ResourceManager.GetString("cooklist", Resources.resourceCulture);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		internal static string jquery_latest
		{
			get
			{
				return Resources.ResourceManager.GetString("jquery_latest", Resources.resourceCulture);
			}
		}

		internal static string login
		{
			get
			{
				return Resources.ResourceManager.GetString("login", Resources.resourceCulture);
			}
		}

		internal static string login_style
		{
			get
			{
				return Resources.ResourceManager.GetString("login_style", Resources.resourceCulture);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					Resources.resourceMan = new ResourceManager("PBServer.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		internal static byte[] StartInventory
		{
			get
			{
				return (byte[])Resources.ResourceManager.GetObject("StartInventory", Resources.resourceCulture);
			}
		}

		internal Resources()
		{
		}
	}
}
