using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ScreenPen.Core
{
    public class Stroke
    {
        public Stroke(Pen pen, Point InitialPoint)
        {
            _LPoints.Add(InitialPoint);
            StrokePen = pen;
        }

        private List<Point> _LPoints = new List<Point>();
        public Pen StrokePen { get; set; }
        public Color StrokeColor
        {
            get { return StrokePen.Color; }

            set
            {
                StrokePen.Color = value;
            }
        }

        public void AddPoint(Point PointToAdd)
        {
            _LPoints.Add(PointToAdd);
        }

        public void DrawLastSegment(Graphics graphics)
        {
            if (_LPoints.Count > 1)
                graphics.DrawLine(StrokePen, _LPoints[_LPoints.Count - 2], _LPoints.Last());
        }

        public void DrawFullStroke(Graphics graphics)
        {
            //for (int i = 0; i < _LPoints.Count - 1; i++)
            //    graphics.DrawLine(StrokePen, _LPoints[i], _LPoints[i + 1]);

            if (_LPoints.Count > 1)
                graphics.DrawLines(StrokePen, _LPoints.ToArray());

        }
    }
}
