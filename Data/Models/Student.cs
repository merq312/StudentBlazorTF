using System.ComponentModel.DataAnnotations;

namespace ServerBlazorEF.Models {
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