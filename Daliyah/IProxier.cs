// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 06-12-2017
// ***********************************************************************
// <copyright file="IProxier.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Net;

namespace Daliyah
{
    /// <summary>
    /// Interface IProxier
    /// </summary>
    public interface IProxier
    {
        WebProxy GetProxy();
    }
}