// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-10-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="Gui.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using Daliyah.Scraper.Anime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daliyah
{
    /// <summary>
    /// Class Gui.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class Gui : Form
    {
        private readonly Settings _settings = new Settings();

        /// <summary>
        /// Initializes the Gui
        /// </summary>
        public Gui()
        {
            InitializeComponent();

            LoadWebsiteLists();

            SaveLocationLabel.Text = _settings.SavePath;

            var categoryListBoxItemContextMenuStrip = new ContextMenuStrip();
            categoryListBoxItemContextMenuStrip.Items.Add("Configure...");
            categoryListBoxItemContextMenuStrip.ItemClicked += CategoryListBoxItemContextMenuStrip_ItemClicked;

            WebsiteListDrama.ContextMenuStrip = categoryListBoxItemContextMenuStrip;

            WebsiteListDrama.MouseClick += (sender, args) =>
            {
                if (args.Button != MouseButtons.Right) return;

                var index = WebsiteListDrama.IndexFromPoint(args.Location);
                {
                    if (index == WebsiteListDrama.SelectedIndex)
                    {
                        categoryListBoxItemContextMenuStrip.Show(WebsiteListDrama, args.Location);
                    }
                }
            };
        }

        private void CategoryListBoxItemContextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        /// <summary>
        /// Loads the website lists.
        /// </summary>
        private void LoadWebsiteLists()
        {
            string[] dramaSites =
            {
                "kissasian.com",
                "dopeka.com", "doramasjc.com", "doramastv.com", "drama24hr.asia", "dramacity.se", "dramago.com",
                "dramalove.tv", "dramanices.com", "dramatvb.se", "estrenosdoramas.net", "gooddrama.to",
                "hkdramaon9.com", "icdrama.se", "myasiantv.se", "novelascoreanas.es"
            };
            for (var i = 0; i < dramaSites.Length; i++)
            {
                WebsiteListDrama.Items.Insert(i, dramaSites[i]);
            }

            string[] animeSites =
            {
                "9anime.to", "gogoanime.io"
            };
            for (var i = 0; i < animeSites.Length; i++)
            {
                WebsiteListAnime.Items.Insert(i, animeSites[i]);
            }

            string[] adultSites =
            {
                "pron.tv"
            };
            for (var i = 0; i < adultSites.Length; i++)
            {
                WebsiteListAdult.Items.Insert(i, adultSites[i]);
            }
        }

        /// <summary>
        /// magic button click as an asynchronous operation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private async void ProcessButton_ClickAsync(object sender, EventArgs e)
        {
            if (WebsiteListDrama.SelectedItem == null && WebsiteListAdult.SelectedItem == null &&
                WebsiteListAnime.SelectedItem == null)
            {
                MessageBox.Show(@"No Routine Selected.", @"Routine Exception | Delilah",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (WebsiteListDrama.SelectedItem == null || WebsiteListDrama.SelectedItem.ToString() != "kissasian.com")
            {
                MessageBox.Show(@"Routine is disabled.", @"Routine Exception | Delilah",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (_settings.ProxyCount <= 0)
            {
                MessageBox.Show(@"No Proxies Loaded.", @"Proxy Exception | Delilah",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            ProcessButton.Enabled = false;
            SetSaveLocationButton.Enabled = false;
            LoadProxiesButton.Enabled = false;
            TabbedWindow.Enabled = false;
            RoutineProgressBar.Enabled = true;
            RoutineProgressBar.Value = 66;

            var kissasianScraper = new KissasianScraper(_settings.SavePath, _settings.ProxyList);
            kissasianScraper.ScrapingFinished += (source, args) =>
            {
                ProcessButton.Enabled = true;
                SetSaveLocationButton.Enabled = true;
                LoadProxiesButton.Enabled = true;
                TabbedWindow.Enabled = true;
                RoutineProgressBar.Enabled = false;
                RoutineProgressBar.Value = 0;
            };
            await kissasianScraper.StartSiteScrapingAsync();
        }

        private void SetSaveLocationButton_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog =
                new FolderBrowserDialog {Description = @"Locate where to save reports and debug files."};
            if (folderBrowserDialog.ShowDialog() != DialogResult.OK) return;

            var selectedPath = folderBrowserDialog.SelectedPath;

            _settings.SavePath = selectedPath;

            SaveLocationLabel.Text = $@"Save Location: {_settings.SavePath}";
        }

        private async void LoadProxiesButton_Click(object sender, EventArgs e)
        {
            var fileBrowserDialog = new OpenFileDialog
            {
                InitialDirectory = _settings.SavePath,
                Filter = @"Proxies|*.txt"
            };

            if (fileBrowserDialog.ShowDialog() != DialogResult.OK) return;

            var selectedPath = fileBrowserDialog.FileName;

            var proxyList = await Task<List<WebProxy>>.Factory.StartNew(() => LoadWebProxies(selectedPath));

            _settings.ProxyList = proxyList;
            ProxiesLoadedLabel.Text = $@"Loaded Proxies: {_settings.ProxyCount}";
        }

        private static List<WebProxy> LoadWebProxies(string selectedPath)
        {
            var proxyStringList = System.IO.File.ReadAllLines(selectedPath).Distinct().ToList();

            var proxyList = new List<WebProxy>();

            foreach (var proxyString in proxyStringList)
            {
                var proxySplit = proxyString.Split(':');

                if (proxySplit.Length != 2) continue;

                if (!int.TryParse(proxySplit[1], out var proxyPort)) continue;

                var proxyHost = proxySplit[0];

                proxyList.Add(new WebProxy(proxyHost, proxyPort));
            }
            return proxyList;
        }

        private void OpenReportsFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", $@"{_settings.ReportsPath}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Unable to Open Reports Folder",
                    $@"{exception.Source} - {exception.Message} | Delilah",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OpenDebugFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", $@"{_settings.DebugPath}");
            }
            catch (Exception exception)
            {
                MessageBox.Show(@"Unable to Open Reports Folder",
                    $@"{exception.Source} - {exception.Message} | Delilah",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}