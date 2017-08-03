// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-15-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="FileWriter.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.IO;
using System.Text;

namespace Daliyah.DataDumper
{
    /// <summary>
    /// Class FileWriter.
    /// </summary>
    /// <seealso cref="Daliyah.IDataDumper" />
    internal class FileWriter : IDataDumper
    {
        private readonly object _syncLock = new object();

        /// <summary>
        /// Writes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="filePath">The file path.</param>
        public void Write(string data, string filePath)
        {
            lock (_syncLock)
            {
                filePath = Path.GetFullPath(filePath);

                var fullPathSplit = filePath.Split('\\');

                var directoryPathStringBuilder = new StringBuilder();

                for (var i = 0; i < fullPathSplit.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        directoryPathStringBuilder.Append(fullPathSplit[i]);
                        continue;
                    }

                    directoryPathStringBuilder.Append('\\' + fullPathSplit[i]);
                }

                Directory.CreateDirectory(directoryPathStringBuilder.ToString());

                var file = new StreamWriter(filePath, true);
                file.WriteLine(data);
                file.Close();
            }
        }
    }
}