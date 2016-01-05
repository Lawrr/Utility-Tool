using System;
using System.Windows.Forms;

namespace UtilityTool.Tasks {
    public class BalloonTipTask : ITask {
        public int TipTimeout { get; private set; }
        public string TipTitle { get; private set; }
        public string TipText { get; private set; }
        public ToolTipIcon TipIcon { get; private set; }

        public BalloonTipTask(long tipTimeout, string tipTitle, string tipText, string tipIcon)
            : this((int)tipTimeout, tipTitle, tipText, tipIcon) {
        }

        public BalloonTipTask(int tipTimeout, string tipTitle, string tipText, string tipIcon) {
            TipTimeout = tipTimeout;
            TipTitle = tipTitle;
            TipText = tipText;
            try {
                TipIcon = (ToolTipIcon)Enum.Parse(typeof(ToolTipIcon), tipIcon);
            } catch (ArgumentException) {
                TipIcon = ToolTipIcon.None;
            }
        }

        public void Run() {
            Program.Tray.TrayIcon.ShowBalloonTip(TipTimeout, TipTitle, TipText, TipIcon);
        }
    }
}
