using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zones.Implementation
{
    class DeskZone : Zone
    {
        private static readonly Color Gold = Color.FromArgb(128, 255, 215, 0);
        private static readonly Color DarkOrange = Color.FromArgb(255, 255, 140, 0);

        public DeskZone(Rectangle rectangle, Color fillColor, Color borderColor) : base(rectangle)
        {
            FillColor = fillColor;
            BorderColor = borderColor;
        }

        public DeskZone(Rectangle rectangle) : this(rectangle, Gold, DarkOrange) { }

        private DeskZone() { }

        public override Zone Clone()
        {
            return new DeskZone(Rectangle, FillColor, BorderColor);
        }
    }
}
