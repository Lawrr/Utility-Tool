using System.Windows.Forms;

namespace UtilityTool.Layout {
    public class LayoutButton : Button, ILayoutControl {
        public string Type { get; private set; }
        public string Task { get; private set; }
        public string Args { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init() {
            Location = new System.Drawing.Point(X, Y);
        }
    }
}
