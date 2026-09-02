using ScreenPen.GUI;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ScreenPen.Core
{
    public class FormCanvasStroke
    {
        private readonly FormCanvas _Canvas;
        private readonly Stroke _Stroke;
        public int PointsCount
        {
            get
            {
                return _Stroke.PointsCount;
            }
        }


        public FormCanvasStroke(StrokePen strokePen, Point InitialPoint, FormCanvas Canvas, CompositingMode compositingMode)
        {
            _Canvas = Canvas;
            _Stroke = new Stroke(strokePen, InitialPoint, compositingMode);
        }

        public void AddPoint(Point PointToAdd)
        {
            _Stroke.AddPoint(PointToAdd);
        }

        public void DrawLastSegment()
        {
            _Stroke.DrawLastSegment(_Canvas.CanvasBitmapGraphics);
        }

        public void DrawFullStroke()
        {
            _Stroke.DrawFullStroke(_Canvas.CanvasBitmapGraphics);
        }
    }
}
