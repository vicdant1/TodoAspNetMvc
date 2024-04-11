using TodoApp.Domain.Enums;

namespace TodoApp.Application.Interfaces
{
    public interface ITaskService
    {
        Task<Domain.Entities.Task> CreateTask(Domain.Entities.Task task);
        Task<IEnumerable<Domain.Entities.Task>> GetAllTasks();
        Task SendTasksEmail(string emailTo);
        Task<Domain.Entities.Task> GetAsync(int id);
        Task<IEnumerable<Domain.Entities.Task>> GetTasksByCategory(ETaskCategory category);
        Task<IEnumerable<Domain.Entities.Task>> GetTasksByPriority(ETaskPriority taskPriority);
        Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task);
        Task<Domain.Entities.Task> MarkTaskAsCompleted(int id);
        Task<Domain.Entities.Task> DeleteTask(int id);
    }
}
