using TaskTracker.Core.Entities;

namespace TaskTracker.Core.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        // May define some custom persistence logic
    }
}
