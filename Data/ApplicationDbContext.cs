using ProjectTask.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectTask.Models;

namespace ProjectTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {

        }
        public DbSet<Project> projects { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Tasks> tasks { get; set; }
    }
}
