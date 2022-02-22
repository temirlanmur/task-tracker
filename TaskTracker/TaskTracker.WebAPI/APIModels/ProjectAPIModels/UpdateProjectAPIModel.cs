using TaskTracker.Core.Enums;

namespace TaskTracker.WebAPI.APIModels.ProjectAPIModels
{
    public class UpdateProjectAPIModel : CreateProjectAPIModel
    {
        public ProjectStatus Status { get; set; }

        public UpdateProjectAPIModel(string name) : base(name) { }
    }
}
