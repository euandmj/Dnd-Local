using DndL.Core.Model;

namespace DndL.Client.Extensions
{
    public static class DrawnLine_PointPacket_ConversionExtensions
    {
        public static PointPacket ToPointPacket(this DrawnLine dl)
        {
            var pp = new PointPacket
            {
                StrokeBrush = dl.StrokeBrush,
                StrokeThickness = dl.StrokeThickness,
                Id = dl.ID.ToString()
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
                StrokeThickness = pp.StrokeThickness,
                ID = System.Guid.Parse(pp.Id)
            };
    }
}
