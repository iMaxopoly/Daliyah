// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-24-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-26-2017
// ***********************************************************************
// <copyright file="KissasianScraper.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using Daliyah.Logger;
using Daliyah.Requester;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Daliyah.Scraper.Anime
{
    /// <summary>
    /// Class KissasianScraper. This class cannot be inherited.
    /// </summary>
    /// <seealso cref="Daliyah.Scraper.AbstractScraper" />
    internal sealed class KissasianScraper : AbstractScraper
    {
        protected override Uri SiteUri { get; set; } = new Uri(WebsiteAbsolutePaths.Kissasian);

        /// <summary>
        /// Gets or sets the site signature.
        /// </summary>
        /// <value>The site signature.</value>
        protected override string SiteSignature { get; set; } = "UA-63783416-2";

        /// <summary>
        /// Gets or sets the type of the site page.
        /// </summary>
        /// <value>The type of the site page.</value>
        protected override PageType SitePageType { get; set; } = PageType.Cloudflare;

        /// <summary>
        /// Gets or sets the site parallelism.
        /// </summary>
        /// <value>The site parallelism.</value>
        protected override int SiteParallelism { get; set; } = 20;


        public KissasianScraper(string savePath, List<WebProxy> proxyList)
            : base(savePath, proxyList)
        {
            MaxRetry = 12;
        }

        /// <summary>
        /// start site inspection as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task StartSiteInspectionAsync()
        {
            OnScrapingFinished();
        }

        /// <summary>
        /// start site scraping as an asynchronous operation.
        /// </summary>
        /// <returns>Task.</returns>
        public override async Task StartSiteScrapingAsync()
        {
            Logger.Log("Starting Site Scraping", LogType.Log);

            ThreadPool.SetMinThreads(SiteParallelism, SiteParallelism);

            await Step1GetTitleLinks();
            await Step2GetEpisodeLinks();
            await Step3GetCyberlockerLinks();

            OnScrapingFinished();
        }

        public (string html, List<string> linkList) GetTitleLinks(string link, bool useProxy)
        {
            return GetMultiResultBySelector(link, "//div[@class='item']/a", "href", SiteResultType.Title, true,
                useProxy);
        }

        public (string html, List<string> linkList) GetEpisodeLinks(string link, bool useProxy)
        {
            return GetMultiResultBySelector(link, "//td[@class='episodeSub']/a", "href", SiteResultType.Episode, true,
                useProxy);
        }

        public (string html, List<string> linkList) GetCyberlockerLinks(string link, bool useProxy)
        {
            return GetMultiResultBySelector(link,
                "//div[@id='divContentVideo']/iframe | //video[@id='my_video_1_html5_api']", "src",
                SiteResultType.Cyberlocker, false, useProxy);
        }

        /// <summary>
        /// Step1s the get title links.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task Step1GetTitleLinks()
        {
            var workerBlock = new ActionBlock<string>
            (link =>
                {
                    try
                    {
                        var (_, titleLinkList) = GetTitleLinks(link, true);

                        if (titleLinkList == null) return;

                        foreach (var titleLink in titleLinkList)
                        {
                            DataDumper.Write(titleLink,
                                $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\TitleNodes.txt");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($@"Exception raised: {ex.ToString()}", LogType.Error);
                    }
                },
                new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = SiteParallelism}
            );

            // todo: Get number of pages

            for (var i = 1; i <= 123; i++)
                workerBlock.Post($"{BaseUrl}/DramaList?page={i}");

            workerBlock.Complete();

            await workerBlock.Completion;
        }

        /// <summary>
        /// Step2s the get episode links.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task Step2GetEpisodeLinks()
        {
            var workerBlock = new ActionBlock<string>
            (link =>
                {
                    try
                    {
                        var (_, episodeLinkList) = GetEpisodeLinks(link, true);

                        if (episodeLinkList == null) return;

                        foreach (var episodeLink in episodeLinkList)
                        {
                            DataDumper.Write(episodeLink,
                                $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\EpisodeNodes.txt");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($@"Exception raised: {ex.ToString()}", LogType.Error);
                    }
                },
                new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = SiteParallelism}
            );

            // Load Title Links
            try
            {
                var fileLines = File
                    .ReadAllLines(
                        $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\TitleNodes.txt")
                    .Distinct().ToList();
                foreach (var line in fileLines)
                    workerBlock.Post(line);
            }
            catch (Exception exception)
            {
                Logger.Log($"Exception raised: Title Links File Not Found | {exception.Source} - {exception.Message}", LogType.Error);
            }
            finally
            {
                workerBlock.Complete();
            }

            await workerBlock.Completion;
        }

        /// <summary>
        /// Step3s the get cyberlocker links.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task Step3GetCyberlockerLinks()
        {
            var workerBlock = new ActionBlock<string>
            (link =>
                {
                    try
                    {
                        // Aggregate Server links
                        var (html, cyberlockerLinks) = GetCyberlockerLinks(link, true);

                        if (cyberlockerLinks == null) return;

                        var doc = new HtmlDocument();
                        doc.LoadHtml(html);

                        var pageTitleNode = doc.DocumentNode.SelectSingleNode("//title");
                        var pageTitle = pageTitleNode.InnerText.Trim();

                        foreach (var cyberlockerLink in cyberlockerLinks)
                        {
                            DataDumper.Write($"nil<<@>>{pageTitle}<<@>>{link}<<@>>{cyberlockerLink}\t",
                                $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\CyberlockerNodes.txt");
                        }

                        var serverLinkNodes = doc.DocumentNode.SelectNodes("//select[@id='selectServer']//option");
                        if (serverLinkNodes == null) return;

                        foreach (var serverLinkNode in serverLinkNodes)
                        {
                            var serverLinkValue = serverLinkNode?.GetAttributeValue("value", null);
                            if (string.IsNullOrWhiteSpace(serverLinkValue)) continue;
                            DataDumper.Write(serverLinkValue,
                                $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\ServerLinkAggregate.txt");
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Log($@"Exception raised: {ex.ToString()}", LogType.Error);
                    }
                },
                new ExecutionDataflowBlockOptions {MaxDegreeOfParallelism = SiteParallelism}
            );

            // Load Episode Links
            try
            {
                var fileLines = File
                    .ReadAllLines(
                        $"{SavePath}\\Debug\\{SiteUri.Host}\\{CurrentTimeStamp:d-M-yy_HH-mm-ss}\\EpisodeNodes.txt")
                    .Distinct().ToList();
                foreach (var line in fileLines)
                    workerBlock.Post(line);
            }
            catch (Exception exception)
            {
                Logger.Log($"Exception raised: Episode Links File Not Found | {exception.Source} - {exception.Message}", LogType.Error);
            }
            finally
            {
                workerBlock.Complete();
            }

            await workerBlock.Completion;
        }
    }
}