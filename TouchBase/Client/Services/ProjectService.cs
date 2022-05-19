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

        public async Task<ProjectCollectionModel> Get2(string companyName)
        {
            //https://www.youtube.com/watch
            //https://www.youtube.com/watch?v=SG3v8vxCYFU
            //https://www.youtube.com/watch?v=SG3v8vxCYFU&a=aksldjkfl
            // two query params= v and a

            //https://localhost.com/api/ProjectCollection?comapnyName=
            var result = await _http.GetFromJsonAsync<ProjectCollectionModel>("api/ProjectCollection?companyName=" + companyName);
            return result;
        }

        public async Task SaveModel(ProjectModel projectModel)
        {
            _http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            var serializerOptions = new JsonSerializerOptions();
            serializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
            var content = new StringContent(JsonSerializer.Serialize(projectModel, serializerOptions),Encoding.UTF8,"application/json");
            var result = await _http.PutAsync("api/Project", content);
        }

        public async Task CreateModel(ProjectModel projectModel)
        {
            var result = _http.PostAsJsonAsync("api/Project", projectModel);
        }



        public Task Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task GetCollections()
        {
            throw new NotImplementedException();
        }
    }
}
