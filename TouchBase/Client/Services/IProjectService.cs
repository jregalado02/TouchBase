
using System.Net.Http.Json;
using TouchBase.Model;

namespace TouchBase.Client.Services
{
    public interface IProjectService
    {
        List<ProjectModel> Projects { get; set; }
        List<ProjectCollectionModel> ProjectCollections { get; set; }

       
        Task<ProjectCollectionModel> GetProjectCollectionModel(string companyName);

        Task<ProjectCollectionModel> GetProjectCollectionModelFromId(int id);

        Task EditCollectionModel(ProjectCollectionModel projectCollectionModel);

        Task CreateModel(ProjectModel model);

        Task CreateProjectCollectionModel(ProjectCollectionModel model);

        Task SaveModel(ProjectModel projectModel);

        Task DeleteModel(int id);


        

        
    }

    
}
