using System;

namespace DndL.Gui.Core.Modes
{
    public class CanvasModeChangedEventArgs
        : EventArgs
    {
        public CanvasMode OldMode { get; }
        public CanvasMode NewMode { get; }

        public CanvasModeChangedEventArgs(CanvasMode old, CanvasMode @new)
            => (OldMode, NewMode) = (old, @new);
    }
}
