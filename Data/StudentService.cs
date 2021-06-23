using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerBlazorEF.Models {
  // This class contains CRUD operations to interface with the SQL database.
  // We have Get (Read), Insert (Create), Update, and Delete methods in this function.
  // These methods are asynchronous as performing operations on database is not instantaneous.
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
        student.Email = s.Email;
        student.CourseCode = s.CourseCode;
        student.CourseTitle = s.CourseTitle;

        _context.Students.Update(student);
        await _context.SaveChangesAsync();

        return student;
      }

      public async Task<Student> DeleteStudentAsync(string id) {
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
