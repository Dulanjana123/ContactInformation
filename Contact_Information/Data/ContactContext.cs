using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contact_Information.Model;

namespace Contact_Information.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.ToTable("Contacts");
                entity.HasOne(a => a.Countries);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasOne(a => a.Location);
            });
        }



    }
}
