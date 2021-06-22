What you need
- Latest .NET version
- Visual Studio Code (or any editor)
- SQL Server Express LocalDB
> https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15
- Install Entity Framework CLI
> dotnet tool install --global dotnet-ef --version 5.0.0-*

---

1. Open a terminal window, go to the directory you wish to create the project in, and create a Blazor server app by typing 

> dotnet new blazorserver -o StudentBlazorTF

2. Enter the folder, and ensure that the app template is functional (visit localhost:5000 on your browser).

> cd StudentBlazorTF
> dotnet run

4. Run these commands in your terminal.

> dotnet add package Microsoft.EntityFrameworkCore.Design
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer
> dotnet add package Microsoft.EntityFrameworkCore.SqlServer.Design

3. Open the newly created folder in your code editor.

4. Create a folder called Models inside the Data folder. Create a file Student.cs inside Models (this is our data model). Enter the following code.

> ...

5. Open appsettings.json and enter the following code to the json object.

> "ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CollegeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
},

6. In the Data folder, create a file SchoolDbContext.cs.

> ...

7. Go to the Startup.cs file. Add the following code to the function ConfigureServices()

> ...

8. Enter the root directory of your project with a terminal. And execute the following command

> dotnet-ef migrations add initial_migration

If executed correctly there should be a new folder in your root called Migrations.

9. Next, create the database by running this command in your terminal.

> dotnet-ef database update

10. Create a file StudentService.cs in the Data folder.

> ...

11. Add the following to the ConfigureServices() method in the Startup.cs file.

> services.AddScoped<StudentService>();

12. In the Pages folder, create a new file Students.razor

> ...

13. Add a navlink to the students page. Open NavMenu.razor in the Shared folder. Enter the following code into ul block.

> <li class="nav-item px-3">
>   <NavLink class="nav-link" href="students">
>     <span class="oi oi-list-rich" aria-hidden="true"></span> Students
>   </NavLink>
> </li>

14. Build and run the project again.