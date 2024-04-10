namespace TodoApp.Application.ViewModels
{
    public class TasksViewModel
    {
        public IEnumerable<Domain.Entities.Task> Tasks { get; set; }
        public int TasksCount { get; set; }
        public int HomeCount { get; set; }
        public int WorkCount { get; set; }
        public int PersonalCount { get; set; }
        public int ShoppingCount { get; set; }

    }
}
