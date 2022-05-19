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

            var projectCollectionModel = new ProjectCollectionModel 
            { 
                ProjectCollectionModelId = 1, 
                CompanyName = "Great Lakes Cloud Solutions, LLC" 
            };

            var projectModel = new ProjectModel
            {
                ProjectCollectionModelId = 1,
                ProjectModelId = 1,
                Approximation = "Your Mom",
                Description = "Stuff and things",
                IsDone = false,
                Name = "First Model"
                //ProjectCollectionModel = projectCollectionModel
            };

            builder.Entity<ProjectCollectionModel>().HasData(projectCollectionModel);
            builder.Entity<ProjectModel>().HasData(projectModel);
        }
    }
}