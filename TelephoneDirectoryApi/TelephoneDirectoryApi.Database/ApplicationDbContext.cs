using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelephoneDirectoryApi.Models;

namespace TelephoneDirectoryApi.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EntryInTelephoneDirectory> TelephoneDirectory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            GenerateTelephoneDirectory(modelBuilder);
        }

        private void GenerateTelephoneDirectory(ModelBuilder builder)
        {
            var telephoneDirectory1 = new EntryInTelephoneDirectory() { Id = Guid.NewGuid(), Name = "Antek", Surname = "Kowalski", City = "Warszawa", Street = "Wodna", StreetNumber = "35b", Number = 455433212 };
            var telephoneDirectory2 = new EntryInTelephoneDirectory() { Id = Guid.NewGuid(), Name = "Marek", Surname = "Nowak", City = "Bielsko-Biała", Street = "Kryształowa", StreetNumber = "34a", Number = 123456788 };

            builder.Entity<EntryInTelephoneDirectory>().HasData(
                telephoneDirectory1,
                telephoneDirectory2
            );
        }
    }
}
