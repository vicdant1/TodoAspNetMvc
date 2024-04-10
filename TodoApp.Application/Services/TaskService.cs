using TodoApp.Application.Interfaces;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<Domain.Entities.Task> CreateTask(Domain.Entities.Task task)
        {
            return _taskRepository.CreateTask(task);
        }

        public Task<Domain.Entities.Task> DeleteTask(int id)
        {
            return _taskRepository.DeleteTask(id);
        }

        public Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            return _taskRepository.GetAllTasks();
        }

        public Task<Domain.Entities.Task> GetAsync(int id)
        {
            return _taskRepository.GetAsync(id);
        }

        public Task<IEnumerable<Domain.Entities.Task>> GetTasksByCategory(ETaskCategory category)
        {
            return _taskRepository.GetTasksByCategory(category);
        }

        public Task<IEnumerable<Domain.Entities.Task>> GetTasksByPriority(ETaskPriority taskPriority)
        {
            return _taskRepository.GetTasksByPriority(taskPriority);
        }

        public async Task<Domain.Entities.Task> MarkTaskAsCompleted(int id)
        {
            var task = await _taskRepository.GetAsync(id);
            if (task == null)
                throw new Exception("Not found such task");

            task.IsCompleted = true;

            await UpdateTask(task);

            return task;
        }

        public Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
        {
            return _taskRepository.UpdateTask(task);
        }
    }
}
