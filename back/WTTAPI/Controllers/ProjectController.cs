using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WTTAPI.Models;

namespace WTTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private static List<ProjectDetail> ProjectDetails = new List<ProjectDetail>
        {

        };
        private readonly PresenceDetailContext _dbContext;
        public ProjectController(PresenceDetailContext dataContext)
        {
            _dbContext = dataContext;
        }


        [HttpGet]
        public async Task<ActionResult<List<ProjectDetail>>> Get()
        {
            return Ok(await _dbContext.ProjectDetails.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<ProjectDetail>>> Get(int id)
        {
            var project = await _dbContext.ProjectDetails.FindAsync(id);
            if (project == null)
                return BadRequest("Not Found");

            return Ok(project);
        }


        [HttpPost]
        public async Task<ActionResult<List<ProjectDetail>>> AddProject(AddProject project)
        {

            var newProject = new ProjectDetail
            {
                Name = project.Name,
                Requester = project.Requester
            };

            _dbContext.ProjectDetails.Add(newProject);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.ProjectDetails.ToListAsync());
        }



        [HttpPut]
        public async Task<ActionResult<ProjectDetail>> UpdateProject(UpdateProject request)
        {
            var project = await _dbContext.ProjectDetails.FindAsync(request.PId);
            if (project == null)
                return BadRequest("Not Found");

            project.Name = request.Name;
            project.Requester = request.Requester;

            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.ProjectDetails.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectDetail>>> Delete(int id)
        {
            var dbProject = await _dbContext.ProjectDetails.FindAsync(id);
            if (dbProject == null)
                return BadRequest("Not Found");

            _dbContext.ProjectDetails.Remove(dbProject);
            await _dbContext.SaveChangesAsync();

            return Ok(await _dbContext.ProjectDetails.ToListAsync());
        }



    }
}
