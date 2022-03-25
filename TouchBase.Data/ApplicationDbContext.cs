using Microsoft.EntityFrameworkCore;
using TouchBase.Model;
namespace TouchBase.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProjectModel> DBProjects { get; set; }
        public DbSet<ProjectCollectionModel> DBProjectCollections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ProjectModel>().ToTable("Project");
            builder.Entity<ProjectCollectionModel>().ToTable("ProjectCollection");
        }
    }
}