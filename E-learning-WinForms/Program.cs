﻿using System;
using System.Windows.Forms;

namespace E_learning_WinForms
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Source + e.Message);
            }
        }
    }
}
