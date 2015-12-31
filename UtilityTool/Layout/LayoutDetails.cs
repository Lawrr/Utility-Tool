using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UtilityTool.Layout {
    public class LayoutDetails {
        public string Text { get; private set; }  = String.Format("{0} {1}", Application.ProductName, Application.ProductVersion);
        public int Width { get; private set; }  = 300;
        public int Height { get; private set; }  = 300;
        public IContainer Components { get; private set; } = new Container();

        public void Add(IComponent component) {
            Components.Add(component);
        }
    }
}
