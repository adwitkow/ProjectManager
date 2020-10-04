using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Model
{
    class Desk
    {
        public int Id { get; set; }
        public virtual Zone Zone { get; set; }
        [Required]
        public virtual Person Owner { get; set; }

        public virtual List<string> Appliances { get; set; }
    }
}
