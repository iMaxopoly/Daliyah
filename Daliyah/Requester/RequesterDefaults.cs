// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-13-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-17-2017
// ***********************************************************************
// <copyright file="RequesterDefaults.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Daliyah.Requester
{
    /// <summary>
    /// Struct RequesterDefaults
    /// </summary>
    internal struct RequesterDefaults
    {
        /// <summary>
        /// The cloudflare page wait
        /// </summary>
        public const int CloudflarePageWait = 10000;

        /// <summary>
        /// The javascript page wait
        /// </summary>
        public const int JavascriptPageWait = 5000;

        /// <summary>
        /// The user agent
        /// </summary>
        public const string UserAgent =
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.115 Safari/537.36"
            ;
    }
}