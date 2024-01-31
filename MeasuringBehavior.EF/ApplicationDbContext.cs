using MeasuringBehavior.Core.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeasuringBehavior.EF
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Question> Questions { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Village> Village { get; set; }
    }
}
