using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class InnovationDbContext : DbContext
    {
        public InnovationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<MyWorks> MyWorks { get; set; }
        public DbSet<MyServices> myServices { get; set; }
    }
}
