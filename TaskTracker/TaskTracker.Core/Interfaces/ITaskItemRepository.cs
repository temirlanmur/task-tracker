using TaskTracker.Core.Entities;

namespace TaskTracker.Core.Interfaces
{
    public interface ITaskItemRepository : IRepository<TaskItem>
    {
        // May define some custom persistence logic
    }
}
