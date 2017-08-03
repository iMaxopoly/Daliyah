// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="WebRenderer.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using EO.Base;
using EO.WebBrowser;
using EO.WebEngine;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Daliyah.Requester
{
    /// <summary>
    /// Class WebRenderer.
    /// </summary>
    /// <seealso cref="Daliyah.IRequester" />
    internal class WebRenderer : IRequester
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
            view.CustomUserAgent = RequesterDefaults.UserAgent;

            runner.Send(async () =>
            {
                var task = view.LoadUrl(siteUrl);
                task.WaitOne(20000);

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

                taskDone = true;
            });

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