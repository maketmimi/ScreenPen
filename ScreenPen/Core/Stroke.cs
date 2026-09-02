using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System;
using System.Drawing.Drawing2D;

namespace ScreenPen.Core
{
    public class Stroke
    {

        private static readonly Pen _SharedPen = new Pen(Color.Black, 5)
        {
            LineJoin = System.Drawing.Drawing2D.LineJoin.Round,
            StartCap = System.Drawing.Drawing2D.LineCap.Round,
            EndCap = System.Drawing.Drawing2D.LineCap.Round
        };

        private List<Point> _LPoints = new List<Point>();
        private StrokePen StrokePenInfo { set; get; }
        private readonly CompositingMode _GraphicsCompositingMode;
        public int PointsCount
        {
            get
            {
                return _LPoints.Count;
            }
        }

        public Stroke(StrokePen strokePen, Point InitialPoint, CompositingMode compositingMode)
        {
            _LPoints.Add(InitialPoint);
            StrokePenInfo = strokePen;
            _GraphicsCompositingMode = compositingMode;
        }

        public void AddPoint(Point PointToAdd)
        {
            _LPoints.Add(PointToAdd);
        }

        public void DrawLastSegment(Graphics graphics)
        {
            StrokePenInfo.CustomizePenToMatchThisStrokePen(_SharedPen);
            graphics.CompositingMode = _GraphicsCompositingMode;

            if (_LPoints.Count > 1)
                graphics.DrawLine(_SharedPen, _LPoints[_LPoints.Count - 2], _LPoints.Last());
        }

        public void DrawFullStroke(Graphics graphics)
        {
            //for (int i = 0; i < _LPoints.Count - 1; i++)
            //    graphics.DrawLine(StrokePen, _LPoints[i], _LPoints[i + 1]);
            graphics.CompositingMode = _GraphicsCompositingMode;

            StrokePenInfo.CustomizePenToMatchThisStrokePen(_SharedPen);
            if (_LPoints.Count > 1)
                graphics.DrawLines(_SharedPen, _LPoints.ToArray());
        }
    }
}
