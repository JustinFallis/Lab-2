using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;

namespace Lab1A.Models
{
    public class Lab1AContext : DbContext
    {
        public Lab1AContext (DbContextOptions<Lab1AContext> options)
            : base(options)
        {
        }

        public DbSet<Lab1A.Models.Car> Car { get; set; }

        public DbSet<Lab1A.Models.Member> Member { get; set; }

        public DbSet<Lab1A.Models.Dealership> Dealership { get; set; }

    }
}
