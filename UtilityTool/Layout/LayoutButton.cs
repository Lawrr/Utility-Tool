﻿using System;
using System.Windows.Forms;
using UtilityTool.Tasks;

namespace UtilityTool.Layout {
    public class LayoutButton : Button, ILayoutControl {
        public string Control { get; private set; }
        public string Task { get; private set; }
        public ITask TaskInstance { get; private set; }
        public object[] Args { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Init() {
            // Create on click event handler
            Type taskType = Type.GetType(String.Format("UtilityTool.Tasks.{0}", Task));
            // Make sure type implements ITask
            if (typeof(ITask).IsAssignableFrom(taskType)) {
                TaskInstance = ((ITask)Activator.CreateInstance(taskType, Args));
                Click += (sender, e) => {
                    TaskInstance.Run();
                };
            }

            // Set location with x and y
            Location = new System.Drawing.Point(X, Y);
        }
    }
}
