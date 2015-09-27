using System;
using System.Windows.Forms;

namespace UtilityTool {
    static class Program {

        // The form which is opened by clicking the tray icon
        public static MainForm MainForm { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainForm = new MainForm();

            Application.Run(MainForm);
        }
    }
}
