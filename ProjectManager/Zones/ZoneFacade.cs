using ProjectManager.Drawing;
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
        public IEnumerable<Zone> Zones { get => ZoneContainer.Zones; }

        private readonly ZoneContainer ZoneContainer;

        public ZoneFacade()
        {
            ZoneContainer = new ZoneContainer();
        }

        public void CreateNewZone(ZoneType type, Rectangle newZoneRectangle)
        {
            switch (type)
            {
                case ZoneType.Desk:
                    ZoneContainer.CreateDesk(newZoneRectangle);
                    break;
                case ZoneType.Team:
                    ZoneContainer.CreateTeam("Team", newZoneRectangle);
                    break;
                default:
                    break;
            }
        }
    }
}
