using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zone
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
    }
}
