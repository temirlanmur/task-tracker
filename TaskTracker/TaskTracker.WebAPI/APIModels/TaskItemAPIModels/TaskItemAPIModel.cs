using TaskTracker.Core.Entities;
using TaskTracker.Core.Enums;

namespace TaskTracker.WebAPI.APIModels.TaskItemAPIModels
{
    public class TaskItemAPIModel : UpdateTaskItemAPIModel
    {
        public int Id { get; set; }

        public TaskItemAPIModel(int id, string name) : base(name) { Id = id; }

        public static TaskItemAPIModel FromTaskItem(TaskItem taskItem)
        {
            return new TaskItemAPIModel(taskItem.Id, taskItem.Name)
            {
                Description = taskItem.Description,
                StartDate = taskItem.StartDate,
                CompletionDate = taskItem.CompletionDate,
                Status = taskItem.Status,
                Priority = taskItem.Priority
            };
        }
    }    
}
