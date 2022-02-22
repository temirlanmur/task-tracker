using TaskTracker.Core.Entities;
using TaskTracker.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Infrastructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context) { _context = context; }

        public Project? GetById(int id)        
            => _context
                .Projects
                .Include(p => p.TasksItems)
                .FirstOrDefault(p => p.Id == id);

        public IEnumerable<Project> GetAll()
            => _context
                .Projects                
                .ToList();

        public void Add(Project entity)
        {
            _context.Projects.Add(entity);
            _context.SaveChanges();
        }
        
        public void Update(Project entity)
        {
            _context.Projects.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var project = _context
                .Projects
                .FirstOrDefault(p => p.Id == id);
            if (project == null || project.IsDeleted == true)
                throw new ArgumentException("Project cannot be found");
            project.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
