using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Interfaces;
using TodoApp.Application.ViewModels;
using TodoApp.Domain.Enums;

namespace TodoApp.Controllers
{

    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly ITaskService _taskService;
        public DashboardController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        public async Task<IActionResult> Index()
        {
            var usersTasks = (await _taskService.GetAllUsersTasks()).GroupBy(task => task.UserId);

            if(usersTasks.Any() )
                return View(new DashboardViewModel
                {
                    Tasks = usersTasks.Select(tasks => new TasksViewModel
                    {
                        Tasks = tasks,
                        HomeCount = tasks.Count(task => task.Category == ETaskCategory.Home),
                        PersonalCount = tasks.Count(task => task.Category == ETaskCategory.Personal),
                        ShoppingCount = tasks.Count(task => task.Category == ETaskCategory.Shopping),
                        WorkCount = tasks.Count(task => task.Category == ETaskCategory.Work),
                        TasksCount = tasks.Count(),
                    }).ToList()
                });

            return View();
        }
    }
}
