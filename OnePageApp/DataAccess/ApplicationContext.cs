using Microsoft.EntityFrameworkCore;
using OnePageApp.Entities;

namespace OnePageApp.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<Service> Services { get; set; }
        public DbSet<About> Abouts { get; set; }
    }
}
