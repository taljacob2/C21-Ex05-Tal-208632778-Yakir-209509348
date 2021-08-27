﻿using System;
using System.Windows.Forms;
using WindowsFormsUI.Com.Team.Form.Game;

namespace WindowsFormsUI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // TODO : remove console, and set this project as WindowsApplication.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }
}
