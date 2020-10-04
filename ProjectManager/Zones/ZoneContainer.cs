using ProjectManager.Model;
using ProjectManager.Zones.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zones
{
    class ZoneContainer
    {
        public readonly IList<Zone> Zones;

        public ZoneContainer()
        {
            Zones = new List<Zone>();
        }

        public void CreateDesk(Rectangle rectangle)
        {
            Zones.Add(new DeskZone(rectangle));
        }

        public void CreateTeam(string name, Rectangle rectangle)
        {
            Zones.Add(new TeamZone(name, rectangle));
        }
    }
}
