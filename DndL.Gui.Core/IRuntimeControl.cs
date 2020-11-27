namespace DndL.Gui.Core
{
    public interface IRuntimeControl
    {
        public int Column { get; }
        public int Row { get; }
        public int? ColumnSpan { get; }
        public int? RowSpan { get; }
    }
}
