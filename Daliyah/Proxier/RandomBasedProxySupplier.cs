// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-18-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-18-2017
// ***********************************************************************
// <copyright file="RandomBasedProxySupplier.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net;

namespace Daliyah.Proxier
{
    /// <summary>
    /// Class RandomBasedProxySupplier.
    /// </summary>
    /// <seealso cref="Daliyah.IProxier" />
    internal class RandomBasedProxySupplier : IProxier
    {
        /// <summary>
        /// The proxy list
        /// </summary>
        private readonly List<WebProxy> _proxyList;

        /// <summary>
        /// The random
        /// </summary>
        private readonly Random _random = new Random(DateTime.UtcNow.Millisecond);

        /// <summary>
        /// The synchronize lock
        /// </summary>
        private readonly object _syncLock = new object();

        public RandomBasedProxySupplier(List<WebProxy> proxyList)
        {
            _proxyList = proxyList;
        }

        public WebProxy GetProxy()
        {
            lock (_syncLock)
            {
                return _proxyList[_random.Next(_proxyList.Count)];
            }
        }
    }
}