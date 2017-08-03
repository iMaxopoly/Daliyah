// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-18-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-18-2017
// ***********************************************************************
// <copyright file="WebRendererKissasian.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Daliyah.Requester
{
    /// <summary>
    /// Class WebRendererKissasian.
    /// </summary>
    /// <seealso cref="Daliyah.IRequester" />
    internal class WebRendererKissasian : IRequester
    {
        /// <summary>
        /// download HTML as an asynchronous operation.
        /// </summary>
        /// <param name="siteUrl">The URL.</param>
        /// <param name="sitePageType">Type of the page.</param>
        /// <param name="siteSignature">The siteSignature.</param>
        /// <param name="proxy">The proxy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public (string html, bool isSuccessful) DownloadHtml(string siteUrl, PageType sitePageType,
            string siteSignature, WebProxy proxy)
        {
            var taskDone = false;
            string html = null;
            var isSuccessful = false;
            var isUsingProxy = false;
            string instanceHash;

            // Attach proxy
            if (proxy != null)
            {
                isUsingProxy = true;
            }

            // Generate SHA256 for thread name/ Web Instance
            using (var sha256Hash = SHA256.Create())
            {
                instanceHash = HashGenerator.GetCryptographicHash(sha256Hash, siteUrl);
            }

            // Setup EO WebEngine
            var newWebEngine = Engine.Create(instanceHash);
            newWebEngine.Options.AllowProprietaryMediaFormats();
            newWebEngine.Options.DisableGPU = true;
            var options = new BrowserOptions
            {
                AllowJavaScriptOpenWindow = false,
                LoadImages = false
            };
            newWebEngine.Options.SetDefaultBrowserOptions(options);
            newWebEngine.Options.ExtraCommandLineArgs = "--mute-audio";
            if (isUsingProxy)
            {
                newWebEngine.Options.Proxy = new ProxyInfo(ProxyType.HTTP, proxy.Address.Host, proxy.Address.Port);
            }

            // Instantiate thread runner
            var runner = new ThreadRunner(instanceHash, newWebEngine);
            var view = runner.CreateWebView();

            // Handle certificate error
            view.CertificateError += (sender, e) => { e.Continue(); };

            // User Agent
            view.CustomUserAgent = RequesterDefaults.UserAgent;

            runner.Send(async () =>
            {
                var task = view.LoadUrl(siteUrl);
                task.WaitOne(20000);

                string googleRedirectorCyberlockerValue = null;

                // Custom Handler to check redirect location response header
                task.WebView.AfterReceiveHeaders += (sender, e) =>
                {
                    if (string.IsNullOrWhiteSpace(e.Response.RedirectLocation) ||
                        !e.Response.RedirectLocation.Contains("googlevideo.com")) return;
                    googleRedirectorCyberlockerValue = e.Response.RedirectLocation;
                };

                switch (sitePageType)
                {
                    case PageType.Static:
                        break;

                    case PageType.Javascript:
                        await Task.Delay(RequesterDefaults.JavascriptPageWait);
                        break;

                    case PageType.Cloudflare:
                        await Task.Delay(RequesterDefaults.CloudflarePageWait);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(typeof(PageType).ToString());
                }

                if (view.CanEvalScript)
                {
                    html = task.WebView.GetHtml();
                    if (html.Contains(siteSignature))
                    {
                        isSuccessful = true;
                    }
                }

                // Replace In=Site URL with Google Redirector URL
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var googleRedirectorCyberlockerNode =
                    doc.DocumentNode.SelectSingleNode("//video[@id='my_video_1_html5_api']");
                if (googleRedirectorCyberlockerNode != null)
                {
                    doc.DocumentNode.SelectSingleNode("//video[@id='my_video_1_html5_api']")
                        .SetAttributeValue("src", googleRedirectorCyberlockerValue);
                }

                if (!string.IsNullOrWhiteSpace(doc.DocumentNode.InnerHtml))
                {
                    html = doc.DocumentNode.InnerHtml;
                }

                taskDone = true;
            }, 60000);

            while (!taskDone)
            {
                Thread.Sleep(2000);
            }

            view.Destroy();
            newWebEngine.Stop(true);
            runner.Dispose();

            return (html, isSuccessful);
        }
    }
}