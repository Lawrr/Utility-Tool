using System;
using System.Windows.Forms;
using UtilityTool.Tasks;

namespace UtilityTool.Layout {
    public class LayoutButton : Button, ILayoutControl {
        public string Type { get; private set; }
        public string Task { get; private set; }
        public object[] Args { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init() {
            // Create on click event handler
            Type taskType = System.Type.GetType(String.Format("UtilityTool.Tasks.{0}", Task));
            // Make sure type implements ITask
            if (typeof(ITask).IsAssignableFrom(taskType)) {
                Click += (sender, e) => {
                    ((ITask)Activator.CreateInstance(taskType, Args)).Run();
                };
            }

            // Set location with x and y
            Location = new System.Drawing.Point(X, Y);
        }
    }
}
