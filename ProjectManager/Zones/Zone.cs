using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Zones
{
    public abstract class Zone
    {
        public Rectangle Rectangle;

        public abstract Color FillColor { get; }
        public abstract Color BorderColor { get; }

        public Zone(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
        }
    }
}
