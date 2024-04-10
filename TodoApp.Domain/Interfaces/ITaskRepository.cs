using TodoApp.Domain.Enums;

namespace TodoApp.Domain.Interfaces
{
    public interface ITaskRepository
    {
        Task<Entities.Task> CreateTask(Entities.Task task);
        Task<IEnumerable<Entities.Task>> GetAllTasks();
        Task<Entities.Task> GetAsync(int id);
        Task<IEnumerable<Entities.Task>> GetTasksByCategory(ETaskCategory category);
        Task<IEnumerable<Entities.Task>> GetTasksByPriority(ETaskPriority taskPriority);
        Task<Entities.Task> UpdateTask(Entities.Task task);
        Task<Entities.Task> DeleteTask(int id);
    }
}
