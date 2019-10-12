using Arya;
using Arya.Win;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StargateClient {
	static class Program {

		static public string serverHost = "localhost";

		[STAThread]
		static void Main() {

			try {
				IniData ini = new FileIniDataParser().ReadFile("client.ini");
				if ((ini.Sections.ContainsSection("server")) && (ini["server"].ContainsKey("host"))) {
					serverHost = ini["server"]["host"];
				}
			} catch { }

			AppDomain.CurrentDomain.AssemblyResolve += A.Helper.CEFAssemblyResolver;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string[] args = Environment.GetCommandLineArgs();

			if (args.Length <= 1) {
				using (Mutex mutex = new Mutex(false, "Global\\StargateUniverseClientMain")) {
					if (!mutex.WaitOne(0, false)) {
						Process.GetCurrentProcess().Kill();
						return;
					}

					Application.Run(new MainForm());
				}
			} else {
				Application.Run(new WebForm());
			}
		}


	}
}
