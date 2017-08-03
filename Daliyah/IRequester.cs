// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="IRequester.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using Daliyah.Requester;
using System.Net;

namespace Daliyah
{
    /// <summary>
    /// Interface IRequester
    /// </summary>
    public interface IRequester
    {
        /// <summary>
        /// Downloads the HTML asynchronous.
        /// </summary>
        /// <param name="siteUrl">The URL.</param>
        /// <param name="sitePageType">Type of the page.</param>
        /// <param name="siteSignature">The siteSignature.</param>
        /// <param name="proxy">The proxy.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        (string html, bool isSuccessful) DownloadHtml(string siteUrl, PageType sitePageType,
            string siteSignature, WebProxy proxy);
    }
}