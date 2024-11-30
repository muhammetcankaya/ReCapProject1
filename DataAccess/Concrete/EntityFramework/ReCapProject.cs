using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapProject:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB ;Database=ReCapProject1;Trusted_Connection=true ");
        }
        //Burada bizim nesneler veri tabanıyla eşledik
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users için birincil anahtar
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            // Customers için birincil anahtar
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            // Rentals için birincil anahtar
            modelBuilder.Entity<Rental>()
                .HasKey(r => r.RentId);

            // Cars için birincil anahtar
            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarId); // CarId, Car tablosundaki birincil anahtar

            // İlişkileri tanımla

            // User ile Customer arasında bire-bir ilişki (1:1)
            modelBuilder.Entity<Customer>()
                .HasOne<User>() // Customer'ın bir User'ı olacak
                .WithOne() // User'ın bir Customer'ı olacak
                .HasForeignKey<Customer>(c => c.UserId); // Foreign key UserId olacak

            // Customer ile Rental arasında bire-çok ilişki (1:N)
            modelBuilder.Entity<Rental>()
                .HasOne<Customer>() // Rental'ın bir Customer'ı olacak
                .WithMany() // Customer birden fazla Rental'a sahip olabilir
                .HasForeignKey(r => r.CustomerId); // Foreign key CustomerId olacak

            // User ile Rental arasında bire-çok ilişki (1:N)
            modelBuilder.Entity<Rental>()
                .HasOne<User>() // Rental'ın bir User'ı olacak
                .WithMany() // User birden fazla Rental'a sahip olabilir
                .HasForeignKey(r => r.UserId); // Foreign key UserId olacak

            // Car ile Rental arasında bire-çok ilişki (1:N)
            modelBuilder.Entity<Rental>()
                .HasOne<Car>() // Rental'ın bir Car'ı olacak
                .WithMany() // Car birden fazla Rental'a sahip olabilir
                .HasForeignKey(r => r.CarId); // Foreign key CarId olacak
        }


    }
}
