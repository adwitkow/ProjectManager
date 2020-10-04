using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
    class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual List<Person> Members { get; set; }
    }
}
