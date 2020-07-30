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
                _image = value;
                OnImageChanged(EventArgs.Empty);
            }
        }
        public float ZoomLevel { get; private set; }

        public event EventHandler ImageChanged;

        private int CanvasWidth { get => this.Width - SystemInformation.VerticalScrollBarWidth; }
        private int CanvasHeight { get => this.Height - SystemInformation.HorizontalScrollBarHeight; }
        private new int HorizontalScroll { get => this.HorizontalScrollBar.Value; }
        private new int VerticalScroll { get => this.VerticalScrollBar.Value; }

        private readonly ZoneFacade ZoneFacade;

        private Image _image;

        public Canvas()
        {
            InitializeComponent();

            this.ZoomLevel = 1f;

            this.DoubleBuffered = true;
            this.ZoneFacade = new ZoneFacade();
            //this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        protected void OnImageChanged(EventArgs e)
        {
            UpdateScrollbars();
            Invalidate();
            ImageChanged?.Invoke(this, e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            // TODO: Instead of painting a new zone, we may want to move/resize an existing zone
            ZoneFacade.StartPaintingZone(e.Location);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var location = e.Location;
            if (!ZoneFacade.UpdatePaintingZone(location))
            {
                Cursor = ZoneFacade.GetCursor(location);
            }
            else
            {
                Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            ZoneFacade.CreateNewZone(ZoomLevel, new Point(HorizontalScroll, VerticalScroll));
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintZoomedVisibleImage(e.Graphics);
            ZoneFacade.PaintZones(e.Graphics);
            base.OnPaint(e);
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
            ZoneFacade.ResizeRectangles(ZoomLevel, new Point(HorizontalScroll, VerticalScroll));
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
            ZoneFacade.ResizeRectangles(ZoomLevel, new Point(HorizontalScroll, VerticalScroll));
            Invalidate();
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            ZoneFacade.ResizeRectangles(ZoomLevel, new Point(HorizontalScroll, VerticalScroll));
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
            graphics.InterpolationMode = InterpolationMode.Bilinear;

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
                scrollbar.Enabled = false;
            }
            else
            {
                var largeChange = (int)Math.Max(10, maxSize / ZoomLevel);
                scrollbar.Maximum = maxSize + largeChange;
                scrollbar.SmallChange = maxSize / 20;
                scrollbar.LargeChange = largeChange;
                scrollbar.Value = VerticalScrollBar.Value.Clamp(0, maxSize);
                scrollbar.Enabled = true;
            }
        }
    }
}
