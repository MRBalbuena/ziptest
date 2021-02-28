using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Zip.Backend.Data
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Guest> GuestBook { get; set; }
        public DbSet<Gallery> Gallery { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(guest =>
            {
                guest.HasKey(i => i.Id);
                guest.Property(i => i.Created)
                    .IsConcurrencyToken()
                    .IsRequired();
            });
            modelBuilder.Entity<Gallery>(gallery =>
              {

                gallery.HasKey(i => i.Id);
                gallery.Property(i => i.Created)
                    .IsConcurrencyToken()
                    .IsRequired();
            });
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
      
    }

    public class Guest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
    }

    public class Gallery
    {
        public Guid Id { get; set; }
        public string Url { get; set; }        
        public DateTime Created { get; set; }
    }
}
