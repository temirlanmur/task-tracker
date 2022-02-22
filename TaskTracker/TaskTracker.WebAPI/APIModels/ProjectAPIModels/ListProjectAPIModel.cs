using TaskTracker.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.WebAPI.APIModels.ProjectAPIModels
{
    public class ListProjectAPIModel : UpdateProjectAPIModel
    {        
        public int Id { get; set; }
        
        public ListProjectAPIModel(int id, string name) : base(name) { Id = id; }

        public static ListProjectAPIModel FromProject(Project project)
        {
            var model = new ListProjectAPIModel(project.Id, project.Name)
            {
                Description = project.Description,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };            

            return model;
        }
    }
}
