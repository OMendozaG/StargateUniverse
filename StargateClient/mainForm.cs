using Arya;
using Arya.Win;
using CefSharp;
using Newtonsoft.Json;
using StargateClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StargateClient {
	public partial class MainForm : Form {

		HttpClient http = new HttpClient(new HttpClientHandler());

		IDictionary<string, Dictionary<string, dynamic>> ProxiesConfig = new Dictionary<string, Dictionary<string, dynamic>>();
		List<Process> Processes = new List<Process>();


		public MainForm() {
			InitializeComponent();

			serverTooStrip.Text = Program.serverHost + ":5410";
			UpdateMap();
		}

		private void UpdateMap() {
			this.Text = "Stargate Universe (Connecting to " +  Program.serverHost + ":5410...)";

			A.Helper.RunOnThread(() => {
				string response = A.Helper.RunOnAwaitedTask(async () => {
					try {
						HttpResponseMessage httpResponse;
						httpResponse = await http.GetAsync("http://" +  Program.serverHost + ":5410/map");
						return (!httpResponse.IsSuccessStatusCode) ? "" : await httpResponse.Content.ReadAsStringAsync();
					} catch { return ""; }
				});


				A.Helper.RunOnMainThread(this, () => {
					mapView.Items.Clear();

					if ((response == "") || (!response.StartsWith("["))) { this.Text = "Stargate Universe (Error connecting " +  Program.serverHost + ":5410)"; return; }
					this.Text = "Stargate Universe @ " +  Program.serverHost + ":5410";

					List<IDictionary<string, dynamic>> list = JsonConvert.DeserializeObject<List<IDictionary<string, dynamic>>>(response);

					foreach (IDictionary<string, dynamic> proxyConfig in list) { try {
							ListViewItem item = new ListViewItem();
							item.Text = proxyConfig["port"].ToString();
							item.SubItems.Add(proxyConfig["ip"]);
							item.SubItems.Add((proxyConfig.ContainsKey("name")) ? proxyConfig["name"] : "");
							item.SubItems.Add((proxyConfig.ContainsKey("account")) ? proxyConfig["account"] : "");
							item.SubItems.Add((proxyConfig.ContainsKey("description")) ? proxyConfig["description"] : "");
							mapView.Items.Add(item);

							if (!ProxiesConfig.ContainsKey(proxyConfig["ip"])) { proxyConfig.Add(proxyConfig["ip"], proxyConfig); }
							ProxiesConfig[proxyConfig["ip"]] = proxyConfig;

					} catch { } }

				});
			});
		}



		private void FormRestoreClick(object sender, EventArgs e) {
			UpdateMap();

			WindowState = FormWindowState.Normal;
			Show();
			CenterToScreen();
			BringToFront();
		}

		private void FormExitClick(object sender, EventArgs e) {
			ExitProcess();

			Process.GetCurrentProcess().Kill();
		}

		private void KillProcess(string name) {
			Process process = new System.Diagnostics.Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.FileName = "taskkill.exe";
			process.StartInfo.Arguments = "/F /IM " + name;
			process.Start();
		}

		private void ExitProcess() {
			try { Cef.Shutdown(); } catch { }
			foreach (Process process in Processes) {
				try { process.Kill(); } catch { }
			}
			KillProcess("CefSharp.BrowserSubprocess.exe");
			KillProcess(System.AppDomain.CurrentDomain.FriendlyName);
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			#if DEBUG
				FormExitClick(sender, e);
			#endif

			Hide();
			e.Cancel = true;
		}

		private void MainForm_Shown(object sender, EventArgs e) {
			CenterToScreen();
		}

		private void MapView_DoubleClick(object sender, EventArgs e) {
			if (mapView.SelectedItems.Count != 1) { return; }

			Process process = new Process();
			process.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
			process.StartInfo.Arguments = "\"" + mapView.SelectedItems[0].SubItems[0].Text  + "\"" + " \"" + mapView.SelectedItems[0].SubItems[1].Text + "\"" + " \"" + mapView.SelectedItems[0].SubItems[2].Text + "\"" + " \"" + mapView.SelectedItems[0].SubItems[3].Text + "\"" + " \"" + mapView.SelectedItems[0].SubItems[4].Text + "\"";
			process.Start();

			Processes.Add(process);
		}

	}
}
