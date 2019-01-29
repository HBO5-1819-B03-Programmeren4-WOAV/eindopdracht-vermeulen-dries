using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DV_Prog4_EE.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DV_Prog4_EE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Group>().ToTable("Groups");
            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Invitation>().ToTable("Invitation");
            modelBuilder.Entity<Friend>().ToTable("Friends");
            modelBuilder.Entity<Event_User>().ToTable("Event_User");
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Invitation> Invitations { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Event_User> event_Users { get; set; }

        private void MapGroup(EntityTypeBuilder<Group> obj)
        {
            obj.ToTable("Group");
            obj.HasKey(c => c.Id);
            obj.HasMany(c => c.Members);

        }

        private void MapUsers(EntityTypeBuilder<AppUser> obj)
        {
            obj.ToTable("User");
            
        }
    }
}
