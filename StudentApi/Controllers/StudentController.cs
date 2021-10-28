using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;

        public StudentController(StudentContext context)
        {
            _context = context;
        }

        // GetStudentItems
        // GET: api/Student    ,   api/GetAllStudents
        // [HttpGet]        
        [Route("GetAllStudents")]
        public async Task<ActionResult<IEnumerable<StudentInfoClass>>> GetStudentItems()
        {
            return await _context.StudentInfo.ToListAsync();
        }

        // GetStudentItem
        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentInfoClass>> GetStudentItem(int id)
        {
            var studentItem = await _context.StudentInfo.FindAsync(id);

            if (studentItem == null)
            {
                return NotFound();
            }

            return studentItem;
        }

        // PutStudentItem
        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentItem(int id, StudentInfoClass studentItem)
        {
            if (id != studentItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // PostStudentItem
        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentInfoClass>> PostStudentItem(StudentInfoClass studentItem)
        {
            _context.StudentInfo.Add(studentItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentItem), new { id = studentItem.Id }, studentItem);
        }

        // DeleteStudentItem
        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentItem(int id)
        {
            var studentItem = await _context.StudentInfo.FindAsync(id);
            if (studentItem == null)
            {
                return NotFound();
            }

            _context.StudentInfo.Remove(studentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentItemExists(int id)
        {
            return _context.StudentInfo.Any(e => e.Id == id);
        }
    }
}
