using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Tutorial_2.Data;
using WebAPI_Tutorial_2.Models;

namespace WebAPI_Tutorial_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Course>>> GetAllCourses()
        {
            var dbCourses = await _context.Courses.ToListAsync();
            return Ok(dbCourses);
        }
    }
}
