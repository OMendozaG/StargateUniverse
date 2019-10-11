using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StargateService {
	static class Program {

		static bool IsElevated => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

		static void Main() {

			string[] args = Environment.GetCommandLineArgs();
			if ((args.Length >= 2) && (args[1].ToLower() == "/install")) {

				if (!IsElevated) {
					MessageBox.Show("Run with administrator privileges to install service!", "Service Not Installed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Process.GetCurrentProcess().Kill();
					return;
				}
				
				Process process = new System.Diagnostics.Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "sc.exe";
				process.StartInfo.Arguments = "CREATE \"StargateUniverseService\" type=interact type=own binPath=\"" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + "\" start=auto DisplayName=\"Stargate Universe Service\"";
				process.Start();

				MessageBox.Show("Service Installed", "Installed!",  MessageBoxButtons.OK, MessageBoxIcon.Information);

				Process.GetCurrentProcess().Kill();
				return;
			}

			if ((args.Length >= 2) && (args[1].ToLower() == "/uninstall")) {

				if (!IsElevated) {
					MessageBox.Show("Run with administrator privileges to uninstall service!", "Service Not Uninstalled", MessageBoxButtons.OK, MessageBoxIcon.Error);
					Process.GetCurrentProcess().Kill();
					return;
				}
				
				Process process = new System.Diagnostics.Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "sc.exe";
				process.StartInfo.Arguments = "DELETE \"StargateUniverseService\"";
				process.Start();

				MessageBox.Show("Service Uninstalled", "Uninstalled!",  MessageBoxButtons.OK, MessageBoxIcon.Information);

				Process processkill = new System.Diagnostics.Process();
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				process.StartInfo.FileName = "taskkill.exe";
				process.StartInfo.Arguments = "/F /IM " + System.AppDomain.CurrentDomain.FriendlyName;
				process.Start();

				Process.GetCurrentProcess().Kill();
				return;
			}
			/*
			#if DEBUG
			if (System.Diagnostics.Debugger.IsAttached) {
				StargateUniverseService myService = new StargateUniverseService();
				myService.onDebug();
				System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
			}
			#endif
			*/

			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] {
				new StargateUniverseService()
			};


			ServiceBase.Run(ServicesToRun);
		}

	}
}
