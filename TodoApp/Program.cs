using Microsoft.AspNetCore.Identity;
using TodoApp.Domain.Identity;
using TodoApp.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


#region Roles Settings

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Manager", "Member" }; // Specify as many roles as necessary

    foreach (var role in roles)
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

    string email = "admin@yourwebsite.com";
    string pass = "12341234";

    if(await userManager.FindByEmailAsync(email) == null)
    {
        var user = new AppUser();
        user.Email = email;
        user.UserName = email;

        await userManager.CreateAsync(user, pass);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

#endregion


app.Run();
