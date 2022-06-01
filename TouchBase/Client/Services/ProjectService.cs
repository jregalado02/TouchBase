using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using TouchBase.Model;

namespace TouchBase.Client.Services
{
    public class ProjectService : IProjectService
    {
        private readonly HttpClient _http;

        public ProjectService(HttpClient http)
        {
            _http = http;
        }

        public List<ProjectModel> Projects { get; set; } = new List<ProjectModel>();
        public List<ProjectCollectionModel> ProjectCollections { get; set; } = new List<ProjectCollectionModel>();

        public async Task<ProjectCollectionModel> GetProjectCollectionModel(string companyName)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ProjectCollectionModel>("api/ProjectCollection?companyName=" + companyName);
                return result;
            }
            catch
            {
                return null;
            }

        }

        public async Task<ProjectCollectionModel> GetProjectCollectionModelFromId(int id)
        {
            try
            {
                var result = await _http.GetFromJsonAsync<ProjectCollectionModel>($"api/ProjectCollection/{id}");
                if (result != null)
                { return result; }
                throw new Exception("No Collection Found :{");
                
            }

            catch
            {
                return null;
            }
        }

       

        public async Task SaveModel(ProjectModel projectModel)
        {
            var result = await _http.PutAsync("api/Project", SerializeContent(projectModel));
        }

        public async Task EditCollectionModel(ProjectCollectionModel projectCollectionModel)
        {
            var result = await _http.PutAsJsonAsync("api/ProjectCollection",projectCollectionModel);
        }

        public async Task CreateModel(ProjectModel projectModel)
        {
            var result = await _http.PostAsync("api/Project", SerializeContent(projectModel));
            
        }

        public async Task CreateProjectCollectionModel(ProjectCollectionModel projectCollectionModel)
        {
            if (projectCollectionModel == null)
            {
                throw new ArgumentNullException(nameof(projectCollectionModel));
            }

            var result = await _http.PostAsJsonAsync<ProjectCollectionModel>("api/ProjectCollection", projectCollectionModel);
        }


        public async Task DeleteModel(int id )
        {
            
            
           var result = await _http.DeleteAsync($"api/Project/{id}");
            
        }

        private HttpContent SerializeContent(ProjectModel model)
        {
            _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            var content = new StringContent(JsonSerializer.Serialize(model, serializerOptions), Encoding.UTF8, "application/json");

            return content;
        }

        



       
    }
}
