namespace StargateClient {
	partial class MainForm {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mapView = new System.Windows.Forms.ListView();
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.menuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.openTooStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tray = new System.Windows.Forms.NotifyIcon(this.components);
			this.menuTray.SuspendLayout();
			this.SuspendLayout();
			// 
			// mapView
			// 
			this.mapView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader3});
			this.mapView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mapView.FullRowSelect = true;
			this.mapView.GridLines = true;
			this.mapView.HideSelection = false;
			this.mapView.Location = new System.Drawing.Point(0, 0);
			this.mapView.MultiSelect = false;
			this.mapView.Name = "mapView";
			this.mapView.Size = new System.Drawing.Size(663, 254);
			this.mapView.TabIndex = 2;
			this.mapView.UseCompatibleStateImageBehavior = false;
			this.mapView.View = System.Windows.Forms.View.Details;
			this.mapView.DoubleClick += new System.EventHandler(this.MapView_DoubleClick);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Server";
			this.columnHeader6.Width = 0;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Port";
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "IP";
			this.columnHeader1.Width = 107;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Name";
			this.columnHeader2.Width = 100;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Description";
			this.columnHeader4.Width = 200;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Account";
			this.columnHeader3.Width = 150;
			// 
			// menuTray
			// 
			this.menuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTooStrip,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.menuTray.Name = "trayMenu";
			this.menuTray.Size = new System.Drawing.Size(104, 60);
			// 
			// openTooStrip
			// 
			this.openTooStrip.Name = "openTooStrip";
			this.openTooStrip.Size = new System.Drawing.Size(103, 22);
			this.openTooStrip.Text = "&Open";
			this.openTooStrip.Click += new System.EventHandler(this.FormRestoreClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(100, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.exitToolStripMenuItem.Text = "&Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.FormExitClick);
			// 
			// tray
			// 
			this.tray.ContextMenuStrip = this.menuTray;
			this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
			this.tray.Text = "Stargate Universe";
			this.tray.Visible = true;
			this.tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.FormRestoreClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(663, 254);
			this.Controls.Add(this.mapView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Stargate Universe Client";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.menuTray.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView mapView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ContextMenuStrip menuTray;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.NotifyIcon tray;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem openTooStrip;
		private System.Windows.Forms.ColumnHeader columnHeader6;
	}
}

