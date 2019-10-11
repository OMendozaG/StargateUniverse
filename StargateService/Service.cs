using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using NHttp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Titanium.Web.Proxy;
using Titanium.Web.Proxy.Models;

namespace StargateService {
	public partial class StargateUniverseService : ServiceBase {

		IniData ini;
		HttpServer http;
		int nextport = 5410;

		IDictionary<string, Dictionary<string, dynamic>> ProxiesConfig = new Dictionary<string, Dictionary<string, dynamic>>();
		IDictionary<string, ProxyServer> Proxies = new Dictionary<string, ProxyServer>();

		public StargateUniverseService() {
			InitializeComponent();
		}

		protected override void OnStart(string[] args) {
			FileIniDataParser parser = new FileIniDataParser();
			ini = parser.ReadFile(AppDomain.CurrentDomain.BaseDirectory + "config.ini", System.Text.Encoding.UTF8);


			http = new HttpServer();
			http.EndPoint = new IPEndPoint(IPAddress.Loopback, nextport);
			http.RequestReceived += HTTPRequest;
			http.Start();

			foreach (SectionData section in ini.Sections) {
				try {
					nextport++;
					string ip = section.SectionName;
					int port = nextport;
					if (ProxiesConfig.ContainsKey(ip)) { continue; }
				
					ProxyServer proxy = new ProxyServer();
					proxy.AddEndPoint(new ExplicitProxyEndPoint(IPAddress.Loopback, port, false));
					proxy.UpStreamEndPoint = new IPEndPoint(IPAddress.Parse(ip), 0);
					proxy.Start();


					Proxies.Add(ip, proxy);
					ProxiesConfig.Add(ip, new Dictionary<string, dynamic>());


					ProxiesConfig[ip].Add("ip", ip);
					ProxiesConfig[ip].Add("port", port);
					foreach (KeyData key in section.Keys) {
						if (ProxiesConfig[ip].ContainsKey(key.KeyName.ToLower())) { continue; }
						ProxiesConfig[ip].Add(key.KeyName.ToLower(), key.Value);
					}
					
				} catch {
				}

			}

		}

		public void onDebug() {
			OnStart(null);
		}

		protected override void OnStop() {
		}



		private void HTTPRequest(object sender, HttpRequestEventArgs e) {

			string response = "";
			string file = e.Request.Url.AbsolutePath.ToLower();

			file = (!file.StartsWith("/")) ? file : file.Substring(1);
			file = (!file.EndsWith("/")) ? file : file.Substring(0, file.Length - 1);



			if (file == "map") {
				List<IDictionary<string, dynamic>> list = new List<IDictionary<string, dynamic>>();

				foreach (KeyValuePair<string, Dictionary<string, dynamic>> proxyInfo in ProxiesConfig) {
					list.Add(proxyInfo.Value);
				}

				response = JsonConvert.SerializeObject(list);
			}



			/* TODO: que se pueda hacer una peticion utiulizando el name de la ip que se quiere o la ip. Y que se creeen chrometabs en el servicio con el chache del cliente
			//NOTA: esto será más complicado por que tendras que iniciar instancias de si mismo o del client idk
			if ((file == "rrequest") && (e.Request.QueryString.AllKeys.Contains("url"))) {
				string url = e.Request.QueryString["url"];
				string data = (!e.Request.QueryString.AllKeys.Contains("params")) ? "" : e.Request.QueryString["params"];

				//Helper.RunAndWait(async () => { await webview.Chromium.EvaluateScriptAsync("eval", new object[] { rrequestScript }); });
				//JavascriptResponse jsResponse = Helper.RunAndWaitReturn(async () => { return await webview.Chromium.EvaluateScriptAsync("rrequest", new object[] { url, data }); });

				//response = jsResponse.Result.ToString();
			} */



			//SYSTEM INFO
			if (file == "sysinfo") {
				string drives = "";
				if (e.Request.QueryString.AllKeys.Contains("drives")) {
					foreach (char drive in e.Request.QueryString["drives"].ToLower()) {
						drives += ((drives == "") ? "" : ",") + "\"" + drive.ToString() + "\":" +  SystemInfo.GetDiskUsagePercent(drive.ToString()).ToString(CultureInfo.InvariantCulture); 
					}
				}

				response = "{\"cpu\":" + SystemInfo.GetCPUUsagePercent().ToString(CultureInfo.InvariantCulture) + ",\"hd\":" +  SystemInfo.GetDiskUsagePercent("c").ToString(CultureInfo.InvariantCulture) + ",\"hds\":{" + drives + "},\"ram\":" +  SystemInfo.GetRamUsagePercent().ToString(CultureInfo.InvariantCulture) + "}";
			}



			using (var writer = new StreamWriter(e.Response.OutputStream)) { writer.Write((response != "") ? response : "Stargate Request Error"); }
		}

	}
}
