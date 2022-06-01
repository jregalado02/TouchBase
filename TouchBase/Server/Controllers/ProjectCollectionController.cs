using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouchBase.Data;
using TouchBase.Model;
using System.Net;

namespace TouchBase.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectCollectionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectCollectionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetCompanyProjects([FromQuery] string companyName)
        {
            //var companyProjects = await _context.DBProjectCollections.Include(p => p.Projects).ToListAsync();

            var companyModel = await _context.DBProjectCollections.Include(p => p.ProjectModels).FirstOrDefaultAsync(c => c.CompanyName.Contains(companyName));

            return Ok(companyModel);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProjectCollectionModel(int id)
        {
            var Model = await _context.DBProjectCollections.Include(p => p.ProjectModels).FirstOrDefaultAsync(c => c.ProjectCollectionModelId == id);
            return Ok(Model);
        }

        [HttpPost]
        public async Task<IActionResult> PostProjectCollectionModel([FromBody] ProjectCollectionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DBProjectCollections.Add(model);
            await _context.SaveChangesAsync();
            return Ok();

        }

        [HttpPut]
        public async Task<IActionResult> PutProjectCollectionModel([FromBody]ProjectCollectionModel model)
        {
            var collectionToEdit = await _context.DBProjectCollections.FirstOrDefaultAsync(x => x.ProjectCollectionModelId == model.ProjectCollectionModelId);
            if (collectionToEdit is null)
            { return NotFound("No Collection Found!"); }
            _context.Entry(collectionToEdit).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
