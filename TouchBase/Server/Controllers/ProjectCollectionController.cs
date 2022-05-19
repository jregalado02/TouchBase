using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TouchBase.Data;
using TouchBase.Model;

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





    }
}
