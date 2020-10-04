using ProjectManager.Model;
using ProjectManager.Zones;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager
{
    class ProjectContext : DbContext
    {
        public DbSet<Desk> Desks { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Zone> Zones { get; set; }
    }
}
