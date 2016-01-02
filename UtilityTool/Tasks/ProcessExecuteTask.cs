using System.Diagnostics;

namespace UtilityTool.Tasks {
    public class ProcessExecuteTask : ITask {
        private string Path;
        private bool CloseOnRun;

        public ProcessExecuteTask(string path) : this(path, false) {
        }

        public ProcessExecuteTask(string path, bool closeOnRun) {
            Path = path;
            CloseOnRun = closeOnRun;
        }

        public void Run() {
            Process.Start(Path);
            if (CloseOnRun) {
                Program.MainForm.Hide();
            }
        }
    }
}
