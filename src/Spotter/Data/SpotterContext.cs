using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Spotter.Models;

namespace Spotter.Data
{
    public class SpotterContext : DbContext
    {
        public SpotterContext(DbContextOptions<SpotterContext> options)
            : base(options)
        {
        }

        public DbSet<Plane> Plane { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>().ToTable("Plane");
        }

#if DEBUG
        /// <summary>
        /// Initialize a small data set for testing purposes. This is only use in debug mode only.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(SpotterContext context)
        {
            if (context.Plane.Any())
            {
                return;
            }

            context.Plane.Add(new Plane
            {
                Make = "Boeing",
                Model = "777-300ER",
                Registration = "G-RNAC",
                Location = "London Gatwick",
                SeenDateTime = DateTime.Now.AddDays(-2)
            });
            context.SaveChanges();
        }
#endif
    }
}
