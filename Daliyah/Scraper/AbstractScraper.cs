using Daliyah.DataDumper;
using Daliyah.Logger;
using Daliyah.Proxier;
using Daliyah.Requester;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Daliyah.Scraper
{
    public abstract partial class AbstractScraper : IScraper
    {
        /// <summary>
        /// Occurs when [scraping finished].
        /// </summary>
        public event EventHandler ScrapingFinished;

        protected abstract Uri SiteUri { get; set; }

        /// <summary>
        /// Gets or sets the site signature.
        /// </summary>
        /// <value>The site signature.</value>
        protected abstract string SiteSignature { get; set; }

        /// <summary>
        /// Gets or sets the type of the site page.
        /// </summary>
        /// <value>The type of the site page.</value>
        protected abstract PageType SitePageType { get; set; }

        /// <summary>
        /// Gets or sets the site parallelism.
        /// </summary>
        /// <value>The site parallelism.</value>
        protected abstract int SiteParallelism { get; set; }

        protected int MaxRetry = 5;

        protected enum SiteResultType
        {
            Title,
            Episode,
            Cyberlocker,
            Miscellaneous
        }

        /// <summary>
        /// The logger
        /// </summary>
        protected readonly ILogger Logger;

        protected readonly IProxier Proxier;

        /// <summary>
        /// The data dumper
        /// </summary>
        protected readonly IDataDumper DataDumper;

        /// <summary>
        /// The current time stamp
        /// </summary>
        protected readonly DateTime CurrentTimeStamp;

        public string SavePath { get; set; } =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\Delilah";

        protected string BaseUrl => SiteUri.AbsoluteUri;

        protected AbstractScraper()
        {
            Logger = new ConsoleLogger();
            DataDumper = new FileWriter();
            CurrentTimeStamp = DateTime.Now;
        }

        protected AbstractScraper(string savePath, List<WebProxy> proxyList)
            : this()
        {
            SavePath = savePath;
            Proxier = new RandomBasedProxySupplier(proxyList);
        }

        protected (string html, List<string> linkList) GetMultiResultBySelector(string link, string selector,
            string selectorAttributeForValue, SiteResultType resultType, bool resultLinksAreRelative, bool useProxy)
        {
            IRequester requester = new WebRenderer();
            var retryCount = 0;
            string html = null;
            while (retryCount < MaxRetry)
            {
                WebProxy proxy = null;
                if (useProxy)
                {
                    proxy = Proxier.GetProxy();
                }
                Logger.Log(
                    proxy == null
                        ? $"Fetch: {resultType} | Retry: {retryCount} | Link: {link}"
                        : $"Fetch: {resultType} | Proxy: {proxy.Address.Host}:{proxy.Address.Port} | Retry: {retryCount} | Link: {link}",
                    LogType.Log);
                bool isSuccessful;
                (html, isSuccessful) = requester.DownloadHtml(link, SitePageType, SiteSignature, proxy);
                if (!isSuccessful)
                {
                    retryCount++;
                    continue;
                }
                break;
            }

            if (string.IsNullOrWhiteSpace(html)) return (null, null);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var linkNodes = doc.DocumentNode.SelectNodes(selector);
            if (linkNodes == null)
            {
                Logger.Log($"Empty {resultType} Nodes: {link}", LogType.Error);
                Console.WriteLine(
                    $@"{SavePath}/Debug/{SiteUri.Host}/{
                            CurrentTimeStamp
                        :d-M-yy_HH-mm-ss}/Error/ErrorHtml{resultType}.txt");
                DataDumper.Write(doc.DocumentNode.InnerHtml,
                    $"{SavePath}/Debug/{SiteUri.Host}/{CurrentTimeStamp:d-M-yy_HH-mm-ss}/Error/ErrorHtml{resultType}.txt");
                return (html, null);
            }

            var linkList = new List<string>();
            foreach (var linkNode in linkNodes)
            {
                var relativeLink = linkNode.Attributes[selectorAttributeForValue].Value;
                if (string.IsNullOrWhiteSpace(relativeLink)) continue;

                if (resultLinksAreRelative)
                {
                    Logger.Log($"Result {resultType} Link: {BaseUrl + relativeLink}", LogType.Log);
                    linkList.Add(BaseUrl + relativeLink);
                }
                else
                {
                    Logger.Log($"Result {resultType} Link: {relativeLink}", LogType.Log);
                    linkList.Add(relativeLink);
                }
            }

            return (html, linkList);
        }

        public virtual Task StartSiteInspectionAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task StartSiteScrapingAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task GenerateReportAsync()
        {
            throw new NotImplementedException();
        }

        protected virtual void OnScrapingFinished()
        {
            ScrapingFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}