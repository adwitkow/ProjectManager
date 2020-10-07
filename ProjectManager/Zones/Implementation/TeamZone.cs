using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zones.Implementation
{
    class TeamZone : NamedZone
    {
        private static readonly Color Lime = Color.FromArgb(64, 0, 255, 0);
        private static readonly Color DarkGreen = Color.FromArgb(255, 0, 100, 0);

        public override ZoneType Type => ZoneType.Team;

        public TeamZone(string name, float scale, Rectangle rectangle, Color fillColor, Color borderColor) : base(name, scale, rectangle)
        {
            FillColor = fillColor;
            BorderColor = borderColor;
        }

        public TeamZone(string name, Rectangle rectangle) : this(name, 1f, rectangle, Lime, DarkGreen) { }

        private TeamZone() : base("", 1f, Rectangle.Empty) { }

        public override Zone Clone()
        {
            return new TeamZone(Name, Scale, Rectangle, FillColor, BorderColor);
        }
    }
}
