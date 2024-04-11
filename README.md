# ASP.NET Core MVC Todo App

This repository contains a simple Todo application built using ASP.NET Core MVC. The application allows users to manage their tasks efficiently.

## Feature video (click on thumbnail to go there)
[![TodoApp Cloud Plus Plus](https://img.youtube.com/vi/AmU7T4pXdmg/maxresdefault.jpg)](https://www.youtube.com/watch?v=AmU7T4pXdmg)

## Stack and Approaches

### Stack
- **ASP.NET Core MVC:** The application is built using ASP.NET Core MVC, providing a robust and scalable web framework for building web applications.
- **Entity Framework Core:** Entity Framework Core is used for data access, providing a convenient and powerful way to interact with the database.
- **Bootstrap:** Bootstrap is used for front-end styling and layout, ensuring a responsive and visually appealing user interface.
- **Razor Pages:** Razor Pages are used for server-side page generation, enabling dynamic content rendering.

### Approaches
- **Model-View-Controller (MVC) Architecture:** The application follows the MVC architectural pattern, separating concerns for improved maintainability and scalability.
- **Dependency Injection:** ASP.NET Core's built-in dependency injection container is used to manage dependencies and promote loose coupling between components.
- **Validation:** Data validation is implemented both on the client-side and server-side to ensure data integrity and security.
- **DDD and Clean Arch:** Domain-Driven Design and Clean Arch approaches are used on the code organization.
- **Email Sending:** An extra feature has been implemented to send email notifications using the application's own SMTP server. This feature enhances user experience by providing timely reminders and updates.

## Screenshots

### Home Page
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/29258a4a-9b56-4f26-915c-aa9568b81d3b)

### Todo List Page
#### When there are no tasks:
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/b2817b1e-1ff7-4e5b-a28b-eea60a8785d3)
#### When tasks are seeded:
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/f7643a4a-ea1c-423a-913d-07788721ae7d)

### Adding a Todo Item
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/a1c647be-67ca-4e29-bf95-539a6f8fd5b1)


### Editing a Todo Item
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/47d2f9ef-09ff-4075-b78e-010e8840b8f0)


### Email Sending Feature
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/517f24b8-2a9a-4220-828a-0a2c0110735f)
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/3906d791-a8ce-43b4-862d-a3c1113cd6e1)
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/c958c0ce-bbc4-49cb-be19-80a1961aac36)
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/5589317c-cbdf-4baa-a7e3-c96f944268e0)
![image](https://github.com/vicdant1/TodoAspNetMvc/assets/69057084/4bb95e97-025d-4898-97d6-2218f5b39e94)

## How to Run

To run this application locally, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution in Visual Studio or your preferred code editor.
3. Build the solution to restore the NuGet packages.
4. Update the connection string in the `appsettings.json` file to point to your local database.

   Example `appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=TodoAppDb;User=yourusername;Password=yourpassword;"
     }
   }
   ```

5. Run `dotnet ef database update` command or open NuGet Package Manager and run `Update-Database` command
6. Run app and have fun : )
