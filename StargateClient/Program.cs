using Arya;
using Arya.Win;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
				Application.Run(new MainForm());
			} else {
				Application.Run(new WebForm());
			}
		}


	}
}
