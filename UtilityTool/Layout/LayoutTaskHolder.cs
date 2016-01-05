using System;
using System.ComponentModel;
using UtilityTool.Tasks;

namespace UtilityTool.Layout {
    public class LayoutTaskHolder : Component, ILayoutComponent {
        public string Task { get; private set; }
        public ITask TaskInstance { get; private set; }
        public object[] Args { get; private set; }

        public void Init() {
            // Create task
            Type taskType = Type.GetType(String.Format("UtilityTool.Tasks.{0}", Task));
            // Make sure type implements ITask
            if (typeof(ITask).IsAssignableFrom(taskType)) {
                TaskInstance = ((ITask)Activator.CreateInstance(taskType, Args));
                TaskInstance.Run();
            }
        }
    }
}
