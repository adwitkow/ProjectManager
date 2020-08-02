using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Drawing
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
            return RectanglePainter.UpdatePosition(mousePosition);
        }

        public Rectangle? CreateZoneRectangle(float zoomFactor, Point offset)
        {
            var newRectangle = RectanglePainter.GetCurrentNativeRectangle(zoomFactor, offset);
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

        public void ResizeRectangles(IEnumerable<Rectangle> nativeRectangles, float zoomFactor, Point offset)
        {
            Rectangles.Clear();
            foreach (var rectangle in nativeRectangles)
            {
                var x = (int)((rectangle.X * zoomFactor) - (offset.X * zoomFactor));
                var y = (int)((rectangle.Y * zoomFactor) - (offset.Y * zoomFactor));
                var w = (int)(rectangle.Width * zoomFactor);
                var h = (int)(rectangle.Height * zoomFactor);
                Rectangles.Add(new Rectangle(x, y, w, h));
            }
        }
    }
}
