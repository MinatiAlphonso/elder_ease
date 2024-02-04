using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ElderEase.Models;

namespace ElderEase.Data
{
    public class ElderEaseContext : DbContext
    {
        public ElderEaseContext (DbContextOptions<ElderEaseContext> options)
            : base(options)
        {
        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Client> Client { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>().ToTable("Provider");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Client>().ToTable("Client");
        }
    }
}
