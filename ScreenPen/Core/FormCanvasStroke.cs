using ScreenPen.GUI;
using System.Drawing;

namespace ScreenPen.Core
{
    public class FormCanvasStroke
    {
        private readonly FormCanvas _Canvas;
        private readonly Stroke _Stroke;

        public FormCanvasStroke(Pen pen, Point InitialPoint, FormCanvas Canvas)
        {
            _Canvas = Canvas;
            _Stroke = new Stroke(pen, InitialPoint);
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
