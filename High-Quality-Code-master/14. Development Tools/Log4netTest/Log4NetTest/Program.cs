﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

//Here is the once-per-application setup information
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetTest
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
            Application.Run(new MainForm());
        }
    }
}
