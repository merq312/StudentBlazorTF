# Student Blazor App for STY1001

## What you need

- Latest .NET version
- Visual Studio Code (or any editor)
- SQL Server Express LocalDB
> https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sql-server-ver15
- Install Entity Framework CLI
> dotnet tool install --global dotnet-ef --version 5.0.0-*

---

## Instructions

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

```
using System.ComponentModel.DataAnnotations;

namespace ServerBlazorEF.Models {
  public class Student {
    public string StudentId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string School { get; set; }
  }
}
```

5. Open appsettings.json and enter the following code to the json object.

```
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CollegeDB;Trusted_Connection=True;MultipleActiveResultSets=true"
},
```

6. In the Data folder, create a file SchoolDbContext.cs.

```
using System;
using Microsoft.EntityFrameworkCore;

namespace ServerBlazorEF.Models {
  public class SchoolDbContext : DbContext {
    public DbSet<Student> Students { get; set; }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);

      builder.Entity<Student>().HasData(
        new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Jane",
          LastName = "Smith",
          School = "Medicine"
        }, new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "John",
          LastName = "Fisher",
          School = "Engineering"
        }, new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Pamela",
          LastName = "Baker",
          School = "Food Science"
        }, new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Peter",
          LastName = "Taylor",
          School = "Mining"
        }
      );
    }
  }
}
```

7. Go to the Startup.cs file. Add the following code to the function ConfigureServices()

```
services.AddDbContext<SchoolDbContext>(
    option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
```

8. Enter the root directory of your project with a terminal. And execute the following command

> dotnet-ef migrations add initial_migration

If executed correctly there should be a new folder in your root called Migrations.

9. Next, create the database by running this command in your terminal.

> dotnet-ef database update

10. Create a file StudentService.cs in the Data folder.

```
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerBlazorEF.Models {
  public class StudentService {
      SchoolDbContext _context;
      public StudentService(SchoolDbContext context) {
        _context = context;
      }

      public async Task<List<Student>> GetStudentsAsync() {
        return await _context.Students.ToListAsync();
      }

      public async Task<Student> GetStudentByIdAsync(string id) {
        return await _context.Students.FindAsync(id);
      }

      public async Task<Student> InsertStudentAsync(Student student) {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return student;
      }

      public async Task<Student> UpdateStudentAsync(string id, Student s) {
        var student = await _context.Students.FindAsync(id);
        
        if (student == null)
          return null;

        student.FirstName = s.FirstName;
        student.LastName = s.LastName;
        student.School = s.School;

        _context.Students.Update(student);
        await _context.SaveChangesAsync();

        return student;
      }

      public async Task<Student> DeleteStudentAsync(string id)
      {
        var student = await _context.Students.FindAsync(id);
        
        if (student == null)
          return null;

        _context.Students.Remove(student);
        await _context.SaveChangesAsync();

        return student;
      }

      private bool StudentExists(string id) {
        return _context.Students.Any(e => e.StudentId == id);
      }
  }
}
```

11. Add the following to the ConfigureServices() method in the Startup.cs file.

```
services.AddScoped<StudentService>();
```

12. In the Pages folder, create a new file Students.razor

```
@page "/students"
@using ServerBlazorEF.Models
@inject StudentService studentService

<h1>Students</h1>

<p>This component demonstrates managing students data.</p>

@if (students == null) {
  <p><em>Loading...</em></p>
} else {
  <button @onclick="Add"  class="btn btn-success">Add</button>
  <table class='table table-hover'>
    <thead>
      <tr>
        <th>ID</th>
        <th>First Name</th>
        <th>Last Name</th>
        <th>School</th>
      </tr>
    </thead>
    <tbody>
      @foreach (var item in students)
      {
        <tr @onclick="(() => Show(item.StudentId))">
          <td>@item.StudentId</td>
          <td>@item.FirstName</td>
          <td>@item.LastName</td>
          <td>@item.School</td>
        </tr>
        }
    </tbody>
  </table>
}

@if (students != null && mode==MODE.Add) // Insert form 
{
  <input placeholder="First Name" @bind="@firstName" /><br />
  <input placeholder="Last Name" @bind="@lastName" /><br />
  <input placeholder="School" @bind="@school" /><br />
  <button @onclick="Insert" class="btn btn-warning">Insert</button>
}

@if (students != null && mode==MODE.EditDelete) // Update & Delete form
{
  <input type="hidden" @bind="@studentId" /><br />
  <input placeholder="First Name" @bind="@firstName" /><br />
  <input placeholder="Last Name" @bind="@lastName" /><br />
  <input placeholder="School" @bind="@school" /><br />
  <button @onclick="Update" class="btn btn-primary">Update</button>
  <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
  <button @onclick="Delete" class="btn btn-danger">Delete</button>
}

@functions {
  List<Student> students;
  string studentId;
  string firstName;
  string lastName;
  string school;

  private enum MODE { None, Add, EditDelete };
  MODE mode = MODE.None;
  Student student;

  protected override async Task OnInitializedAsync() {
    await load();
  }

  protected async Task load() {
    students = await studentService.GetStudentsAsync();
  }

  protected async Task Insert() {
    Student s = new Student() {
      StudentId = Guid.NewGuid().ToString(),
      FirstName = firstName,
      LastName = lastName,
      School = school
    };

    await studentService.InsertStudentAsync(s);
    ClearFields();
    await load();
    mode = MODE.None;
  }

  protected void ClearFields() {
    studentId = string.Empty;
    firstName = string.Empty;
    lastName = string.Empty;
    school = string.Empty;
  }

  protected void Add() { 
    ClearFields();
    mode = MODE.Add;
  }

  protected async Task Update() {

    Student s = new Student() {
      StudentId = studentId,
      FirstName = firstName,
      LastName = lastName,
      School = school
    };

    await studentService.UpdateStudentAsync(studentId, s);
    ClearFields();
    await load();
    mode = MODE.None;
  }

  protected async Task Delete() {
    await studentService.DeleteStudentAsync(studentId);
    ClearFields();
    await load();
    mode = MODE.None;
  }
  protected async Task Show(string id) {
    student = await studentService.GetStudentByIdAsync(id);
    studentId = student.StudentId;
    firstName = student.FirstName;
    lastName = student.LastName;
    school = student.School;
    mode = MODE.EditDelete;
  }
}
```

13. Add a navlink to the students page. Open NavMenu.razor in the Shared folder. Enter the following code into ul block.

```
<li class="nav-item px-3">
  <NavLink class="nav-link" href="students">
    <span class="oi oi-list-rich" aria-hidden="true"></span> Students
  </NavLink>
</li>
```

14. Build and run the project again.