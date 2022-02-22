using TaskTracker.Core.Entities;
using TaskTracker.Core.Enums;
using TaskTracker.WebAPI.APIModels.TaskItemAPIModels;

namespace TaskTracker.WebAPI.APIModels.ProjectAPIModels
{
    public class ProjectAPIModel : ListProjectAPIModel
    {        
        public List<TaskItemAPIModel>? Tasks { get; set; }

        public ProjectAPIModel(int id, string name) : base(id, name) { }
        
        public static new ProjectAPIModel FromProject(Project project)
        {
            var model = new ProjectAPIModel(project.Id, project.Name)
            {
                Description = project.Description,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };

            model.Tasks = 
                project.TasksItems
                    .Select(t => TaskItemAPIModel.FromTaskItem(t))
                    .ToList();

            return model;
        }
    }               
}
