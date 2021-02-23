using System;
using Microsoft.EntityFrameworkCore;

namespace Zip.Backend.Data
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Guest> GuestBook { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(guest =>
            {
                guest.HasKey(i => i.Id);
                guest.Property(i => i.Created)
                    .IsConcurrencyToken()
                    .IsRequired();
            });
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSnakeCaseNamingConvention();
    }

    public class Guest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Created { get; set; }
    }

}