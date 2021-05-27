using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2.Models
{
    public class Lab2Context : DbContext
    {
        public virtual DbSet<University> University { get; set; }
        public virtual DbSet<Campus> Campus { get; set; }
        public virtual DbSet<Dormitory> Dormitory { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }

        public virtual DbSet<Blok> Blok { get; set; }
        public virtual DbSet<Room> Room { get; set; }

        public Lab2Context(DbContextOptions<Lab2Context> options)
            : base(options)
        { 
            Database.EnsureCreated();
        }
    }
}
