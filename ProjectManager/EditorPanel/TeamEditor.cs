using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManager.Model;

namespace ProjectManager.EditorPanel
{
    public partial class TeamEditor : ZoneEditor
    {
        public TeamEditor()
        {
            InitializeComponent();
        }

        public override void Link(Zone zone)
        {
            if (zone.Type != Zones.ZoneType.Team)
            {
                throw new ArgumentException("Provided zone is not a TeamZone", nameof(zone));
            }

            TeamNameTextBox.DataBindings.Clear();
            LabelScaleUpDown.DataBindings.Clear();

            TeamNameTextBox.DataBindings.Add("Text", zone, "Name", false, DataSourceUpdateMode.OnPropertyChanged);
            LabelScaleUpDown.DataBindings.Add("Value", zone, "Scale", false, DataSourceUpdateMode.OnPropertyChanged);

            base.Link(zone);
        }
    }
}
