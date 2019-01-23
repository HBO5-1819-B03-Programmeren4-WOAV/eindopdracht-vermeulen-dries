using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DV_Prog4_EE.Domain;

namespace DV_Prog4_EE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<Group>().ToTable("Group");
        //    //modelBuilder.Entity<Event>().ToTable("Event");
        //    //modelBuilder.Entity<Invitation>().ToTable("Invitation");
        //    //modelBuilder.Ignore<ApplicationUser>();
        //}
        //public DbSet<Group> Groups { get; set; }
        //public DbSet<Event> Events { get; set; }
        //public DbSet<Invitation> Invitations { get; set; }
    }
}
