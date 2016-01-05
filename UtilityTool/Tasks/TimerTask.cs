using System;
using System.Timers;

namespace UtilityTool.Tasks {
    public class TimerTask : ITask {
        public Timer Timer { get; private set; }
        public ITask TaskInstance { get; private set; }
        public string RunTask { get; private set; }
        public object[] RunTaskArgs { get; private set; }

        public TimerTask(double interval, string runTask, params object[] runTaskArgs) {
            Timer = new Timer(interval);
            Timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            RunTask = runTask;
            RunTaskArgs = runTaskArgs;

            // Create task
            Type taskType = Type.GetType(String.Format("UtilityTool.Tasks.{0}", RunTask));
            // Make sure type implements ITask
            if (typeof(ITask).IsAssignableFrom(taskType)) {
                TaskInstance = ((ITask)Activator.CreateInstance(taskType, RunTaskArgs));
            }
        }

        public void Run() {
            Timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            TaskInstance.Run();
        }
    }
}
