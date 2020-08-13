using ProjectManager.Drawing;
using ProjectManager.Properties;
using ProjectManager.Zones;
using ProjectManager.Zones.Implementation;
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
        private readonly ZoneFacade ZoneFacade;
        private readonly CanvasZonePainter CanvasZonePainter;

        public FloorplanEditor() : this(Resources.Floorplan) { }

        public FloorplanEditor(Image image)
        {
            InitializeComponent();

            FloorplanCanvas.Image = image;

            ZoneFacade = new ZoneFacade();
            CanvasZonePainter = new CanvasZonePainter(FloorplanCanvas, new RectanglePainter());
            CanvasZonePainter.RectangleCreated += this.CanvasZonePainter_RectangleCreated;

            ZoneTypeComboBox.DataSource = Enum.GetValues(typeof(ZoneType));
            ZoneTypeComboBox.SelectedIndex = 0;
        }

        private void CanvasZonePainter_RectangleCreated(object sender, Drawing.Events.RectangleEventArgs e)
        {
            var selectedZoneType = (ZoneType)ZoneTypeComboBox.SelectedItem;
            ZoneFacade.CreateNewZone(selectedZoneType, e.Rectangle);

            CanvasZonePainter.Zones = ZoneFacade.Zones;
        }
    }
}
