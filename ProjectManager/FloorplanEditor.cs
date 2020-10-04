using ProjectManager.Drawing;
using ProjectManager.EditorPanel;
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
            CanvasZonePainter = new CanvasZonePainter(ZoneFacade, FloorplanCanvas, new RectanglePainter());
            CanvasZonePainter.RectangleCreated += this.CanvasZonePainter_RectangleCreated;
        }

        private void CanvasZonePainter_RectangleCreated(object sender, Drawing.Events.RectangleEventArgs e)
        {
            SideControlPanel.Controls.Clear();

            var selectedZoneType = ZoneType.Desk;//(ZoneType)ZoneTypeComboBox.SelectedItem;
            var zone = ZoneFacade.CreateNewZone(selectedZoneType, e.Rectangle);

            var editor = new ZoneEditor(zone);
            editor.Modified += this.Editor_Modified;
            SideControlPanel.Controls.Add(editor);
        }

        private void Editor_Modified(object sender, EventArgs e)
        {
            CanvasZonePainter.UpdateZones();
        }
    }
}
