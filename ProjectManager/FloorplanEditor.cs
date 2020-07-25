using ProjectManager.Properties;
using ProjectManager.Zone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager
{
    public partial class FloorplanEditor : Form
    {
        private static readonly float MinZoom = 0.5f;
        private static readonly float MaxZoom = 3f;

        private readonly RectanglePainter Painter;
        private readonly ZoneContainer ZoneContainer;

        private readonly Image OriginalImage;
        private float ZoomFactor;

        public FloorplanEditor() : this(Resources.Floorplan) { }

        public FloorplanEditor(Image image)
        {
            InitializeComponent();

            ZoomFactor = 1;
            Painter = new RectanglePainter();
            ZoneContainer = new ZoneContainer();

            var floorplan = image;
            OriginalImage = image;
            FloorplanCanvas.Size = floorplan.Size;
            FloorplanCanvas.Image = floorplan;

            this.MouseWheel += this.FloorplanCanvas_MouseWheel;
            FloorplanCanvas.MouseWheel += this.FloorplanCanvas_MouseWheel;
        }

        private void FloorplanCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            // Disable scroll bar moving
            ((HandledMouseEventArgs)e).Handled = true;
            ZoomImage(e.Delta);
        }

        private void FloorplanCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            Painter.StartDrawing(e.Location);
        }

        private void FloorplanCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            if (Painter.IsDrawing)
            {
                Painter.UpdatePosition(location);
                Repaint();
            }

            UpdateCursor(location);
        }

        private void FloorplanCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            var newRectangle = Painter.AssignNewNativeRectangle(ZoomFactor);
            if (newRectangle != default)
            {
                ZoneContainer.CreateDesk(newRectangle);
                ResizeRectangles();
                Repaint();
            }
        }

        private void FloorplanCanvas_Paint(object sender, PaintEventArgs e)
        {
            Painter.PaintRectangles(e.Graphics);
        }

        private void UpdateCursor(Point mouseLocation)
        {
            Cursor cursorCandidate;
            var crossCursor = IsMouseOverRectangle(mouseLocation);
            if (crossCursor)
            {
                cursorCandidate = Cursors.SizeAll;
            }
            else
            {
                cursorCandidate = Cursors.Default;
            }

            if (FloorplanCanvas.Cursor != cursorCandidate)
            {
                FloorplanCanvas.Cursor = cursorCandidate;
            }
        }

        private void ZoomImage(int delta)
        {
            if (delta > 0)
            {
                ZoomFactor *= 1.2f;
            }
            else
            {
                ZoomFactor *= 0.8f;
            }

            ZoomFactor = ZoomFactor.Clamp(MinZoom, MaxZoom);

            if (ZoomFactor == MinZoom || ZoomFactor == MaxZoom)
            {
                return;
            }

            ResizeRectangles();

            Size newSize = new Size((int)(OriginalImage.Width * ZoomFactor), (int)(OriginalImage.Height * ZoomFactor));

            Image originalBitmap = FloorplanCanvas.Image;
            Bitmap bmp = new Bitmap(OriginalImage, newSize);
            if (originalBitmap != OriginalImage)
            {
                originalBitmap.Dispose();
            }

            FloorplanCanvas.Size = newSize;
            FloorplanCanvas.Image = bmp;
        }

        private Rectangle GetRectangleUnderMouse(Point mouseLocation)
        {
            return Painter.Rectangles
                .Where(rect => rect.Contains(mouseLocation))
                .LastOrDefault(); // hopefully the youngest rectangle - simulating the feel of z-index when rects overlap
        }

        private bool IsMouseOverRectangle(Point mouseLocation)
        {
            return GetRectangleUnderMouse(mouseLocation) != default;
        }

        private void ResizeRectangles()
        {
            var rectangles = ZoneContainer.Zones.Select(zone => zone.Rectangle);
            Painter.ResizeRectangles(rectangles, ZoomFactor);
        }

        private void Repaint()
        {
            FloorplanCanvas.Invalidate();
        }
    }
}
