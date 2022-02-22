using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using TaskTracker.WebAPI.APIModels;
using TaskTracker.WebAPI.APIModels.ProjectAPIModels;
using TaskTracker.WebAPI.APIModels.TaskItemAPIModels;
using Microsoft.AspNetCore.Mvc;

namespace TaskTracker.WebAPI.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }        

        [HttpGet("{projectId:int}")]
        public ActionResult<ProjectAPIModel> GetById(int projectId)
        {
            try
            {
                var project = _projectRepository.GetById(projectId);
                if (project == null)
                    return NotFound();

                var result = ProjectAPIModel.FromProject(project);                

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorAPIModel(ex.Message));
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListProjectAPIModel>> GetAll()
        {
            try
            {
                var projects = _projectRepository.GetAll();

                var result =
                    projects
                        .Select(p => ListProjectAPIModel.FromProject(p))
                        .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorAPIModel(ex.Message));
            }
        }

        [HttpPost]
        public ActionResult<CreateProjectAPIModel> CreateProject([FromBody]CreateProjectAPIModel model)
        {
            try
            {
                var project = new Project(model.Name);

                project.Description = model.Description;
                project.Priority = model.Priority;
                project.SetStartDate(model.StartDate);
                project.SetCompletionDate(model.CompletionDate);

                _projectRepository.Add(project);

                return CreatedAtAction(nameof(GetById), new { projectId = project.Id }, model);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorAPIModel(ex.Message));
            }
        }

        [HttpPut("{projectId:int}")]
        public ActionResult<ProjectAPIModel> UpdateProject(int projectId, [FromBody]UpdateProjectAPIModel model)
        {
            try
            {
                var project = _projectRepository.GetById(projectId);
                if (project == null)
                    return NotFound();

                project.Name = model.Name;
                project.Description = model.Description;
                project.SetStartDate(model.StartDate);
                project.SetCompletionDate(model.CompletionDate);
                project.SetStatus(model.Status);
                project.Priority = model.Priority;

                _projectRepository.Update(project);

                return Ok(ProjectAPIModel.FromProject(project));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorAPIModel(ex.Message));
            }
        }

        [HttpDelete("{projectId:int}")]
        public IActionResult DeleteProject(int projectId)
        {
            try
            {
                var project = _projectRepository.GetById(projectId);
                if (project == null)
                    return NotFound();

                _projectRepository.Delete(projectId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorAPIModel(ex.Message));
            }
        }
    }
}
