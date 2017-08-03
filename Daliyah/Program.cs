// ***********************************************************************
// Assembly         : Daliyah
// Author           : kryptodev
// Created          : 06-10-2017
//
// Last Modified By : kryptodev
// Last Modified On : 06-23-2017
// ***********************************************************************
// <copyright file="Program.cs" company="kryptodev">
//     Copyright © kryptodev.com 2017
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Windows.Forms;

// Daliyah is named in light of the 4-year-old girl Daliyah Marie Arana who has read over 1000 books.
namespace Daliyah
{
    /// <summary>
    /// Class Program.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui());
        }
    }
}