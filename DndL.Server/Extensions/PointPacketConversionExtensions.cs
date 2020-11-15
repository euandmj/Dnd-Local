using DndL.Core.Model;

namespace DndL.Server.Extensions
{
    public static class PointPacketConversionExtensions
    {
        public static PointPacket ToPointPacket(this DrawnLine dl)
        {
            var pp = new PointPacket
            {
                StrokeBrush = dl.StrokeBrush,
                StrokeThickness = dl.StrokeThickness
            };

            pp.X.AddRange(dl.X);
            pp.Y.AddRange(dl.Y);

            return pp;
        }

        public static DrawnLine ToDrawnLine(this PointPacket pp)
            => new DrawnLine
            {
                X = pp.X,
                Y = pp.Y,
                StrokeBrush = pp.StrokeBrush,
                StrokeThickness = pp.StrokeThickness
            };

    }
}
