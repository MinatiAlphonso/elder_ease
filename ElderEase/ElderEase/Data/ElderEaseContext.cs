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
            /*
            modelBuilder.Entity<Provider>().ToTable("Provider");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Client>().ToTable("Client");*/
            // Seed sample data
            modelBuilder.Entity<Provider>().HasData(
                new Provider
                {
                    Id = 1,
                    firstName = "John",
                    lastName = "Doe",
                    email = "john.doe@example.com",
                    phone = "123-456-7890",
                    city = "Cityville",
                    state = "Stateville",
                    country = "Countryland",
                    zipCode = "12345",
                    password = "hashedpassword" // Make sure to hash the password in a real scenario
                                                // Add other properties
                },
                new Provider
                {
                    Id = 2,
                    firstName = "Khushi",
                    lastName = "Patil",
                    email = "khushi.patil@example.com",
                    phone = "605-456-7890",
                    city = "Rapid City",
                    state = "SD",
                    country = "Countryland",
                    zipCode = "45123",
                    password = "hashedpassword" // Make sure to hash the password in a real scenario
                                                // Add other properties
                });

            modelBuilder.Entity<Service>().HasData(
                new Service
                {
                    Id = 1,
                    ProviderId = 1,
                    serviceType = ServiceTypes.Paid,
                    isAvailable = false,
                    serviceName = ServiceNames.HomeNurse
                },
                new Service
                {
                    Id = 2,
                    ProviderId = 1,
                    serviceType = ServiceTypes.Free,
                    isAvailable = true,
                    serviceName = ServiceNames.Driver
                },
                new Service
                {
                    Id = 3,
                    ProviderId = 2,
                    serviceType = ServiceTypes.Paid,
                    isAvailable = true,
                    serviceName = ServiceNames.CareTaker
                },
                new Service
                {
                    Id = 4,
                    ProviderId = 2,
                    serviceType = ServiceTypes.Free,
                    isAvailable = true,
                    serviceName = ServiceNames.Companion
                }
                // Add more service entries as needed
            );
        }
    }
}
