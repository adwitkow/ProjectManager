using ProjectManager.Drawing.Events;
using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager.Drawing
{
    class CanvasZonePainter
    {
        public event EventHandler<RectangleEventArgs> RectangleCreated;

        public IEnumerable<Zone> Zones;

        private IEnumerable<Zone> ResizedZones;

        private readonly Canvas Canvas;
        private readonly RectanglePainter RectanglePainter;

        private Point MousePosition { get; set; }

        public CanvasZonePainter(Canvas canvas, RectanglePainter rectanglePainter)
        {
            this.Canvas = canvas;
            this.RectanglePainter = rectanglePainter;

            ResizedZones = new List<Zone>();
            Zones = new List<Zone>();

            canvas.MouseDown += this.Canvas_MouseDown;
            canvas.MouseMove += this.Canvas_MouseMove;
            canvas.MouseUp += this.Canvas_MouseUp;
            canvas.Paint += this.Canvas_Paint;
            canvas.ViewChanged += this.Canvas_ViewChanged;
        }

        private void Canvas_ViewChanged(object sender, EventArgs e)
        {
            ResizedZones = ResizeZones();
            UpdateCursor(MousePosition, Canvas.BoundMouseLocation);
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            var bounds = new Rectangle(0, 0, Canvas.ViewportWidth, Canvas.ViewportHeight);
            var visibleZones = ResizedZones.Where(zone => bounds.IntersectsWith(zone.Rectangle));
            var brush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));

            var visibleRectangles = visibleZones.Select(zone => zone.Rectangle).ToArray();
            var groupedZones = visibleZones
                .GroupBy(zone => zone.FillColor)
                .Select(group => new ColoredRectangleGroup(group.Key, group.First().BorderColor, group.Select(zone => zone.Rectangle).ToArray()));
            RectanglePainter.PaintRectangles(e.Graphics, groupedZones);

            var namedZones = visibleZones.OfType<NamedZone>();

            var originalFont = new Font("Arial Black",24 * Canvas.ZoomLevel, FontStyle.Bold, GraphicsUnit.Point);
            var format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Far;
            foreach (var zone in namedZones)
            {
                var rectangle = zone.Rectangle;
                var x = rectangle.X;
                var y = rectangle.Y;
                var width = rectangle.Width;
                var height = rectangle.Height;

                var font = GetAdjustedFont(e.Graphics, zone.Name, originalFont, width, height / 2, 6);
                e.Graphics.DrawString(zone.Name, font, brush, new RectangleF(x, y, width, height), format);
            }
        }

        protected void OnRectangleCreated(RectangleEventArgs e)
        {
            RectangleCreated?.Invoke(this, e);

            ResizedZones = ResizeZones();
            Canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var rect = RectanglePainter.FinishRectangleCreation();
            if (rect != default)
            {
                OnRectangleCreated(new RectangleEventArgs(ConvertRectangleToNative(rect)));
            }
        }

        private void Canvas_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MousePosition = e.Location;
            var boundLocation = Canvas.BoundMouseLocation;
            UpdateCursor(e.Location, boundLocation);
        }

        private void Canvas_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            RectanglePainter.BeginRectangleCreation(Canvas.BoundMouseLocation);
        }

        private void UpdateCursor(Point realMousePosition, Point boundLocation)
        {
            var cursorOutOfBounds = realMousePosition.X != boundLocation.X || realMousePosition.Y != boundLocation.Y;
            if (!RectanglePainter.UpdatePosition(Canvas.BoundMouseLocation))
            {
                if (cursorOutOfBounds)
                {
                    Canvas.Cursor = Cursors.Default;
                }
                else
                {
                    Canvas.Cursor = GetCursor(realMousePosition);
                }
            }
            else
            {
                Canvas.Invalidate();
            }
        }

        private Cursor GetCursor(Point position)
        {
            var crossCursor = GetTopZoneAtPosition(position) != null;

            // TODO: We could also set the cursor to 'resize' arrow or text beam here

            Cursor cursorCandidate;
            if (crossCursor)
            {
                cursorCandidate = Cursors.SizeAll;
            }
            else
            {
                cursorCandidate = Cursors.Cross;
            }

            return cursorCandidate;
        }

        private Zone GetTopZoneAtPosition(Point position)
        {
            return ResizedZones
                .Where(zone => zone.Rectangle.Contains(position))
                .LastOrDefault(); // hopefully the youngest rectangle - simulating the feel of z-index when rects overlap
        }

        private Rectangle ConvertRectangleToNative(Rectangle rectangle)
        {
            var zoomLevel = Canvas.ZoomLevel;
            var offsetX = Canvas.HorizontalScroll;
            var offsetY = Canvas.VerticalScroll;

            var x1 = (int)(rectangle.Left / zoomLevel + offsetX);
            var x2 = (int)(rectangle.Right / zoomLevel + offsetX);
            var y1 = (int)(rectangle.Top / zoomLevel + offsetY);
            var y2 = (int)(rectangle.Bottom / zoomLevel + offsetY);

            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }

        private Font GetAdjustedFont(Graphics g, string graphicString, Font originalFont, int containerWidth, int maxFontSize, int minFontSize)
        {
            Font testFont = originalFont;
            // We utilize MeasureString which we get via a control instance           
            for (int adjustedSize = maxFontSize; adjustedSize >= minFontSize; adjustedSize--)
            {
                testFont = new Font(originalFont.Name, adjustedSize, originalFont.Style);

                // Test the string with the new size
                SizeF adjustedSizeNew = g.MeasureString(graphicString, testFont);

                if (containerWidth > Convert.ToInt32(adjustedSizeNew.Width))
                {
                    // Good font, return it
                    return testFont;
                }
            }

            return testFont;
        }

        private IEnumerable<Zone> ResizeZones()
        {
            var results = new List<Zone>();

            var zoomLevel = Canvas.ZoomLevel;
            var offsetX = Canvas.HorizontalScroll;
            var offsetY = Canvas.VerticalScroll;
            foreach (var zone in Zones)
            {
                var rectangle = zone.Rectangle;
                var x = (int)((rectangle.X - offsetX) * zoomLevel);
                var y = (int)((rectangle.Y - offsetY) * zoomLevel);
                var w = (int)(rectangle.Width * zoomLevel);
                var h = (int)(rectangle.Height * zoomLevel);
                var resizedRectangle = new Rectangle(x, y, w, h);
                var clone = zone.Clone();
                clone.Rectangle = resizedRectangle;
                results.Add(clone);
            }

            return results;
        }
    }
}
