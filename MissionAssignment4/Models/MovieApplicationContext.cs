using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MissionAssignment4.Models
{
    public class MovieApplicationContext : DbContext
    {
        // Constructor
        public MovieApplicationContext (DbContextOptions<MovieApplicationContext> options) : base(options)
        {
            // leave it blank for now
        }

        public DbSet<MovieApplicationResponse> Responses { get; set; }
    }
}
