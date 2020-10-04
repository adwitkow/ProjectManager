using ProjectManager.Drawing;
using ProjectManager.Model;
using ProjectManager.Zones.Implementation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManager.Zones
{
    class ZoneFacade
    {
        // TODO: Rename this class...

        public IList<Zone> Zones { get; }

        public ZoneFacade()
        {
            Zones = new List<Zone>();
        }

        public Zone CreateNewZone(ZoneType type, Rectangle newZoneRectangle)
        {
            Zone zone;
            switch (type)
            {
                case ZoneType.Desk:
                    zone = new DeskZone(newZoneRectangle);
                    break;
                case ZoneType.Team:
                    zone = new TeamZone("Team", newZoneRectangle);
                    break;
                default:
                    throw new InvalidOperationException("Trying to create a zone with invalid ZoneType");
            }

            Zones.Add(zone);

            return zone;
        }
    }
}
