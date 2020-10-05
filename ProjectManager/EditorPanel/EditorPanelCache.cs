using ProjectManager.Model;
using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.EditorPanel
{
    class EditorPanelCache
    {
        private DeskEditor deskEditor;
        private TeamEditor teamEditor;

        public ZoneEditor RequestEditor(Zone zone)
        {
            ZoneEditor result;
            var type = zone.Type;
            switch (type)
            {
                case ZoneType.Desk:
                    if (deskEditor == null)
                    {
                        deskEditor = new DeskEditor();
                    }
                    result = deskEditor;
                    break;
                case ZoneType.Team:
                    if (teamEditor == null)
                    {
                        teamEditor = new TeamEditor();
                    }
                    result = teamEditor;
                    break;
                default:
                    throw new InvalidOperationException("Requesting a ZoneEditor for a Zone of invalid ZoneType");
            }
            result.Link(zone);
            return result;
        }
    }
}
