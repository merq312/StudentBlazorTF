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
          FirstName = "Chamila",
          LastName = "Gunasena",
          Email = "merc312@gmail.com",
          CourseCode = "STY1001",
          CourseTitle = "Software Engineering Concepts"
        }
      );
    }
  }
}