using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TouchBase.Data;
using TouchBase.Model;



namespace TouchBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var pjects = await _context.DBProjects.ToListAsync();
            return Ok(pjects);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(int id)
        {
            var pject = await _context.DBProjects.FindAsync(id);
            if (pject == null)
            {
                return NotFound("No project found. :(");
            }
            return Ok(pject);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProjectCollectionModel([FromBody] ProjectModel projectModel)
        {
            var toTrack = await _context.DBProjects
                .FirstOrDefaultAsync(x => x.ProjectModelId == projectModel.ProjectModelId);

            _context.Entry(toTrack).CurrentValues.SetValues(projectModel);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddProjectModel([FromBody] ProjectModel modelToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var collection = await _context.DBProjectCollections.FirstOrDefaultAsync(m => m.ProjectCollectionModelId == modelToAdd.ProjectCollectionModelId);

            modelToAdd.ProjectCollectionModel = collection;
            modelToAdd.ProjectCollectionModelId = collection.ProjectCollectionModelId;

            _context.DBProjects.Add(modelToAdd);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProjectModel(int id)
        {
            var model  = await _context.DBProjects
                .FirstOrDefaultAsync(x => x.ProjectModelId == id);
            _context.DBProjects.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
