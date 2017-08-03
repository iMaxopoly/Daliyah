// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 08-01-2017
//
// Last Modified By : kryptodev
// Last Modified On : 08-01-2017
// ***********************************************************************
// <copyright file="Settings.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net;

namespace Daliyah
{
    /// <summary>
    /// Class Settings.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// Gets or sets the save path.
        /// </summary>
        /// <value>The save path.</value>
        public string SavePath { get; set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Delilah";

        /// <summary>
        /// Gets the reports path.
        /// </summary>
        /// <value>The reports path.</value>
        public string ReportsPath => SavePath + "\\Reports";

        /// <summary>
        /// Gets the debug path.
        /// </summary>
        /// <value>The debug path.</value>
        public string DebugPath => SavePath + "\\Debug";

        /// <summary>
        /// Gets or sets the proxy list.
        /// </summary>
        /// <value>The proxy list.</value>
        public List<WebProxy> ProxyList { get; set; }

        /// <summary>
        /// Gets the proxy count.
        /// </summary>
        /// <value>The proxy count.</value>
        public int ProxyCount => ProxyList?.Count ?? 0;
    }
}