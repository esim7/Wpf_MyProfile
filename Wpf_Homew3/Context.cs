using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wpf_Homew3
{
    public class Context : DbContext
    {
        private readonly string connectionString;
        public Context(/*string connectionString*/)
        {
            //this.connectionString = connectionString;
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-RM1NBDJ;Database=MyCabinet;Trusted_Connection=True;");
        }
    }
}
