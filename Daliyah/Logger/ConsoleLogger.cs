// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-18-2017
// ***********************************************************************
// <copyright file="ConsoleLogger.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;

namespace Daliyah.Logger
{
    /// <summary>
    /// Class ConsoleLogger.
    /// </summary>
    /// <seealso cref="Daliyah.ILogger" />
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// The synchronize lock
        /// </summary>
        private readonly object _syncLock = new object();

        /// <summary>
        /// Logs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="type">The type.</param>
        public void Log(string message, LogType type)
        {
            string msgtype;
            try
            {
                msgtype = LoggerUtils.CheckLogType(type);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            }

            lock (_syncLock)
            {
                Console.WriteLine($@"{msgtype} | {DateTime.UtcNow}: {message}");
            }
        }
    }
}