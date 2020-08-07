using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ProjectManager.Zones;
using System.Runtime.CompilerServices;
using ProjectManager.Drawing;
using ProjectManager.Drawing.Events;

namespace ProjectManager
{
    public partial class Canvas : UserControl
    {
        private static readonly float MinZoom = 0.3f;
        private static readonly float MaxZoom = 5f;

        public Image Image {
            get => _image;
            set
            {
                if (value != null)
                { 
                    _image = value;
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        public IEnumerable<Rectangle> NativeRectangles { get; set; }
        public ICollection<Rectangle> Rectangles { get; private set; }

        public event EventHandler ImageChanged;
        public event EventHandler<RectangleEventArgs> RectangleCreated;

        private float ZoomLevel { get; set; }

        private Point BoundMouseLocation { get; set; }
        private int CanvasWidth { get => this.Width - SystemInformation.VerticalScrollBarWidth; }
        private int CanvasHeight { get => this.Height - SystemInformation.HorizontalScrollBarHeight; }
        private new int HorizontalScroll { get => this.HorizontalScrollBar.Value; }
        private new int VerticalScroll { get => this.VerticalScrollBar.Value; }

        private readonly RectanglePainter RectanglePainter;

        private Image _image;

        public Canvas()
        {
            InitializeComponent();

            this.NativeRectangles = new List<Rectangle>();
            this.Rectangles = new List<Rectangle>();
            this.ZoomLevel = 1f;

            this.DoubleBuffered = true;
            //this.SetStyle(ControlStyles.ResizeRedraw, true);

            this.RectanglePainter = new RectanglePainter();
        }

        protected void OnImageChanged(EventArgs e)
        {
            ImageChanged?.Invoke(this, e);

            UpdateScrollbars();
            Invalidate();
        }

        protected void OnRectangleCreated(RectangleEventArgs e)
        {
            RectangleCreated?.Invoke(this, e);

            MoveResizeRectangles();
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // TODO: Instead of painting a new zone, we may want to move/resize an existing zone
            RectanglePainter.BeginRectangleCreation(BoundMouseLocation);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
            var maxX = Math.Abs((int)((Image.Width - HorizontalScroll) * ZoomLevel));
            var maxY = Math.Abs((int)((Image.Height - VerticalScroll) * ZoomLevel));

            var clampedX = x.Clamp(0, maxX);
            var clampedY = y.Clamp(0, maxY);

            var cursorOutOfBounds = clampedX != x || clampedY != y;

            BoundMouseLocation = new Point(clampedX, clampedY);

            if (!RectanglePainter.UpdatePosition(BoundMouseLocation))
            {
                if (cursorOutOfBounds)
                {
                    Cursor = Cursors.Default;
                }
                else
                {
                    Cursor = GetCursor(e.Location);
                }
            }
            else
            {
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        private void ScrollBar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            var rect = RectanglePainter.FinishRectangleCreation();
            if (rect != default)
            {
                OnRectangleCreated(new RectangleEventArgs(ConvertRectangleToNative(rect)));
            }
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintZoomedVisibleImage(e.Graphics);
            var bounds = new Rectangle(0, 0, CanvasWidth, CanvasHeight);
            // bounds.Contains(rect)
            var visibleRectangles = Rectangles.Where(rect => bounds.IntersectsWith(rect));
            RectanglePainter.PaintRectangles(e.Graphics, visibleRectangles.ToArray());

            var originalFont = new Font("Arial Black", 24 * ZoomLevel, FontStyle.Bold, GraphicsUnit.Point);
            var format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Far;
            foreach (var rectangle in visibleRectangles)
            {
                var x = rectangle.X;
                var y = rectangle.Y;
                var width = rectangle.Width;
                var height = rectangle.Height;

                var font = GetAdjustedFont(e.Graphics, "DebugTeam", originalFont, width, height, 6);
                e.Graphics.DrawString("DebugTeam", font, Brushes.Black, new RectangleF(x, y, width, height), format);
            }

            base.OnPaint(e);
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

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                ZoomLevel /= 0.8f;
            }
            else
            {
                ZoomLevel *= 0.8f;
            }

            ZoomLevel = ZoomLevel.Clamp(MinZoom, MaxZoom);

            UpdateScrollbars();
            MoveResizeRectangles();
            Invalidate();
            base.OnMouseWheel(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Image != null)
            {
                UpdateScrollbars();
                Invalidate();
            }
            base.OnResize(e);
        }

        private void HorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            MoveResizeRectangles();
            Invalidate();
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            MoveResizeRectangles();
            Invalidate();
        }

        private void PaintZoomedVisibleImage(Graphics graphics)
        {
            if (Image == null)
            {
                return;
            }

            var compositingMode = graphics.CompositingMode;
            var interpolationMode = graphics.InterpolationMode;
            graphics.CompositingMode = CompositingMode.SourceCopy;

            if (ZoomLevel > 1)
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            }
            else
            {
                graphics.InterpolationMode = InterpolationMode.Low;
            }

            RectangleF destinationRect = new RectangleF(
                0,
                0,
                CanvasWidth,
                CanvasHeight);

            RectangleF sourceRect = new RectangleF(
                HorizontalScroll,
                VerticalScroll,
                CanvasWidth / ZoomLevel,
                CanvasHeight / ZoomLevel);
            graphics.DrawImage(
                Image,
                destinationRect,
                sourceRect,
                GraphicsUnit.Pixel);

            graphics.InterpolationMode = interpolationMode;
            graphics.CompositingMode = compositingMode;
        }

        private void UpdateScrollbars()
        {
            var vMax = (int)Math.Max(0, Image.Height - CanvasHeight / ZoomLevel);
            var hMax = (int)Math.Max(0, Image.Width - CanvasWidth / ZoomLevel);

            UpdateScrollBar(VerticalScrollBar, vMax);
            UpdateScrollBar(HorizontalScrollBar, hMax);
        }

        private void UpdateScrollBar(ScrollBar scrollbar, int maxSize)
        {
            if (maxSize == 0)
            {
                scrollbar.Value = 0;
                scrollbar.Enabled = false;
            }
            else
            {
                var largeChange = (int)Math.Max(10, maxSize / ZoomLevel);
                scrollbar.Maximum = maxSize + largeChange;
                scrollbar.SmallChange = maxSize / 20;
                scrollbar.LargeChange = largeChange;
                scrollbar.Value = Math.Abs(scrollbar.Value.Clamp(0, maxSize));
                scrollbar.Enabled = true;
            }
        }

        private void MoveResizeRectangles()
        {
            Rectangles.Clear();
            foreach (var rectangle in NativeRectangles)
            {
                var x = (int)((rectangle.X - HorizontalScroll) * ZoomLevel);
                var y = (int)((rectangle.Y - VerticalScroll) * ZoomLevel);
                var w = (int)(rectangle.Width * ZoomLevel);
                var h = (int)(rectangle.Height * ZoomLevel);
                Rectangles.Add(new Rectangle(x, y, w, h));
            }
        }

        private Rectangle GetTopRectangleAtPosition(Point position)
        {
            return Rectangles
                .Where(rect => rect.Contains(position))
                .LastOrDefault(); // hopefully the youngest rectangle - simulating the feel of z-index when rects overlap
        }

        private Cursor GetCursor(Point position)
        {
            var crossCursor = GetTopRectangleAtPosition(position) != default;

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

        private Rectangle ConvertRectangleToNative(Rectangle rectangle)
        {
            var x1 = (int)(rectangle.Left / ZoomLevel + HorizontalScroll);
            var x2 = (int)(rectangle.Right / ZoomLevel + HorizontalScroll);
            var y1 = (int)(rectangle.Top / ZoomLevel + VerticalScroll);
            var y2 = (int)(rectangle.Bottom / ZoomLevel + VerticalScroll);

            return new Rectangle(
                Math.Min(x1, x2),
                Math.Min(y1, y2),
                Math.Abs(x1 - x2),
                Math.Abs(y1 - y2));
        }
    }
}
