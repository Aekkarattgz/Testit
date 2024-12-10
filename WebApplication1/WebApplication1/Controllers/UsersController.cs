using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            // ตรวจสอบว่า ModelState ถูกต้อง
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // ส่งกลับข้อความข้อผิดพลาดจาก ModelState
            }

            // ตรวจสอบว่า UserTypeId ที่ได้รับมามีอยู่ในฐานข้อมูลหรือไม่
            var userType = await _context.UserTypes.FindAsync(user.UserTypeId);
            if (userType == null)
            {
                return BadRequest("Invalid UserTypeId");  // ส่งกลับข้อผิดพลาดหากไม่พบ UserType
            }

            // เชื่อมโยง UserType กับ User
            user.UserType = userType;  // เชื่อมโยง UserType ที่ค้นหาแล้วให้กับ User

            try
            {
                // บันทึกข้อมูล User
                _context.Users.Add(user);
                await _context.SaveChangesAsync();  // ทำการบันทึกข้อมูล

                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);  // ส่งกลับข้อมูลผู้ใช้ที่ถูกสร้าง
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");  // ส่งกลับข้อผิดพลาดหากเกิด Exception
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
