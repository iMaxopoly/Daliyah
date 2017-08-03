// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-17-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-17-2017
// ***********************************************************************
// <copyright file="WebSimpleGetter.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Data;
using System.IO;
using System.Net;

namespace Daliyah.Requester
{
    /// <summary>
    /// Class WebSimpleGetter.
    /// </summary>
    /// <seealso cref="Daliyah.IRequester" />
    internal class WebSimpleGetter : IRequester
    {
        /// <summary>
        /// download HTML as an asynchronous operation.
        /// </summary>
        /// <param name="siteUrl">The URL.</param>
        /// <param name="sitePageType">Type of the page.</param>
        /// <param name="siteSignature">The siteSignature.</param>
        /// <param name="proxy">The proxy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="NoNullAllowedException">Stream returned Null</exception>
        public (string html, bool isSuccessful) DownloadHtml(string siteUrl, PageType sitePageType,
            string siteSignature, WebProxy proxy)
        {
            string html;
            var isUsingProxy = proxy != null;

            var request = (HttpWebRequest) WebRequest.Create(siteUrl);
            request.AutomaticDecompression = DecompressionMethods.GZip;
            if (isUsingProxy)
            {
                request.Proxy = proxy;
            }
            request.AllowAutoRedirect = true;
            request.MaximumAutomaticRedirections = 6;
            request.Timeout = 10000;
            request.UserAgent = RequesterDefaults.UserAgent;

            using (var response = (HttpWebResponse) request.GetResponse())
            using (var stream = response.GetResponseStream())
                if (stream == null)
                {
                    throw new NoNullAllowedException("Stream returned Null");
                }
                else
                {
                    using (var reader = new StreamReader(stream))
                    {
                        html = reader.ReadToEnd();
                    }
                }

            if (string.IsNullOrWhiteSpace(html) || !html.Contains(siteSignature))
            {
                return (html, false);
            }

            return (html, true);
        }
    }
}