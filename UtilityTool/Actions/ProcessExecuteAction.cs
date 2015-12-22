using System.Diagnostics;

namespace UtilityTool.Events {
    public class ProcessExecuteEvent {

        public ProcessExecuteEvent(string path) {
            Process.Start(@path);
        }

    }
}
