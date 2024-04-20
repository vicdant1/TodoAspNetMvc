using Microsoft.AspNetCore.Identity;

namespace TodoApp.Domain.Identity
{
    // If I need any other info, I can add it here
    public class AppUser : IdentityUser
    {
        ICollection<Entities.Task> Tasks;
    }
}
