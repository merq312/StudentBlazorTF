using System.ComponentModel.DataAnnotations;

namespace ServerBlazorEF.Models {
  // This is the C# class that models the data structure that we are going to create.
  // We have a variable for each field in the database.
  public class Student {
    public string StudentId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string CourseCode { get; set; }
    [Required]
    public string CourseTitle { get; set; }
  }
}