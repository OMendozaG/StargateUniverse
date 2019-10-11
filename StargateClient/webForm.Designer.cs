namespace StargateClient {
	partial class WebForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebForm));
			this.panelNavigation = new System.Windows.Forms.Panel();
			this.linkEmail = new System.Windows.Forms.LinkLabel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonHome = new System.Windows.Forms.Button();
			this.buttonForward = new System.Windows.Forms.Button();
			this.buttonBack = new System.Windows.Forms.Button();
			this.textUrl = new System.Windows.Forms.TextBox();
			this.panelLinks = new System.Windows.Forms.FlowLayoutPanel();
			this.panelWebview = new System.Windows.Forms.Panel();
			this.panelNavigation.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelNavigation
			// 
			this.panelNavigation.BackColor = System.Drawing.SystemColors.Window;
			this.panelNavigation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelNavigation.Controls.Add(this.linkEmail);
			this.panelNavigation.Controls.Add(this.panel3);
			this.panelNavigation.Controls.Add(this.textUrl);
			this.panelNavigation.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelNavigation.Location = new System.Drawing.Point(0, 0);
			this.panelNavigation.Name = "panelNavigation";
			this.panelNavigation.Size = new System.Drawing.Size(556, 32);
			this.panelNavigation.TabIndex = 10;
			// 
			// linkEmail
			// 
			this.linkEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.linkEmail.Cursor = System.Windows.Forms.Cursors.Hand;
			this.linkEmail.Location = new System.Drawing.Point(398, 0);
			this.linkEmail.Name = "linkEmail";
			this.linkEmail.Size = new System.Drawing.Size(155, 30);
			this.linkEmail.TabIndex = 0;
			this.linkEmail.TabStop = true;
			this.linkEmail.Text = "Email";
			this.linkEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkEmail_LinkClicked);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.Menu;
			this.panel3.Controls.Add(this.buttonRefresh);
			this.panel3.Controls.Add(this.buttonHome);
			this.panel3.Controls.Add(this.buttonForward);
			this.panel3.Controls.Add(this.buttonBack);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(114, 30);
			this.panel3.TabIndex = 1;
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.Image")));
			this.buttonRefresh.Location = new System.Drawing.Point(86, 2);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(26, 26);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefresh_Click);
			// 
			// buttonHome
			// 
			this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
			this.buttonHome.Location = new System.Drawing.Point(58, 2);
			this.buttonHome.Name = "buttonHome";
			this.buttonHome.Size = new System.Drawing.Size(26, 26);
			this.buttonHome.TabIndex = 2;
			this.buttonHome.UseVisualStyleBackColor = true;
			this.buttonHome.Click += new System.EventHandler(this.ButtonHome_Click);
			// 
			// buttonForward
			// 
			this.buttonForward.Image = ((System.Drawing.Image)(resources.GetObject("buttonForward.Image")));
			this.buttonForward.Location = new System.Drawing.Point(30, 2);
			this.buttonForward.Name = "buttonForward";
			this.buttonForward.Size = new System.Drawing.Size(26, 26);
			this.buttonForward.TabIndex = 1;
			this.buttonForward.UseVisualStyleBackColor = true;
			this.buttonForward.Click += new System.EventHandler(this.ButtonForward_Click);
			// 
			// buttonBack
			// 
			this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
			this.buttonBack.Location = new System.Drawing.Point(2, 2);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(26, 26);
			this.buttonBack.TabIndex = 0;
			this.buttonBack.UseVisualStyleBackColor = true;
			this.buttonBack.Click += new System.EventHandler(this.ButtonBack_Click);
			// 
			// textUrl
			// 
			this.textUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textUrl.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textUrl.Location = new System.Drawing.Point(120, 7);
			this.textUrl.Name = "textUrl";
			this.textUrl.Size = new System.Drawing.Size(426, 16);
			this.textUrl.TabIndex = 0;
			this.textUrl.TabStop = false;
			this.textUrl.Enter += new System.EventHandler(this.TextUrl_Enter);
			this.textUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextUrl_KeyDown);
			this.textUrl.Leave += new System.EventHandler(this.TextUrl_Leave);
			// 
			// panelLinks
			// 
			this.panelLinks.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelLinks.Location = new System.Drawing.Point(0, 32);
			this.panelLinks.Name = "panelLinks";
			this.panelLinks.Size = new System.Drawing.Size(556, 30);
			this.panelLinks.TabIndex = 13;
			// 
			// panelWebview
			// 
			this.panelWebview.BackColor = System.Drawing.Color.White;
			this.panelWebview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelWebview.Location = new System.Drawing.Point(0, 62);
			this.panelWebview.Name = "panelWebview";
			this.panelWebview.Size = new System.Drawing.Size(556, 309);
			this.panelWebview.TabIndex = 14;
			// 
			// WebForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(556, 371);
			this.Controls.Add(this.panelWebview);
			this.Controls.Add(this.panelLinks);
			this.Controls.Add(this.panelNavigation);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "WebForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Stargate Universe Webview";
			this.Load += new System.EventHandler(this.WebForm_Load);
			this.Shown += new System.EventHandler(this.WebForm_Shown);
			this.panelNavigation.ResumeLayout(false);
			this.panelNavigation.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panelNavigation;
		private System.Windows.Forms.LinkLabel linkEmail;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonHome;
		private System.Windows.Forms.Button buttonForward;
		private System.Windows.Forms.Button buttonBack;
		private System.Windows.Forms.TextBox textUrl;
		private System.Windows.Forms.FlowLayoutPanel panelLinks;
		private System.Windows.Forms.Panel panelWebview;
	}
}