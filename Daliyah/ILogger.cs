// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 06-12-2017
// ***********************************************************************
// <copyright file="ILogger.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using Daliyah.Logger;

namespace Daliyah
{
    /// <summary>
    /// Interface ILogger
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        void Log(string message, LogType type);
    }
}