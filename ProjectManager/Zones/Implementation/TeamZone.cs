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

        public TeamZone(string name, Rectangle rectangle) : base(name, rectangle)
        {
            FillColor = Lime;
            BorderColor = DarkGreen;
        }

        private TeamZone() : base("", Rectangle.Empty) { }

        public override Zone Clone()
        {
            return new TeamZone(Name, Rectangle);
        }
    }
}
