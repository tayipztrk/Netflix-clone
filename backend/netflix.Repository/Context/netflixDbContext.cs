using Microsoft.EntityFrameworkCore;
using netflix.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace netflix.Repository.Context
{
    public class netflixDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<ProgramInterest> ProgramInterests { get; set; }

        public netflixDbContext(DbContextOptions<netflixDbContext> options)
         : base(options)
        {
        }
    }
}
