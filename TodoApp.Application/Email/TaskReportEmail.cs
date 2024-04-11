using System.Text;

namespace TodoApp.Application.Email
{
    public static class TaskReportEmail
    {
        public static string GenerateEmailBody(IEnumerable<Domain.Entities.Task> tasks)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang=\"en\">");
            sb.Append("<head>");
            sb.Append("<meta charset=\"UTF-8\">");
            sb.Append("<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            sb.Append("<title>Tasks Report</title>");
            sb.Append("</head>");
            sb.Append("<body style=\"font-family: Arial, sans-serif;\">");
            sb.Append("<h2 style=\"color: #333;\">Tasks Report</h2>");
            sb.Append("<table style=\"border-collapse: collapse; width: 100%;\">");
            sb.Append("<tr style=\"background-color: #f2f2f2;\">");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">ID</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Title</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Description</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Category</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Priority</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Deadline</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Creation Time</th>");
            sb.Append("<th style=\"border: 1px solid #ddd; padding: 8px;\">Is Completed</th>");
            sb.Append("</tr>");

            foreach (var task in tasks)
            {
                sb.Append("<tr>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Id}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Title}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Description}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Category}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Priority}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.Deadline}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{task.CreationTime}</td>");
                sb.Append($"<td style=\"border: 1px solid #ddd; padding: 8px;\">{(task.IsCompleted ? "✅" : "❌")}</td>");
                sb.Append("</tr>");
            }

            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");

            return sb.ToString();
        }
    }
}
