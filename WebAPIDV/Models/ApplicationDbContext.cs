using Prog5_eindopdracht_DV.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebAPIDV.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users")
                .HasData();
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Invitation>().ToTable("Invitation");
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
    }
}