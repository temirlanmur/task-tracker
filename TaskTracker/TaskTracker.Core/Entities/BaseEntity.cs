namespace TaskTracker.Core.Entities
{
    public class BaseEntity
    {                
        public DateTime CreatedAt { get; } = DateTime.Now;        
        public bool IsDeleted { get; set; } = false;
    }
}
