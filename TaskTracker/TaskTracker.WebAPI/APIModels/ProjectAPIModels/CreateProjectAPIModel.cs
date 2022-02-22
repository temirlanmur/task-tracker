namespace TaskTracker.WebAPI.APIModels.ProjectAPIModels
{
    public class CreateProjectAPIModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }

        public CreateProjectAPIModel(string name) { Name = name; }
    }
}
