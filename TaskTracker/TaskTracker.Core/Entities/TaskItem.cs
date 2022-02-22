using TaskTracker.Core.Enums;

namespace TaskTracker.Core.Entities
{
    public class TaskItem : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        private DateTime? _startDate;        
        public DateTime? StartDate => _startDate;
        private DateTime? _completionDate;        
        public DateTime? CompletionDate => _completionDate;        
        public TaskItemStatus Status { get; set; }        
        public int Priority { get; set; }
        public int? ProjectId { get; internal set; }
        /// <summary>
        /// Accesses task's project. Use project to set the task's project
        /// </summary>
        public Project? Project { get; internal set; }

        public TaskItem(string name) { Name = name; }

        /// <summary>
        /// Sets the start date for the task, given that the passed value is valid
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
                throw new ArgumentOutOfRangeException("Task's start date has to be earlier than its completion date");
        }

        /// <summary>
        /// Sets the completion date for the task, given that the passed value is valid
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
                throw new ArgumentOutOfRangeException("Task's completion date has to be later than its start date");
        }
    }
}
