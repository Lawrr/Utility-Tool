using System.Diagnostics;

namespace UtilityTool.Tasks {
    public class ProcessExecuteTask {
        public ProcessExecuteTask(string path) {
            Process.Start(path);
        }
    }
}
