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

					int index = 0;
					while (menuTray.Items.ContainsKey("proxyOpen" + index.ToString())) {
						menuTray.Items.RemoveByKey("proxyOpen" + index.ToString());
						index++;
					}


					if ((response == "") || (!response.StartsWith("["))) { this.Text = "Stargate Universe (Error connecting " +  Program.serverHost + ":5410)"; return; }
					this.Text = "Stargate Universe @ " +  Program.serverHost + ":5410";

					List<IDictionary<string, dynamic>> list = JsonConvert.DeserializeObject<List<IDictionary<string, dynamic>>>(response);

					foreach (IDictionary<string, dynamic> proxyConfig in list) { try {
						ListViewItem item = new ListViewItem();
						item.Text = Program.serverHost;
						item.SubItems.Add(proxyConfig["port"].ToString());
						item.SubItems.Add(proxyConfig["ip"]);
						item.SubItems.Add((proxyConfig.ContainsKey("name")) ? proxyConfig["name"] : "");
						item.SubItems.Add((proxyConfig.ContainsKey("description")) ? proxyConfig["description"] : "");
						item.SubItems.Add((proxyConfig.ContainsKey("account")) ? proxyConfig["account"] : "");
						mapView.Items.Add(item);

						ToolStripMenuItem toolItem = new ToolStripMenuItem();
						toolItem.Name = "proxyOpen" + (mapView.Items.Count - 1).ToString();
						toolItem.Tag = mapView.Items.Count -1;
						toolItem.Text = ((proxyConfig.ContainsKey("name")) ? proxyConfig["name"] : proxyConfig["ip"]) + ((proxyConfig.ContainsKey("description")) ? " (" + proxyConfig["description"] + ")" : "");
						toolItem.Click += ToolProxi_Open;

						menuTray.Items.Insert(menuTray.Items.Count - 2, toolItem);

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

			RunProxiByMapId(mapView.SelectedItems[0].Index);
		}


		private void ToolProxi_Open(object sender, EventArgs e) {
			RunProxiByMapId((int)((ToolStripMenuItem)sender).Tag);
		}

		private void RunProxiByMapId(int index) {
			Process process = new Process();
			process.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
			process.StartInfo.Arguments = "\"" + mapView.Items[index].SubItems[0].Text  + "\"" + " \"" + mapView.Items[index].SubItems[1].Text + "\" \"" + mapView.Items[index].SubItems[2].Text + "\"" + " \"" + mapView.Items[index].SubItems[3].Text + "\"" + " \"" + mapView.Items[index].SubItems[4].Text + "\"" + " \"" + mapView.Items[index].SubItems[5].Text + "\"";
			process.Start();

			Processes.Add(process);
		}

	}
}
