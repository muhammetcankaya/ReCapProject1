using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProject:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB ;Database=ReCapProject;Trusted_Connection=true ");
        }
        //Burada bizim nesneler veri tabanıyla eşledik
        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Rentals> Rentals { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasKey(u => u.UserId); // Users için birincil anahtar

            modelBuilder.Entity<Customers>()
                .HasKey(c => c.CustomerId); // Customers için birincil anahtar

            modelBuilder.Entity<Rentals>()
                .HasKey(r => r.RentId); // Rentals için birincil anahtar

            // İlişkileri tanımla
            modelBuilder.Entity<Customers>().HasKey(c => c.CustomerId);


        }

    }
}
