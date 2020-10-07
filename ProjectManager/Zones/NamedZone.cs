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
        public float Scale
        {
            get => _scale;
            set
            {
                _scale = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _name;
        private float _scale = 1f;

        protected NamedZone(string name, float scale, Rectangle rectangle) : base(rectangle)
        {
            this.Name = name;
            this.Scale = scale;
        }
    }
}
