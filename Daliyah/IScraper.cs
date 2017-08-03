// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="IScraper.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading.Tasks;

namespace Daliyah
{
    /// <summary>
    /// Interface IScraper
    /// </summary>
    public interface IScraper
    {
        /// <summary>
        /// Occurs when [scraping finished].
        /// </summary>
        event EventHandler ScrapingFinished;

        /// <summary>
        /// Starts the site inspection asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StartSiteInspectionAsync();

        /// <summary>
        /// Starts the site scraping asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StartSiteScrapingAsync();

        /// <summary>
        /// Generates the report asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task GenerateReportAsync();
    }
}