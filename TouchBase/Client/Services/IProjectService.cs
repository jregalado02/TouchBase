
using System.Net.Http.Json;
using TouchBase.Model;

namespace TouchBase.Client.Services
{
    public interface IProjectService
    {
        List<ProjectModel> Projects { get; set; }
        List<ProjectCollectionModel> ProjectCollections { get; set; }

        Task GetCollections();
        Task<ProjectCollectionModel> GetProjectCollectionModel(string companyName);

        Task<ProjectCollectionModel> GetProjectCollectionModelFromId(int id);

        Task CreateModel(ProjectModel model);

        Task SaveModel(ProjectModel projectModel);

        Task DeleteModel(int id);

        

        Task Get(int Id);
    }

    /* public interface IProjectService2<TModel>
     {

         Task<TModel> Get();
     }

     public class AbstractProjectService<TModel> : IProjectService2<TModel>
     {
         private readonly HttpClient _http;

         private string _controllerPath;

         public AbstractProjectService(HttpClient client, string controllerPath)
         {
             _http = client;
             _controllerPath = controllerPath;
         }

         public async Task<TModel> Get()
         {
             var result = await _http.GetFromJsonAsync<TModel>(_controllerPath);
             return result;
         }
     }

     public class ProjectModelService : AbstractProjectService<ProjectModel>
     {

         public ProjectModelService(HttpClient client) : base(client, "api/Project") {  }
     }

     public class ProjectCollectionModelService : AbstractProjectService<ProjectCollectionModel>
     {
         public ProjectCollectionModelService(HttpClient client) : base(client, "api/ProjectCollection") { }
     }

     public class Test
     {
         // This is a ProjectModelService
         private readonly IProjectService2<ProjectModel> _projectModelService

         public Test(IProjectService2<ProjectModel> service)
         {
             _projectModelService = service;
             //_projectModelService ??= new ProjectModelService(new HttpClient());
         }

         public async Task TestMethod()
         {
             var projectModels = await _projectModelService.Get();
         }
     }*/
}
