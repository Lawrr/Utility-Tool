using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace UtilityTool.Layout {
    public partial class LayoutForm : Form {
        public LayoutForm(LayoutDetails layoutDetails) {
            InitializeComponent();

            Icon = Properties.Resources.Icon;

            SetLayout(layoutDetails);
        }

        public void SetLayout(LayoutDetails layoutDetails) {
            // Go through each property and set the value
            foreach (PropertyInfo prop in layoutDetails.GetType().GetProperties()) {
                // Special case for components
                if (prop.Name == "Components") {
                    AddComponents((IContainer)prop.GetValue(layoutDetails));
                } else {
                    this.SetProperty(prop.Name, prop.GetValue(layoutDetails));
                }
            }
        }
        
        public void AddComponents(IContainer container) {
            // Add each component from the container
            foreach (IComponent component in container.Components) {
                // Check if component is a ILayoutControl which needs initializing
                if (component is ILayoutControl) {
                    ((ILayoutControl)component).Init();
                }
                // Check if component is a control which needs to be added
                if (component is Control) {
                    Controls.Add((Control)component);
                }
            }
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
