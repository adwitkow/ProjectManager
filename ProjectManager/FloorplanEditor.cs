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
        private readonly ZoneFacade zoneFacade;

        public FloorplanEditor() : this(Resources.Floorplan) { }

        public FloorplanEditor(Image image)
        {
            InitializeComponent();

            FloorplanCanvas.Image = image;

            zoneFacade = new ZoneFacade();

            ZoneTypeComboBox.DataSource = Enum.GetValues(typeof(ZoneType));
            ZoneTypeComboBox.SelectedIndex = 0;
        }

        private void FloorplanCanvas_RectangleCreated(object sender, Drawing.Events.RectangleEventArgs e)
        {
            var selectedZoneType = (ZoneType)ZoneTypeComboBox.SelectedItem;
            zoneFacade.CreateNewZone(selectedZoneType, e.Rectangle);
            FloorplanCanvas.NativeRectangles = zoneFacade.Zones.Select(zone => zone.Rectangle);
        }
    }
}
