// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-12-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="IDataDumper.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Daliyah
{
    /// <summary>
    /// Interface IDataDumper
    /// </summary>
    public interface IDataDumper
    {
        /// <summary>
        /// Writes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="filePath">The file path.</param>
        void Write(string data, string filePath);
    }
}