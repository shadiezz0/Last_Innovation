using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class InnovationDbContext : DbContext
    {
        public InnovationDbContext(DbContextOptions<InnovationDbContext> options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<MyWorks> MyWorks { get; set; }
        public DbSet<MyServices> myServices { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();
        }
    }
}
