using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager.Zone
{
    class ZoneFacade
    {
        public event EventHandler Repaint;

        private readonly ZoneContainer ZoneContainer;
        private readonly ZonePainter ZonePainter;

        public ZoneFacade()
        {
            ZoneContainer = new ZoneContainer();
            ZonePainter = new ZonePainter();
        }

        public void StartPaintingZone(Point location)
        {
            ZonePainter.StartPaintingZone(location);
        }

        public bool UpdatePaintingZone(Point location)
        {
            if (ZonePainter.UpdatePaintingZone(location))
            {
                CallRepaint();
                return true;
            }
            return false;
        }

        public void CreateNewZone(float zoomFactor)
        {
            var newZoneRectangle = ZonePainter.CreateZoneRectangle(zoomFactor);
            if (newZoneRectangle != null)
            {
                ZoneContainer.CreateDesk(newZoneRectangle.Value);
                ResizeRectangles(zoomFactor);
                CallRepaint();
            }
        }

        public void PaintZones(Graphics graphics)
        {
            ZonePainter.PaintZones(graphics);
        }

        public Rectangle GetTopRectangleAtPosition(Point position)
        {
            return ZonePainter.Rectangles
                .Where(rect => rect.Contains(position))
                .LastOrDefault(); // hopefully the youngest rectangle - simulating the feel of z-index when rects overlap
        }

        public void ResizeRectangles(float zoomFactor)
        {
            var rectangles = ZoneContainer.Zones.Select(zone => zone.Rectangle);
            ZonePainter.ResizeRectangles(rectangles, zoomFactor);
        }

        public Cursor GetCursor(Point position)
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

        private void CallRepaint()
        {
            Repaint?.Invoke(this, EventArgs.Empty);
        }
    }
}
