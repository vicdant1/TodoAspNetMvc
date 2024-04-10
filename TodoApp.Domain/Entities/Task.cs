using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ETaskCategory Category { get; set; }
        public ETaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreationTime { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }

    }
}
