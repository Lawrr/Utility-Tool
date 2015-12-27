﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace UtilityTool {
    public static class Program {
        // Static objects
        public static MainForm MainForm { get; private set; }
        public static Tray Tray { get; private set; }
        public static HotKeyHandler HotKeyHandler { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            bool firstInstance;
            Mutex mutex = new Mutex(true, "aaebf427-11d2-4266-ad81-d2f2676c7404", out firstInstance);
            if (!firstInstance) {
                MessageBox.Show(String.Format("An instance of {0} is already running", Application.ProductName));
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();
            Tray = new Tray();
            HotKeyHandler = new HotKeyHandler();

            // Event handlers
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

            // Start application
            Application.Run(MainForm);
        }

        private static void Application_ApplicationExit(object sender, EventArgs e) {
            // Make it so the icon doesnt stay when exiting the program
            Tray.TrayIcon.Visible = false;
        }
    }
}
