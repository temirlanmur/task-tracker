using TaskTracker.Core.Enums;

namespace TaskTracker.Core.Entities
{
    public class Project : BaseEntity
    {       
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        private DateTime? _startDate;       
        public DateTime? StartDate => _startDate;
        private DateTime? _completionDate;       
        public DateTime? CompletionDate => _completionDate;
        private ProjectStatus _status;
        public ProjectStatus Status => _status;
        public int Priority { get; set; }
        public List<TaskItem> TasksItems { get; internal set; } = new();

        public Project(string name) { Name = name; }        

        /// <summary>
        /// Sets the start date for the project, given that the passed value is valid
        /// </summary>
        /// <param name="startDate">Start date to set</param>
        /// <exception cref="ArgumentOutOfRangeException">If the date is not valid</exception>
        public void SetStartDate(DateTime? startDate)
        {
            if (startDate == null)
                _startDate = null;
            else if (_completionDate == null || startDate < _completionDate) 
                _startDate = startDate;
            else
                throw new ArgumentOutOfRangeException("Project's start date has to be earlier than its completion date");
        }

        /// <summary>
        /// Sets the completion date for the project, given that the passed value is valid
        /// </summary>
        /// <param name="completionDate">Completion date to set</param>
        /// <exception cref="ArgumentOutOfRangeException">If the date is not valid</exception>
        public void SetCompletionDate(DateTime? completionDate)
        {
            if (completionDate == null)
                _completionDate = null;
            else if (_startDate == null || completionDate > _startDate)
                _completionDate = completionDate;
            else
                throw new ArgumentOutOfRangeException("Project's completion date has to be later than its start date");
        }

        /// <summary>
        /// Encapsulates the logic for setting the project's status
        /// </summary>
        public void SetStatus(ProjectStatus status)
        {
            if (status == ProjectStatus.Completed)
            {
                foreach (var task in TasksItems)
                    task.Status = TaskItemStatus.Done;
            }
            _status = status;            
        }

        /// <summary>
        /// Adds the task to the project
        /// </summary>
        /// <param name="task">Task to add</param>
        /// <exception cref="ArgumentException">If the task is already present</exception>
        public void AddTask(TaskItem task)
        {
            if (TasksItems.Any(t => t.Id == task.Id))
                throw new ArgumentException("You are trying to add the task that the project already contains");
            TasksItems.Add(task);            
        }

        /// <summary>
        /// Removes the task from the project and returns it
        /// </summary>
        /// <param name="taskId">Id of the task to remove</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">If the task with the passed id is not present in the project</exception>
        public TaskItem RemoveTask(int taskId)
        {
            var task = TasksItems.FirstOrDefault(t => t.Id == taskId);
            if (task == null)
                throw new ArgumentException("The project does not contain a task with the given id");
            TasksItems.Remove(task);            
            return task;
        }        
    }
}
