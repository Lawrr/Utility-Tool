using System;
using System.Windows.Forms;

namespace UtilityTool {
    public static class Extensions {

        /// <summary>
        /// Invoke thread-safe calls to windows forms controls.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="action"></param>
        public static void InvokeSafe(this Control control, Action action) {
            if (control != null && !control.IsDisposed) {
                if (control.InvokeRequired) {
                    control.Invoke(action);
                } else {
                    action();
                }
            }
        }

        /// <summary>
        /// Shows and activates form.
        /// </summary>
        /// <param name="form"></param>
        public static void ShowActivate(this Form form) {
            if (!form.Visible) {
                form.Show();
            }

            if (form.WindowState == FormWindowState.Minimized) {
                form.WindowState = FormWindowState.Normal;
            }

            form.BringToFront();
            form.Activate();
        }

    }
}
