using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Enums;
using TodoApp.Domain.Identity;
using TodoApp.Domain.Interfaces;
using TodoApp.Infra.Data.Context;

namespace TodoApp.Infra.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private string _currentUserId => _userManager.GetUserId(_httpContextAccessor.HttpContext.User)!;

        public TaskRepository(AppDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<Domain.Entities.Task> CreateTask(Domain.Entities.Task task)
        {
            task.CreationTime = DateTime.Now;
            task.UserId = _currentUserId;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Domain.Entities.Task> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null && task.UserId.Equals(_currentUserId))
            {
                task.IsDeleted = true;

                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return task!;
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetAllTasks()
        {
            return await _context.Tasks.Where(task => !task.IsDeleted && task.UserId.Equals(_currentUserId)).ToListAsync();
        }

        public async Task<Domain.Entities.Task> GetAsync(int id)
        {
            return await _context.Tasks.Where(task => task.Id == id && !task.IsDeleted && task.UserId.Equals(_currentUserId)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByCategory(ETaskCategory category)
        {
            return await _context.Tasks.Where(t => t.Category == category && !t.IsDeleted && t.UserId.Equals(_currentUserId)).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Task>> GetTasksByPriority(ETaskPriority taskPriority)
        {
            return await _context.Tasks.Where(t => t.Priority == taskPriority && !t.IsDeleted && t.UserId.Equals(_currentUserId)).ToListAsync();
        }

        public async Task<Domain.Entities.Task> UpdateTask(Domain.Entities.Task task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return task;
        }

    }
}
