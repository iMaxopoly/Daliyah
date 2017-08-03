// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 07-15-2017
//
// Last Modified By : kryptodev
// Last Modified On : 07-15-2017
// ***********************************************************************
// <copyright file="HashGenerator.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Security.Cryptography;
using System.Text;

namespace Daliyah
{
    /// <summary>
    /// Class HashGenerator.
    /// </summary>
    public static class HashGenerator
    {
        public static string GetCryptographicHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (var i = 0; i < data.Length; i++)
            {
                sBuilder.Append(i.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}