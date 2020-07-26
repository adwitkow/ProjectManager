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

        private readonly ZoneFacade ZoneFacade;

        private readonly Image OriginalImage;
        private float ZoomFactor;

        public FloorplanEditor() : this(Resources.Floorplan) { }

        public FloorplanEditor(Image image)
        {
            InitializeComponent();

            ZoomFactor = 1;
            ZoneFacade = new ZoneFacade();

            var floorplan = image;
            OriginalImage = image;
            FloorplanCanvas.Location = FloorplanCanvasPanel.Location;
            FloorplanCanvas.Size = floorplan.Size;
            FloorplanCanvas.Image = floorplan;

            this.MouseWheel += this.FloorplanCanvas_MouseWheel;
            FloorplanCanvas.MouseWheel += this.FloorplanCanvas_MouseWheel;
            ZoneFacade.Repaint += this.ZoneFacade_Repaint;

            ZoneTypeComboBox.SelectedIndex = 0;
        }

        private void FloorplanCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            // Disable scroll bar moving
            ((HandledMouseEventArgs)e).Handled = true;
            ZoomImage(e.Delta);
        }

        private void FloorplanCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            // TODO: Instead of painting a new zone, we may want to move/resize an existing zone
            ZoneFacade.StartPaintingZone(e.Location);
        }

        private void FloorplanCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            var location = e.Location;
            if (!ZoneFacade.UpdatePaintingZone(location))
            {
                FloorplanCanvas.Cursor = ZoneFacade.GetCursor(location);
            }
        }

        private void FloorplanCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            ZoneFacade.CreateNewZone(ZoomFactor);
        }

        private void FloorplanCanvas_Paint(object sender, PaintEventArgs e)
        {
            ZoneFacade.PaintZones(e.Graphics);
        }

        private void ZoneFacade_Repaint(object sender, EventArgs e)
        {
            FloorplanCanvas.Invalidate();
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

            ZoneFacade.ResizeRectangles(ZoomFactor);

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
    }
}
