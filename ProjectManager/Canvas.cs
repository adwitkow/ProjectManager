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

        public event EventHandler ImageChanged;
        public event EventHandler ViewChanged;

        public Point BoundMouseLocation { get; private set; }

        public float ZoomLevel { get; set; }
        public new int HorizontalScroll { get => this.HorizontalScrollBar.Value; }
        public new int VerticalScroll { get => this.VerticalScrollBar.Value; }
        public int ViewportWidth { get; private set; }
        public int ViewportHeight { get; private set; }

        private Image _image;

        public Canvas()
        {
            InitializeComponent();

            this.ZoomLevel = 1f;
            this.DoubleBuffered = true;
        }

        protected void OnImageChanged(EventArgs e)
        {
            ImageChanged?.Invoke(this, e);

            OnViewChanged(EventArgs.Empty);

            UpdateScrollbars();
            Invalidate();
        }

        protected void OnViewChanged(EventArgs e)
        {
            ViewChanged?.Invoke(this, e);

            ViewportWidth = this.Width - SystemInformation.VerticalScrollBarWidth;
            ViewportHeight = this.Height - SystemInformation.HorizontalScrollBarHeight;

            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var x = e.X;
            var y = e.Y;
            var maxX = Math.Abs((int)((Image.Width - HorizontalScroll) * ZoomLevel));
            var maxY = Math.Abs((int)((Image.Height - VerticalScroll) * ZoomLevel));

            var clampedX = x.Clamp(0, maxX);
            var clampedY = y.Clamp(0, maxY);

            BoundMouseLocation = new Point(clampedX, clampedY);

            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintZoomedVisibleImage(e.Graphics);

            base.OnPaint(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

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

            OnViewChanged(EventArgs.Empty);
        }

        protected override void OnResize(EventArgs e)
        {
            if (Image != null)
            {
                UpdateScrollbars();
                OnViewChanged(EventArgs.Empty);
            }
            base.OnResize(e);
        }

        private void HorizontalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            OnViewChanged(EventArgs.Empty);
        }

        private void VerticalScrollBar_ValueChanged(object sender, EventArgs e)
        {
            OnViewChanged(EventArgs.Empty);
        }

        private void ScrollBar_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
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
                ViewportWidth,
                ViewportHeight);

            RectangleF sourceRect = new RectangleF(
                HorizontalScroll,
                VerticalScroll,
                ViewportWidth / ZoomLevel,
                ViewportHeight / ZoomLevel);
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
            var vMax = (int)Math.Max(0, Image.Height - ViewportHeight / ZoomLevel);
            var hMax = (int)Math.Max(0, Image.Width - ViewportWidth / ZoomLevel);

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
    }
}
