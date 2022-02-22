using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskItemRepository(ApplicationDbContext context) { _context = context; }

        public TaskItem? GetById(int id)
            => _context
                .TaskItems
                .Include(t => t.Project)
                .FirstOrDefault(t => t.Id == id);

        public IEnumerable<TaskItem> GetAll()
            => _context
                .TaskItems                
                .ToList();
        
        public void Add(TaskItem entity)
        {
            _context.TaskItems.Add(entity);
            _context.SaveChanges();
        }                

        public void Update(TaskItem entity)
        {
            _context.TaskItems.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var taskItem = _context
                .TaskItems
                .FirstOrDefault(t => t.Id == id);
            if (taskItem == null || taskItem.IsDeleted == true)
                throw new ArgumentException("Task cannot be found");
            taskItem.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
