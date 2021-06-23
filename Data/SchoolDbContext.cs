using System;
using Microsoft.EntityFrameworkCore;

namespace ServerBlazorEF.Models {
    // This code, using EntityFrameworkCore and the model we created (Student.cs) will create the database schema.
    // We populate the database with 4 initial entries, one for each group member.
  public class SchoolDbContext : DbContext {
    public DbSet<Student> Students { get; set; }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);

      builder.Entity<Student>().HasData(
        new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Chamila",
          LastName = "Gunasena",
          Email = "merc312@gmail.com",
          CourseCode = "STY1001",
          CourseTitle = "Software Engineering Concepts"
        },
        new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Pardeep",
          LastName = "Malhi",
          Email = "pardeep27malhi@gmail.com",
          CourseCode = "STY1001",
          CourseTitle = "Software Engineering Concepts"
        },
        new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Crispain",
          LastName = "Ntwali",
          Email = "ntwalicris@yahoo.fr",
          CourseCode = "STY1001",
          CourseTitle = "Software Engineering Concepts"
        },
        new {
          StudentId = Guid.NewGuid().ToString(),
          FirstName = "Praveen",
          LastName = "Perera",
          Email = "praveenshashika@yahoo.com",
          CourseCode = "STY1001",
          CourseTitle = "Software Engineering Concepts"
        }
      );
    }
  }
}
