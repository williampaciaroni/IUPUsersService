using System;
using IUPUsersService.Models;
using Microsoft.EntityFrameworkCore;

namespace IUPUsersService.Context
{
    public class IUPUsersContext : DbContext
    {
        public DbSet<AppIdentity> AppIdentities { get; set; }
        public DbSet<User> Users { get; set; }

        public IUPUsersContext()
        { }

        public IUPUsersContext(DbContextOptions<IUPUsersContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //OneToOne AppIdentity and User
            modelBuilder.Entity<AppIdentity>()
                    .HasOne(aI => aI.User)
                    .WithOne(u => u.AppIdentity)
                    .HasForeignKey<User>(u => u.AppIdentityRef)
                    .OnDelete(DeleteBehavior.Restrict);

            //AppIdentityRef field unique for Users
            modelBuilder.Entity<User>()
                    .HasIndex(u => u.AppIdentityRef)
                    .IsUnique();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            builder.UseLazyLoadingProxies();
        }
    }
}
