namespace TaskTracker.WebAPI.APIModels.TaskItemAPIModels
{
    public class CreateTaskItemAPIModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Priority { get; set; }

        public CreateTaskItemAPIModel(string name) { Name = name; }       
    }
}
