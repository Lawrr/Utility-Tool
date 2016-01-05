using System.ComponentModel;
using UtilityTool.Tasks;

namespace UtilityTool.Layout {
    public interface ILayoutComponent : IComponent {
        string Task { get; }
        ITask TaskInstance { get; }
        object[] Args { get; }
        void Init();
    }
}
