using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Interfaces;
using TodoApp.Infra.Data.Context;

namespace TodoApp.Infra.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Task> CreateTask(Domain.Entities.Task task)
        {
            task.CreationTime = DateTime.Now;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Domain.Entities.Task> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                task.IsDeleted = true;

                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return task;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            return await _context.Tasks.Where(task => !task.IsDeleted).ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetAsync(int id)
        {
            return await _context.Tasks.Where(task => task.Id == id && !task.IsDeleted).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByCategory(ETaskCategory category)
        {
            return await _context.Tasks.Where(t => t.Category == category && !t.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByPriority(ETaskPriority taskPriority)
        {
            return await _context.Tasks.Where(t => t.Priority == taskPriority && !t.IsDeleted).ToListAsync();
        }

        public async Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

    }
}
