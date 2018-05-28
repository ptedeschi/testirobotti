//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Instituto de Pesquisas Eldorado">
//     Copyright (c) Instituto de Pesquisas Eldorado. All rights reserved.
// </copyright>
// <author>Patrick Tedeschi</author>
//-----------------------------------------------------------------------

using BotTester.View;

namespace BotTester
{
    using System;
    using System.Windows.Forms;

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
            Application.Run(new MainForm());
        }
    }
}