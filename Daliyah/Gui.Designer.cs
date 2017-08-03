namespace Daliyah
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.ProcessButton = new System.Windows.Forms.Button();
            this.SitesLabel = new System.Windows.Forms.Label();
            this.WebsiteListAdult = new System.Windows.Forms.ListBox();
            this.TabbedWindow = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.WebsiteListAnime = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.WebsiteListDrama = new System.Windows.Forms.ListBox();
            this.LoadProxiesButton = new System.Windows.Forms.Button();
            this.SetSaveLocationButton = new System.Windows.Forms.Button();
            this.SaveLocationLabel = new System.Windows.Forms.Label();
            this.ProxiesLoadedLabel = new System.Windows.Forms.Label();
            this.OpenReportsFolderButton = new System.Windows.Forms.Button();
            this.OpenDebugFolderButton = new System.Windows.Forms.Button();
            this.RoutineProgressBar = new System.Windows.Forms.ProgressBar();
            this.TotalProxyRetriesStaticLabel = new System.Windows.Forms.Label();
            this.AvgProxyRetriesStaticLabel = new System.Windows.Forms.Label();
            this.TotalProxyFailuresStaticLabel = new System.Windows.Forms.Label();
            this.TotalProxySuccessStaticLabel = new System.Windows.Forms.Label();
            this.AvgProxySuccessStaticLabel = new System.Windows.Forms.Label();
            this.TotalProxyRetriesValueLabel = new System.Windows.Forms.Label();
            this.AvgProxyRetriesValueLabel = new System.Windows.Forms.Label();
            this.TotalProxyFailuresValueLabel = new System.Windows.Forms.Label();
            this.TotalProxySuccessValueLabel = new System.Windows.Forms.Label();
            this.AvgProxySuccessValueLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.TabbedWindow.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessButton
            // 
            this.ProcessButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.ProcessButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProcessButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProcessButton.Location = new System.Drawing.Point(9, 518);
            this.ProcessButton.Name = "ProcessButton";
            this.ProcessButton.Size = new System.Drawing.Size(158, 26);
            this.ProcessButton.TabIndex = 2;
            this.ProcessButton.Text = "Process";
            this.ProcessButton.UseVisualStyleBackColor = true;
            this.ProcessButton.Click += new System.EventHandler(this.ProcessButton_ClickAsync);
            // 
            // SitesLabel
            // 
            this.SitesLabel.AutoSize = true;
            this.SitesLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.SitesLabel.Location = new System.Drawing.Point(12, 27);
            this.SitesLabel.Name = "SitesLabel";
            this.SitesLabel.Size = new System.Drawing.Size(37, 18);
            this.SitesLabel.TabIndex = 5;
            this.SitesLabel.Text = "Sites";
            // 
            // WebsiteListAdult
            // 
            this.WebsiteListAdult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebsiteListAdult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WebsiteListAdult.FormattingEnabled = true;
            this.WebsiteListAdult.ItemHeight = 15;
            this.WebsiteListAdult.Location = new System.Drawing.Point(3, 3);
            this.WebsiteListAdult.Name = "WebsiteListAdult";
            this.WebsiteListAdult.Size = new System.Drawing.Size(312, 225);
            this.WebsiteListAdult.Sorted = true;
            this.WebsiteListAdult.TabIndex = 6;
            // 
            // TabbedWindow
            // 
            this.TabbedWindow.Controls.Add(this.tabPage1);
            this.TabbedWindow.Controls.Add(this.tabPage2);
            this.TabbedWindow.Controls.Add(this.tabPage3);
            this.TabbedWindow.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabbedWindow.Location = new System.Drawing.Point(9, 190);
            this.TabbedWindow.Name = "TabbedWindow";
            this.TabbedWindow.SelectedIndex = 0;
            this.TabbedWindow.Size = new System.Drawing.Size(326, 259);
            this.TabbedWindow.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.WebsiteListAdult);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(318, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Adult";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.WebsiteListAnime);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(318, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Anime";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // WebsiteListAnime
            // 
            this.WebsiteListAnime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebsiteListAnime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WebsiteListAnime.FormattingEnabled = true;
            this.WebsiteListAnime.ItemHeight = 15;
            this.WebsiteListAnime.Location = new System.Drawing.Point(3, 3);
            this.WebsiteListAnime.Name = "WebsiteListAnime";
            this.WebsiteListAnime.Size = new System.Drawing.Size(312, 225);
            this.WebsiteListAnime.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.WebsiteListDrama);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(318, 231);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Drama";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // WebsiteListDrama
            // 
            this.WebsiteListDrama.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebsiteListDrama.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WebsiteListDrama.FormattingEnabled = true;
            this.WebsiteListDrama.ItemHeight = 15;
            this.WebsiteListDrama.Location = new System.Drawing.Point(3, 3);
            this.WebsiteListDrama.Name = "WebsiteListDrama";
            this.WebsiteListDrama.Size = new System.Drawing.Size(312, 225);
            this.WebsiteListDrama.TabIndex = 0;
            // 
            // LoadProxiesButton
            // 
            this.LoadProxiesButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.LoadProxiesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoadProxiesButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadProxiesButton.Location = new System.Drawing.Point(181, 19);
            this.LoadProxiesButton.Name = "LoadProxiesButton";
            this.LoadProxiesButton.Size = new System.Drawing.Size(158, 25);
            this.LoadProxiesButton.TabIndex = 10;
            this.LoadProxiesButton.Text = "Load Proxies";
            this.LoadProxiesButton.UseVisualStyleBackColor = true;
            this.LoadProxiesButton.Click += new System.EventHandler(this.LoadProxiesButton_Click);
            // 
            // SetSaveLocationButton
            // 
            this.SetSaveLocationButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.SetSaveLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SetSaveLocationButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SetSaveLocationButton.Location = new System.Drawing.Point(12, 83);
            this.SetSaveLocationButton.Name = "SetSaveLocationButton";
            this.SetSaveLocationButton.Size = new System.Drawing.Size(157, 25);
            this.SetSaveLocationButton.TabIndex = 11;
            this.SetSaveLocationButton.Text = "Set Save Location";
            this.SetSaveLocationButton.UseVisualStyleBackColor = true;
            this.SetSaveLocationButton.Click += new System.EventHandler(this.SetSaveLocationButton_Click);
            // 
            // SaveLocationLabel
            // 
            this.SaveLocationLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveLocationLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.SaveLocationLabel.Location = new System.Drawing.Point(10, 111);
            this.SaveLocationLabel.Name = "SaveLocationLabel";
            this.SaveLocationLabel.Size = new System.Drawing.Size(325, 30);
            this.SaveLocationLabel.TabIndex = 12;
            // 
            // ProxiesLoadedLabel
            // 
            this.ProxiesLoadedLabel.AutoSize = true;
            this.ProxiesLoadedLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProxiesLoadedLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.ProxiesLoadedLabel.Location = new System.Drawing.Point(13, 24);
            this.ProxiesLoadedLabel.Name = "ProxiesLoadedLabel";
            this.ProxiesLoadedLabel.Size = new System.Drawing.Size(126, 15);
            this.ProxiesLoadedLabel.TabIndex = 13;
            this.ProxiesLoadedLabel.Text = "Proxies Loaded: 0";
            // 
            // OpenReportsFolderButton
            // 
            this.OpenReportsFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.OpenReportsFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenReportsFolderButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenReportsFolderButton.Location = new System.Drawing.Point(10, 149);
            this.OpenReportsFolderButton.Name = "OpenReportsFolderButton";
            this.OpenReportsFolderButton.Size = new System.Drawing.Size(157, 25);
            this.OpenReportsFolderButton.TabIndex = 14;
            this.OpenReportsFolderButton.Text = "Open Reports Folder";
            this.OpenReportsFolderButton.UseVisualStyleBackColor = true;
            this.OpenReportsFolderButton.Click += new System.EventHandler(this.OpenReportsFolderButton_Click);
            // 
            // OpenDebugFolderButton
            // 
            this.OpenDebugFolderButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.OpenDebugFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenDebugFolderButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenDebugFolderButton.Location = new System.Drawing.Point(181, 149);
            this.OpenDebugFolderButton.Name = "OpenDebugFolderButton";
            this.OpenDebugFolderButton.Size = new System.Drawing.Size(154, 25);
            this.OpenDebugFolderButton.TabIndex = 15;
            this.OpenDebugFolderButton.Text = "Open Debug Folder";
            this.OpenDebugFolderButton.UseVisualStyleBackColor = true;
            this.OpenDebugFolderButton.Click += new System.EventHandler(this.OpenDebugFolderButton_Click);
            // 
            // RoutineProgressBar
            // 
            this.RoutineProgressBar.Enabled = false;
            this.RoutineProgressBar.Location = new System.Drawing.Point(10, 458);
            this.RoutineProgressBar.Name = "RoutineProgressBar";
            this.RoutineProgressBar.Size = new System.Drawing.Size(321, 23);
            this.RoutineProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.RoutineProgressBar.TabIndex = 16;
            this.RoutineProgressBar.UseWaitCursor = true;
            // 
            // TotalProxyRetriesStaticLabel
            // 
            this.TotalProxyRetriesStaticLabel.AutoSize = true;
            this.TotalProxyRetriesStaticLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxyRetriesStaticLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TotalProxyRetriesStaticLabel.Location = new System.Drawing.Point(401, 49);
            this.TotalProxyRetriesStaticLabel.Name = "TotalProxyRetriesStaticLabel";
            this.TotalProxyRetriesStaticLabel.Size = new System.Drawing.Size(140, 15);
            this.TotalProxyRetriesStaticLabel.TabIndex = 18;
            this.TotalProxyRetriesStaticLabel.Text = "Total Proxy Retries";
            // 
            // AvgProxyRetriesStaticLabel
            // 
            this.AvgProxyRetriesStaticLabel.AutoSize = true;
            this.AvgProxyRetriesStaticLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgProxyRetriesStaticLabel.ForeColor = System.Drawing.Color.DimGray;
            this.AvgProxyRetriesStaticLabel.Location = new System.Drawing.Point(408, 140);
            this.AvgProxyRetriesStaticLabel.Name = "AvgProxyRetriesStaticLabel";
            this.AvgProxyRetriesStaticLabel.Size = new System.Drawing.Size(133, 15);
            this.AvgProxyRetriesStaticLabel.TabIndex = 19;
            this.AvgProxyRetriesStaticLabel.Text = "Avg. Proxy Retries";
            // 
            // TotalProxyFailuresStaticLabel
            // 
            this.TotalProxyFailuresStaticLabel.AutoSize = true;
            this.TotalProxyFailuresStaticLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxyFailuresStaticLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TotalProxyFailuresStaticLabel.Location = new System.Drawing.Point(394, 227);
            this.TotalProxyFailuresStaticLabel.Name = "TotalProxyFailuresStaticLabel";
            this.TotalProxyFailuresStaticLabel.Size = new System.Drawing.Size(147, 15);
            this.TotalProxyFailuresStaticLabel.TabIndex = 20;
            this.TotalProxyFailuresStaticLabel.Text = "Total Proxy Failures";
            // 
            // TotalProxySuccessStaticLabel
            // 
            this.TotalProxySuccessStaticLabel.AutoSize = true;
            this.TotalProxySuccessStaticLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxySuccessStaticLabel.ForeColor = System.Drawing.Color.DimGray;
            this.TotalProxySuccessStaticLabel.Location = new System.Drawing.Point(401, 318);
            this.TotalProxySuccessStaticLabel.Name = "TotalProxySuccessStaticLabel";
            this.TotalProxySuccessStaticLabel.Size = new System.Drawing.Size(140, 15);
            this.TotalProxySuccessStaticLabel.TabIndex = 21;
            this.TotalProxySuccessStaticLabel.Text = "Total Proxy Success";
            // 
            // AvgProxySuccessStaticLabel
            // 
            this.AvgProxySuccessStaticLabel.AutoSize = true;
            this.AvgProxySuccessStaticLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgProxySuccessStaticLabel.ForeColor = System.Drawing.Color.DimGray;
            this.AvgProxySuccessStaticLabel.Location = new System.Drawing.Point(394, 410);
            this.AvgProxySuccessStaticLabel.Name = "AvgProxySuccessStaticLabel";
            this.AvgProxySuccessStaticLabel.Size = new System.Drawing.Size(147, 15);
            this.AvgProxySuccessStaticLabel.TabIndex = 22;
            this.AvgProxySuccessStaticLabel.Text = "Avg. Proxy Success %";
            // 
            // TotalProxyRetriesValueLabel
            // 
            this.TotalProxyRetriesValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalProxyRetriesValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxyRetriesValueLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TotalProxyRetriesValueLabel.Location = new System.Drawing.Point(451, 84);
            this.TotalProxyRetriesValueLabel.Name = "TotalProxyRetriesValueLabel";
            this.TotalProxyRetriesValueLabel.Size = new System.Drawing.Size(87, 15);
            this.TotalProxyRetriesValueLabel.TabIndex = 23;
            this.TotalProxyRetriesValueLabel.Text = "0";
            this.TotalProxyRetriesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AvgProxyRetriesValueLabel
            // 
            this.AvgProxyRetriesValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AvgProxyRetriesValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgProxyRetriesValueLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.AvgProxyRetriesValueLabel.Location = new System.Drawing.Point(451, 175);
            this.AvgProxyRetriesValueLabel.Name = "AvgProxyRetriesValueLabel";
            this.AvgProxyRetriesValueLabel.Size = new System.Drawing.Size(87, 15);
            this.AvgProxyRetriesValueLabel.TabIndex = 24;
            this.AvgProxyRetriesValueLabel.Text = "0";
            this.AvgProxyRetriesValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalProxyFailuresValueLabel
            // 
            this.TotalProxyFailuresValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalProxyFailuresValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxyFailuresValueLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TotalProxyFailuresValueLabel.Location = new System.Drawing.Point(451, 263);
            this.TotalProxyFailuresValueLabel.Name = "TotalProxyFailuresValueLabel";
            this.TotalProxyFailuresValueLabel.Size = new System.Drawing.Size(87, 15);
            this.TotalProxyFailuresValueLabel.TabIndex = 25;
            this.TotalProxyFailuresValueLabel.Text = "0";
            this.TotalProxyFailuresValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TotalProxySuccessValueLabel
            // 
            this.TotalProxySuccessValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.TotalProxySuccessValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalProxySuccessValueLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.TotalProxySuccessValueLabel.Location = new System.Drawing.Point(451, 355);
            this.TotalProxySuccessValueLabel.Name = "TotalProxySuccessValueLabel";
            this.TotalProxySuccessValueLabel.Size = new System.Drawing.Size(87, 15);
            this.TotalProxySuccessValueLabel.TabIndex = 26;
            this.TotalProxySuccessValueLabel.Text = "0";
            this.TotalProxySuccessValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AvgProxySuccessValueLabel
            // 
            this.AvgProxySuccessValueLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AvgProxySuccessValueLabel.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvgProxySuccessValueLabel.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.AvgProxySuccessValueLabel.Location = new System.Drawing.Point(455, 443);
            this.AvgProxySuccessValueLabel.Name = "AvgProxySuccessValueLabel";
            this.AvgProxySuccessValueLabel.Size = new System.Drawing.Size(83, 15);
            this.AvgProxySuccessValueLabel.TabIndex = 27;
            this.AvgProxySuccessValueLabel.Text = "0";
            this.AvgProxySuccessValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(13, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 15);
            this.label6.TabIndex = 28;
            this.label6.Text = "Clients Loaded: 0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(181, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 25);
            this.button1.TabIndex = 29;
            this.button1.Text = "Load Clients";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // StopButton
            // 
            this.StopButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.StopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StopButton.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopButton.Location = new System.Drawing.Point(174, 518);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(161, 26);
            this.StopButton.TabIndex = 30;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Consolas", 7.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(414, 534);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(127, 13);
            this.linkLabel1.TabIndex = 31;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "v. 1.0.0.1 kryptodev";
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(549, 556);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.AvgProxySuccessValueLabel);
            this.Controls.Add(this.TotalProxySuccessValueLabel);
            this.Controls.Add(this.TotalProxyFailuresValueLabel);
            this.Controls.Add(this.AvgProxyRetriesValueLabel);
            this.Controls.Add(this.TotalProxyRetriesValueLabel);
            this.Controls.Add(this.AvgProxySuccessStaticLabel);
            this.Controls.Add(this.TotalProxySuccessStaticLabel);
            this.Controls.Add(this.TotalProxyFailuresStaticLabel);
            this.Controls.Add(this.AvgProxyRetriesStaticLabel);
            this.Controls.Add(this.TotalProxyRetriesStaticLabel);
            this.Controls.Add(this.RoutineProgressBar);
            this.Controls.Add(this.OpenDebugFolderButton);
            this.Controls.Add(this.OpenReportsFolderButton);
            this.Controls.Add(this.ProxiesLoadedLabel);
            this.Controls.Add(this.SaveLocationLabel);
            this.Controls.Add(this.SetSaveLocationButton);
            this.Controls.Add(this.LoadProxiesButton);
            this.Controls.Add(this.TabbedWindow);
            this.Controls.Add(this.ProcessButton);
            this.Controls.Add(this.SitesLabel);
            this.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Gui";
            this.Text = "Daliyah";
            this.TabbedWindow.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ProcessButton;
        private System.Windows.Forms.Label SitesLabel;
        private System.Windows.Forms.ListBox WebsiteListAdult;
        private System.Windows.Forms.TabControl TabbedWindow;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListBox WebsiteListAnime;
        private System.Windows.Forms.ListBox WebsiteListDrama;
        private System.Windows.Forms.Button LoadProxiesButton;
        private System.Windows.Forms.Button SetSaveLocationButton;
        private System.Windows.Forms.Label SaveLocationLabel;
        private System.Windows.Forms.Label ProxiesLoadedLabel;
        private System.Windows.Forms.Button OpenReportsFolderButton;
        private System.Windows.Forms.Button OpenDebugFolderButton;
        private System.Windows.Forms.ProgressBar RoutineProgressBar;
        private System.Windows.Forms.Label TotalProxyRetriesStaticLabel;
        private System.Windows.Forms.Label AvgProxyRetriesStaticLabel;
        private System.Windows.Forms.Label TotalProxyFailuresStaticLabel;
        private System.Windows.Forms.Label TotalProxySuccessStaticLabel;
        private System.Windows.Forms.Label AvgProxySuccessStaticLabel;
        private System.Windows.Forms.Label TotalProxyRetriesValueLabel;
        private System.Windows.Forms.Label AvgProxyRetriesValueLabel;
        private System.Windows.Forms.Label TotalProxyFailuresValueLabel;
        private System.Windows.Forms.Label TotalProxySuccessValueLabel;
        private System.Windows.Forms.Label AvgProxySuccessValueLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

