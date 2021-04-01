using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffWebAPi.Models;

namespace StaffWebAPi.Data
{
    public class StaffWebAPiContext : DbContext
    {
        public StaffWebAPiContext (DbContextOptions<StaffWebAPiContext> options)
            : base(options)
        {
        }

        public DbSet<StaffWebAPi.Models.StaffName> StaffName { get; set; }
    }
}
