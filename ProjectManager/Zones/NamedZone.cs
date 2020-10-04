using ProjectManager.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zones
{
    abstract class NamedZone : Zone
    {
        public string Name { get; private set; }

        protected NamedZone(string name, Rectangle rectangle) : base(rectangle)
        {
            this.Name = name;
        }
    }
}
