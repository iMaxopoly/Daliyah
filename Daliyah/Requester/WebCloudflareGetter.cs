// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-17-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-17-2017
// ***********************************************************************
// <copyright file="WebCloudflareGetter.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using CloudFlareUtilities;
using System.Net;
using System.Net.Http;

namespace Daliyah.Requester
{
    /// <summary>
    /// Class WebCloudflareGetter.
    /// </summary>
    /// <seealso cref="Daliyah.IRequester" />
    internal class WebCloudflareGetter : IRequester
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
            var isUsingProxy = proxy != null;

            var innerHandler = new HttpClientHandler
            {
                AllowAutoRedirect = true,
                MaxAutomaticRedirections = 6,
            };
            if (isUsingProxy)
            {
                innerHandler.Proxy = proxy;
                innerHandler.UseProxy = true;
            }

            var handler = new ClearanceHandler(innerHandler);

            // Create a HttpClient that uses the handler to bypass CloudFlare's JavaScript challange.
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", RequesterDefaults.UserAgent);

            // Use the HttpClient as usual. Any JS challenge will be solved automatically for you.
            var html = client.GetStringAsync(siteUrl).Result;

            if (html == null || !html.Contains(siteSignature))
            {
                return (html, false);
            }

            return (html, true);
        }
    }
}