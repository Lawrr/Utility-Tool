using System;
using System.Windows.Forms;
using UtilityTool.Layout;

namespace UtilityTool {
    public partial class LayoutForm : Form {
        public LayoutForm() {
            InitializeComponent();

            Icon = Properties.Resources.Icon;
        }

        public void SetLayout(LayoutDetails layout) {
            // TODO set layout
        }

        private void LayoutForm_FormLoad(object sender, EventArgs e) {
            CenterToScreen();
            BringToFront();
            Activate();
        }

        private void LayoutForm_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
            e.Cancel = true;
        }
    }
}
