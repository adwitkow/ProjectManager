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
        public FloorplanEditor() : this(Resources.Floorplan) { }

        public FloorplanEditor(Image image)
        {
            InitializeComponent();

            FloorplanCanvas.Image = image;

            ZoneTypeComboBox.SelectedIndex = 0;
        }
    }
}
