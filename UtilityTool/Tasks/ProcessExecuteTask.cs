using System.Diagnostics;

namespace UtilityTool.Tasks {
    public class ProcessExecuteTask : ITask {
        private string Path;

        public ProcessExecuteTask(string path) {
            Path = path;
        }

        public void Run() {
            Process.Start(Path);
        }
    }
}
