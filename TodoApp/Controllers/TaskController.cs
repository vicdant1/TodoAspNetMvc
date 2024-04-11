using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Application.ViewModels;
using TodoApp.Domain.Enums;

namespace TodoApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<ActionResult> Index()
        {
            var tasks = await _taskService.GetAllTasks();
            return View(new TasksViewModel
            {
                Tasks = tasks,
                HomeCount = tasks.Count(task => task.Category == ETaskCategory.Home),
                PersonalCount = tasks.Count(task => task.Category == ETaskCategory.Personal),
                ShoppingCount = tasks.Count(task => task.Category == ETaskCategory.Shopping),
                WorkCount = tasks.Count(task => task.Category == ETaskCategory.Work),
                TasksCount = tasks.Count(),
            });
        }

        public async Task<ActionResult> Details(int id)
        {
            var model = await _taskService.GetAsync(id);
            if(model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Domain.Entities.Task task)
        {
            try
            {
                if(!ModelState.IsValid)
                    return View(task);

                await _taskService.CreateTask(task);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var model = await _taskService.GetAsync(id);

            if(model == null)
                return RedirectToAction(nameof(Index));

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Domain.Entities.Task task)
        {
            try
            {
                await _taskService.UpdateTask(task);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> MarkTaskAsCompleted(int id)
        {
            try
            {
                await _taskService.MarkTaskAsCompleted(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _taskService.DeleteTask(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        [HttpPost]
        public async Task<ActionResult> SendTasksEmail(SendEmailDto input)
        {
            await _taskService.SendTasksEmail(input.Email);

            return Ok();
        }
    }
}
