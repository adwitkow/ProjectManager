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
using ProjectManager.Zones;

namespace ProjectManager.EditorPanel
{
    public partial class ZoneEditor : UserControl
    {
        public Zone Zone { get; private set; }

        public event EventHandler Modified;
        public event ZoneTypeEventHandler ZoneTypeChanged;

        public ZoneEditor()
        {
            InitializeComponent();

            var zoneTypes = Enum.GetValues(typeof(ZoneType));
            ZoneTypeComboBox.DataSource = zoneTypes;
        }

        public virtual void Link(Zone zone)
        {
            this.Zone = zone;

            XNumericUpDown.DataBindings.Clear();
            YNumericUpDown.DataBindings.Clear();
            WidthNumericUpDown.DataBindings.Clear();
            HeightNumericUpDown.DataBindings.Clear();

            zone.PropertyChanged += OnModified;

            XNumericUpDown.DataBindings.Add("Value", zone, "X", false, DataSourceUpdateMode.OnPropertyChanged);
            YNumericUpDown.DataBindings.Add("Value", zone, "Y", false, DataSourceUpdateMode.OnPropertyChanged);
            WidthNumericUpDown.DataBindings.Add("Value", zone, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            HeightNumericUpDown.DataBindings.Add("Value", zone, "Height", false, DataSourceUpdateMode.OnPropertyChanged);

            FillButton.BackColor = zone.FillColor;
            BorderButton.BackColor = zone.BorderColor;
            FillButton.Text = ColorTranslator.ToHtml(zone.FillColor);
            BorderButton.Text = ColorTranslator.ToHtml(zone.BorderColor);
        }

        public void OnModified(object sender, EventArgs e)
        {
            Modified?.Invoke(this, e);
        }

        public void OnZoneTypeChanged(object sender, ZoneTypeEventArgs e)
        {
            ZoneTypeChanged?.Invoke(this, e);
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            var chosen = ChooseColor(Zone.FillColor);
            if (Zone.FillColor == chosen)
            {
                return;
            }
            Zone.FillColor = Color.FromArgb(Zone.FillColorA, chosen);
            FillButton.BackColor = chosen;
            FillButton.Text = ColorTranslator.ToHtml(chosen);

            OnModified(this, EventArgs.Empty);
        }

        private void BorderButton_Click(object sender, EventArgs e)
        {
            var chosen = ChooseColor(Zone.BorderColor);
            if (Zone.BorderColor == chosen)
            {
                return;
            }
            Zone.BorderColor = Color.FromArgb(Zone.BorderColorA, chosen);
            BorderButton.BackColor = chosen;
            BorderButton.Text = ColorTranslator.ToHtml(chosen);

            OnModified(this, EventArgs.Empty);
        }

        private Color ChooseColor(Color current)
        {
            var dialog = new ColorDialog
            {
                Color = current
            };
            var result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                return dialog.Color;
            }
            else
            {
                return current;
            }
        }

        private void ZoneTypeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            var type = (ZoneType)ZoneTypeComboBox.SelectedItem;
            OnZoneTypeChanged(this, new ZoneTypeEventArgs(type));
        }

        public class ZoneTypeEventArgs : EventArgs
        {
            public ZoneType NewType;

            public ZoneTypeEventArgs(ZoneType newType)
            {
                this.NewType = newType;
            }
        }

        public delegate void ZoneTypeEventHandler(Object sender, ZoneTypeEventArgs e);
    }
}
