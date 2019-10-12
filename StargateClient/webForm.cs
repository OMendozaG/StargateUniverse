using CefSharp.WinForms;
using StargateClient.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Arya;
using Arya.Win;
using IniParser;
using IniParser.Model;
using System.Threading;

namespace StargateClient {
	public partial class WebForm : Form {

		string host;
		int port;
		string ip;
		string name;
		string account;
		string description;

		bool urlTextEditing = false;

		Arya.Win.WebView webview;
		CefSettings settings;

		public WebForm() {
			InitializeComponent();

			string[] args = Environment.GetCommandLineArgs();
			host =  Program.serverHost;
			Int32.TryParse(args[1], out port);
			ip = args[2];
			name = args[3];
			account = args[4];
			description = args[5];

			Text = name + ((name != "") ? " @ " : "") + ip;

			linkEmail.Text = account;


			settings = new CefSettings();
			settings.CefCommandLineArgs.Add("proxy-server", host + ":" + port);
			settings.CefCommandLineArgs.Add("disable-web-security", "1");
			settings.CachePath = "cache/" + ip + "/session/";
			settings.UserDataPath = "cache/" + ip + "/data/";

			settings.IgnoreCertificateErrors = true;
			settings.PersistSessionCookies = true;
			settings.PersistUserPreferences = true;
	
			webview = new Arya.Win.WebView(settings);
			webview.OuterScroll = false;
			webview.HideWhileLoading = false;
			webview.UseLoadingView = false;
			webview.Dock = DockStyle.Fill;
			panelWebview.Controls.Add(webview);

			webview.Driver.OnUrlChanged = OnURLChanged;

			try {
				IniData ini = new FileIniDataParser().ReadFile("client.ini");

				foreach (KeyData data in ini.Sections["favorites"]) {

					Button button = new Button() {
						AutoSize = true,
						Text = data.KeyName,
						Tag = data.Value,
					};
					button.Click += LinkButtonClick;

					panelLinks.Controls.Add(button);
				}
			} catch { }
		}

		private void LinkButtonClick(object sender, EventArgs e) {
			webview.Driver.Navigate(((Button)sender).Tag.ToString());
		}

		public void OnURLChanged(string url) {
			if (urlTextEditing) { return; }
			
			A.Helper.RunOnMainThread(this, () => {
				textUrl.Text = webview.Driver.url;
			});
		}

		private void TextUrl_Enter(object sender, EventArgs e) {
			urlTextEditing = true;
		}

		private void TextUrl_Leave(object sender, EventArgs e) {
			urlTextEditing = false;
			textUrl.Text = webview.Driver.url;
		}

		private void TextUrl_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				webview.Driver.Navigate(textUrl.Text);
				urlTextEditing = false;
				webview.chromium.Focus();
			}
		}

		private void ButtonHome_Click(object sender, EventArgs e) {
			webview.Driver.Navigate("https://google.com");
		}

		private void WebForm_Load(object sender, EventArgs e) {

		}

		private void WebForm_Shown(object sender, EventArgs e) {
			Rectangle resolution = Screen.PrimaryScreen.Bounds;
			this.Size =  new Size((int)(resolution.Width * 90 / 100), (int)((resolution.Height - 40) * 90 / 100));
			this.CenterToScreen();
			this.BringToFront();

			webview.Driver.Navigate("about:blank");
			A.Helper.RunOnThread(() => {
				Thread.Sleep(500);
				webview.Driver.Navigate("https://google.com");
			});
		}

		private void ButtonForward_Click(object sender, EventArgs e) {
			webview.Driver.GoForward();
		}

		private void ButtonBack_Click(object sender, EventArgs e) {
			webview.Driver.GoBack();
		}

		private void ButtonRefresh_Click(object sender, EventArgs e) {
			webview.Driver.Reload();
		}

		private void LinkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			Clipboard.SetText(linkEmail.Text);
		}
	}
}
