namespace UtilityTool.Layout {
    public interface ILayoutControl : ILayoutComponent {
        string Control { get; }
        int X { get; }
        int Y { get; }
    }
}
