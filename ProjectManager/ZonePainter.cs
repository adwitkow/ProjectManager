using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    class ZonePainter
    {
        public ICollection<Rectangle> Rectangles;

        private readonly RectanglePainter RectanglePainter;

        public ZonePainter()
        {
            Rectangles = new List<Rectangle>();
            RectanglePainter = new RectanglePainter();
        }

        public void StartPaintingZone(Point startPosition)
        {
            RectanglePainter.StartDrawing(startPosition);
        }

        public bool UpdatePaintingZone(Point mousePosition)
        {
            if (RectanglePainter.IsDrawing)
            {
                RectanglePainter.UpdatePosition(mousePosition);
                return true;
            }
            return false;
        }

        public Rectangle? CreateZoneRectangle(float zoomFactor)
        {
            var newRectangle = RectanglePainter.GetCurrentNativeRectangle(zoomFactor);
            if (newRectangle != default)
            {
                return newRectangle;
            }
            return null;
        }

        public void PaintZones(Graphics graphics)
        {
            RectanglePainter.PaintRectangles(graphics, Rectangles.ToArray());
        }

        public void ResizeRectangles(IEnumerable<Rectangle> nativeRectangles, float zoomFactor)
        {
            Rectangles.Clear();
            foreach (var rectangle in nativeRectangles)
            {
                var x = (int)(rectangle.X * zoomFactor);
                var y = (int)(rectangle.Y * zoomFactor);
                var w = (int)(rectangle.Width * zoomFactor);
                var h = (int)(rectangle.Height * zoomFactor);
                Rectangles.Add(new Rectangle(x, y, w, h));
            }
        }
    }
}
