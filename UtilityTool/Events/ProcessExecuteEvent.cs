using System.Diagnostics;

namespace UtilityTool.Events {
    class ProcessExecuteEvent {

        public ProcessExecuteEvent(string path) {
            Process.Start(@path);
        }

    }
}
