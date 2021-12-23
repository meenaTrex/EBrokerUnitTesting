using Microsoft.EntityFrameworkCore;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryManagement
{
    public class TraderContext : DbContext
    {
        public TraderContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Trader> Traders { get; set; }
        public DbSet<Fund> Funds { get; set; }
        public DbSet<TraderEquity> TraderEquities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Trader>().HasData(
                new Trader { TraderId = 1, Name = "Chris" },
                new Trader { TraderId = 2, Name = "Alisha" },
                new Trader { TraderId = 3, Name = "Dodger" }
            ) ;
            modelBuilder.Entity<Fund>().HasData(
               new Fund { Id = 1, TraderId = 1, Amount = 200000 },
               new Fund { Id = 2, TraderId = 2, Amount = 1500000 },
               new Fund { Id = 3, TraderId = 3, Amount = 250000 }
           );
        }
    }

}
