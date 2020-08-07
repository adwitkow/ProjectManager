using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Drawing.Events
{
    public class RectangleEventArgs : EventArgs
    {
        public Rectangle Rectangle { get; set; }

        public RectangleEventArgs() { }

        public RectangleEventArgs(Rectangle rectangle)
        {
            this.Rectangle = rectangle;
        }
    }
}
