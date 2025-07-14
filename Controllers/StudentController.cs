using Microsoft.AspNetCore.Mvc;
using StudentListEF.Data;
using StudentListEF.Models;

namespace StudentListEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StudentList>> GetAllStudents()
        {
            var students = _context.StudentList;
            
            return Ok(students);

        }

        [HttpPost]
        public ActionResult<StudentList> AddStudent(StudentList student)
        {
            _context.StudentList.Add(student);
            _context.SaveChanges();
            return Created("", student);
        }

        [HttpPut("{id}")]
        public ActionResult<StudentList> UpdatingCourse(int id, [FromBody] string Course)
        {

            var student = _context.StudentList.FirstOrDefault(x => x.Id == id);
            student.Course = Course;
            _context.SaveChanges();
            return Ok(student);

        }

        [HttpDelete("{id}")]
        public ActionResult<bool> DeleteStudent(int id)
        {
            var student = _context.StudentList.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            _context.StudentList.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
