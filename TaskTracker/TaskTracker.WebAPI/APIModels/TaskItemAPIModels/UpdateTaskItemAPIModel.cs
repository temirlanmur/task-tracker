using TaskTracker.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.WebAPI.APIModels.TaskItemAPIModels
{
    public class UpdateTaskItemAPIModel : CreateTaskItemAPIModel
    {        
        public TaskItemStatus Status { get; set; }

        public UpdateTaskItemAPIModel(string name) : base(name) { }
    }
}
