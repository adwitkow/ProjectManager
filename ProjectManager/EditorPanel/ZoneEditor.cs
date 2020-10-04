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
    public partial class ZoneEditor : UserControl
    {
        public Zone Zone { get; }

        public event EventHandler Modified;

        public ZoneEditor(Zone zone)
        {
            InitializeComponent();

            this.Zone = zone;

            XNumericUpDown.DataBindings.Add("Value", zone, "X", false, DataSourceUpdateMode.OnPropertyChanged);
            YNumericUpDown.DataBindings.Add("Value", zone, "Y", false, DataSourceUpdateMode.OnPropertyChanged);
            WidthNumericUpDown.DataBindings.Add("Value", zone, "Width", false, DataSourceUpdateMode.OnPropertyChanged);
            HeightNumericUpDown.DataBindings.Add("Value", zone, "Height", false, DataSourceUpdateMode.OnPropertyChanged);

            FillButton.BackColor = zone.FillColor;
            BorderButton.BackColor = zone.BorderColor;
            FillButton.Text = ColorTranslator.ToHtml(zone.FillColor);
            BorderButton.Text = ColorTranslator.ToHtml(zone.BorderColor);

            XNumericUpDown.ValueChanged += OnModified;
            YNumericUpDown.ValueChanged += OnModified;
            WidthNumericUpDown.ValueChanged += OnModified;
            HeightNumericUpDown.ValueChanged += OnModified;
        }

        public void OnModified(object sender, EventArgs e)
        {
            Modified?.Invoke(this, e);
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
    }
}
